// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFingerprintCallback.cs" company="Op@ SAS">
//   MIT License
// </copyright>
// <summary>
//   The FingerprintCallback interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Opa.Poc.Fingerprint.Bridge
{
    using System.Runtime.InteropServices;

    using Opa.Poc.Fingerprint.Dto;

    /// <summary>
    /// The FingerprintCallback interface.
    /// </summary>
    [Guid("26ebd4e2-d903-46c3-8646-04291e7997e9")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IFingerprintCallback
    {
        /// <summary>
        /// The capture processed.
        /// </summary>
        /// <param name="result">
        /// The result.
        /// </param>
        [DispId(1)]
        void CaptureProcessed(ResultFingerprint result);
    }
}
