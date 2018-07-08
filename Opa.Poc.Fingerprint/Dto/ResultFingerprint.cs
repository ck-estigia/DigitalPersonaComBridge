// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResultFingerprint.cs" company="Op@ SAS">
//   MIT License
// </copyright>
// <summary>
//   Defines the ResultFingerprint type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Opa.Poc.Fingerprint.Dto
{
    using System.Drawing;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The result fingerprint.
    /// </summary>
    [Guid("26ebd4e2-d903-46c3-8646-04291e7997e6")]    
    [ProgId("Opa.Interop.Com.ResultFingerprint")]
    [ComVisible(true)]
    public class ResultFingerprint : IResultFingerprint
    {
        /// <summary>
        /// Gets or sets the xml fmd
        /// </summary>
        public string XmlFmd { get; set; }

        /// <summary>
        /// Gets or sets the file fingerprint image.
        /// </summary>
        public string FileFingerprintImage { get; set; }

        /// <summary>
        /// Gets or sets the string image fingerprints.
        /// </summary>
        public string StringImageFingerprints { get; set; }

        /// <summary>
        /// Gets or sets the fingerprints.
        /// </summary>
        public Bitmap ImageFingerprints { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether result.
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
    }
}
