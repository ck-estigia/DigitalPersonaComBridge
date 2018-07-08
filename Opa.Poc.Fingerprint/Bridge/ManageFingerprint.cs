// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManageFingerprint.cs" company="Op@ SAS">
//   MIT License
// </copyright>
// <summary>
//   Defines the ManageFingerprint type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Opa.Poc.Fingerprint.Bridge
{
    using System.Runtime.InteropServices;
    using System.Threading;

    using DPUruNet;

    using Opa.Poc.Fingerprint.Dto;
    using Opa.Poc.Fingerprint.Resources;

    /// <summary>
    /// The manage fingerprint.
    /// </summary>
    [Guid("26ebd4e2-d903-46c3-8646-04291e7997e8")]    
    [ProgId("Opa.Interop.Com.Fingerprint")]
    [ComSourceInterfaces(typeof(IFingerprintCallback))]
    [ComVisible(true)]
    public class ManageFingerprint : IManageFingerprint
    {
        /// <summary>
        /// The probability one.
        /// </summary>
        private const int ProbabilityOne = 0x7fffffff;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageFingerprint"/> class.
        /// </summary>
        public ManageFingerprint()
        {
        }

        /// <summary>
        /// The on captured processed.
        /// </summary>
        /// <param name="result">
        /// The result.
        /// </param>
        public delegate void OnCapturedProcessed(ResultFingerprint result);

        /// <summary>
        /// The capture processed.
        /// </summary>
        public event OnCapturedProcessed CaptureProcessed;

        /// <summary>
        /// The match fingerprint.
        /// </summary>
        /// <param name="firstsFmd">
        /// The firsts fmd.
        /// </param>
        /// <param name="secondFmd">
        /// The second fmd.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool MatchFingerprint(string firstsFmd, string secondFmd)
        {
            var fmdFirsts = Fmd.DeserializeXml(firstsFmd);
            var fmdSecond = Fmd.DeserializeXml(secondFmd);
            var resultCompare = Comparison.Compare(fmdFirsts, 0, fmdSecond, 0);

            if (resultCompare.ResultCode != Constants.ResultCode.DP_SUCCESS)
            {
                return false;
            }

            return resultCompare.Score < (ProbabilityOne / 100000);
        }

        /// <summary>
        /// The capture fingerprint.
        /// </summary>
        /// <returns>
        /// The <see cref="ResultFingerprint"/>.
        /// </returns>
        public ResultFingerprint CaptureFingerprint()
        {
            var readers = ReaderCollection.GetReaders();

            var resultFingerprint = this.ValidateReader(readers);
            if (!resultFingerprint.Result)
            {
                return resultFingerprint;
            }

            var currentReader = readers[0];
            var resultOpen = currentReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);

            if (resultOpen != Constants.ResultCode.DP_SUCCESS)
            {
                resultFingerprint.Result = false;
                resultFingerprint.Message = es_CO.CannotOpenReader;
            }

            currentReader.On_Captured += this.OnCapture;

            if (this.ValidateReader(currentReader))
            {
                resultFingerprint.Result = false;
                resultFingerprint.Message = es_CO.ReaderNotReady;
            }

            var captureResult = currentReader.CaptureAsync(
                Constants.Formats.Fid.ANSI,
                Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT,
                currentReader.Capabilities.Resolutions[0]);

            if (captureResult != Constants.ResultCode.DP_SUCCESS)
            {
                resultFingerprint.Result = false;
                resultFingerprint.Message = es_CO.CaptureFail;
            }

            resultFingerprint.Result = true;
            resultFingerprint.Message = es_CO.WithoutReader;

            return resultFingerprint;
        }

        /// <summary>
        /// The on capture.
        /// </summary>
        /// <param name="captureResult">
        /// The capture result.
        /// </param>
        private void OnCapture(CaptureResult captureResult)
        {
            var resultFingerprint = new ResultFingerprint { Result = this.CheckCaptureResult(captureResult) };

            resultFingerprint.Message = !resultFingerprint.Result ? es_CO.BadCapture : es_CO.Captured;            
            resultFingerprint.ImageFingerprints = !resultFingerprint.Result ? null : FingerprintSerializer.GetFingerprintBitmap(captureResult.Data.Views);
            resultFingerprint.StringImageFingerprints = !resultFingerprint.Result ? null : FingerprintSerializer.GetFingerprintStringBitmap(captureResult.Data.Views);
            resultFingerprint.XmlFmd = !resultFingerprint.Result ? string.Empty : Fmd.SerializeXml(FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI).Data);
            resultFingerprint.FileFingerprintImage = !resultFingerprint.Result ? string.Empty : FingerprintSerializer.GetFingerprintFile(captureResult.Data.Views); 

            this.CaptureProcessed?.Invoke(resultFingerprint);
        }

        /// <summary>
        /// The check capture result.
        /// </summary>
        /// <param name="captureResult">
        /// The capture result.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CheckCaptureResult(CaptureResult captureResult)
        {
            if (captureResult.Quality != Constants.CaptureQuality.DP_QUALITY_GOOD)
            {
                return false;
            }

            return captureResult.Data != null;
        }

        /// <summary>
        /// The validate reader.
        /// </summary>
        /// <param name="reader">
        /// The reader.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool ValidateReader(Reader reader)
        {
            var resultStatus = reader.GetStatus();

            if (resultStatus != Constants.ResultCode.DP_SUCCESS)
            {
                return false;
            }

            if (reader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION)
            {
                reader.Calibrate();
            }

            if (reader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY)
            {
                Thread.Sleep(50);
            }

            return reader.Status.Status == Constants.ReaderStatuses.DP_STATUS_READY;
        }

        /// <summary>
        /// The validate reader.
        /// </summary>
        /// <param name="readers">
        /// The readers.
        /// </param>
        /// <returns>
        /// The <see cref="ResultFingerprint"/>.
        /// </returns>
        private ResultFingerprint ValidateReader(ReaderCollection readers)
        {
            var resultFingerprint = new ResultFingerprint();

            if (readers.Count == 0)
            {
                resultFingerprint.Result = false;
                resultFingerprint.Message = es_CO.WithoutReader;
                return resultFingerprint;
            }

            if (readers.Count > 1)
            {
                resultFingerprint.Result = false;
                resultFingerprint.Message = es_CO.MultipleReaders;
                return resultFingerprint;
            }

            resultFingerprint.Result = true;
            return resultFingerprint;
        }
    }
}
