// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IResultFingerprint.cs" company="Op@ SAS">
//   MIT License
// </copyright>
// <summary>
//   Defines the IResultFingerprint type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Opa.Poc.Fingerprint.Dto
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The ResultFingerprint interface.
    /// </summary>
    [Guid("7f0af108-6724-4135-888f-770d993bea6d")]
    [ComVisible(true)]
    public interface IResultFingerprint
    {
        /// <summary>
        /// Gets or sets the xml fmd
        /// </summary>
        string XmlFmd { get; set; }

        /// <summary>
        /// Gets or sets the file fingerprint image.
        /// </summary>
        string FileFingerprintImage { get; set; }

        /// <summary>
        /// Gets or sets the fingerprints.
        /// </summary>
        Bitmap ImageFingerprints { get; set; }

        /// <summary>
        /// Gets or sets the string image fingerprints.
        /// </summary>
        string StringImageFingerprints { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether result.
        /// </summary>
        bool Result { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        string Message { get; set; }
    }
}