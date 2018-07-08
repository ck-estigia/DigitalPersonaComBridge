// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManageImage.cs" company="Op@ SAS">
//   MIT License
// </copyright>
// <summary>
//   Defines the ManageImage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Opa.Poc.ComLibrary
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;

    using Opa.Poc.ComLibrary.DTO;

    /// <summary>
    /// The manage image.
    /// </summary>
    [Guid("24f03f3b-3f50-4a9b-8cec-ee659c09edd7")]
    [ComVisible(true)]
    [ComSourceInterfaces(typeof(IEvents))]
    [ProgId("Opa.Poc.ManageImage")]
    public class ManageImage : IManageImage
    {
        public event onChangeNitValues ChangeNitValues;
        public delegate void onChangeNitValues(Nit nit);

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageImage"/> class.
        /// </summary>
        public ManageImage()
        {
        }

        /// <summary>
        /// The get nit.
        /// </summary>
        /// <param name="nit">
        /// The nit.
        /// </param>
        /// <returns>
        /// The <see cref="Nit"/>.
        /// </returns>        
        public Nit GetNit(Nit nit)
        {
            nit.NombreNit += " - Reflected";
            this.ChangeNitValues(nit);
            return nit;
        }
    }
}
