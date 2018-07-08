// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IManageImage.cs" company="Op@ SAS">
//   MIT License
// </copyright>
// <summary>
//   The ManageImage interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Opa.Poc.ComLibrary
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.InteropServices;

    using Opa.Poc.ComLibrary.DTO;

    /// <summary>
    /// The ManageImage interface.
    /// </summary>
    [Guid("7f0af108-6724-4135-888f-770d993bea6d")]
    [ComVisible(true)]
    public interface IManageImage
    {
        /// <summary>
        /// The get nit.
        /// </summary>
        /// <param name="nit">
        /// The nit.
        /// </param>
        /// <returns>
        /// The <see cref="Nit"/>.
        /// </returns>
        Nit GetNit(Nit nit);
    }
}