// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IManageFingerprint.cs" company="Op@ SAS">
//   MIT License
// </copyright>
// <summary>
//   The ManageFingerprint interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Opa.Poc.Fingerprint.Bridge
{
    using System.Runtime.InteropServices;

    using Opa.Poc.Fingerprint.Dto;

    /// <summary>
    /// The ManageFingerprint interface.
    /// </summary>
    [Guid("26ebd4e2-d903-46c3-8646-04291e7997e7")]
    [ComVisible(true)]
    public interface IManageFingerprint
    {
        /// <summary>
        /// The capture fingerprint.
        /// </summary>
        /// <returns>
        /// The <see cref="ResultFingerprint"/>.
        /// </returns>
        ResultFingerprint CaptureFingerprint();

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
        bool MatchFingerprint(string firstsFmd, string secondFmd);
    }
}