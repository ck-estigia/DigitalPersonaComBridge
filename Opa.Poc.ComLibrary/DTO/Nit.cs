// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Nit.cs" company="Op@ SAS">
//   MIT License
// </copyright>
// <summary>
//   The nit.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Opa.Poc.ComLibrary.DTO
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The nit.
    /// </summary>
    [Guid("2a5d23e5-9566-49a3-952a-5453e31e542d")]
    [ComVisible(true)]
    [ProgId("Opa.Poc.Com.Interop.Nit")]
    public class Nit : INit
    {
        /// <summary>
        /// Gets or sets the nit id.
        /// </summary>
        public string NitId { get; set; }

        /// <summary>
        /// Gets or sets the nombre nit.
        /// </summary>
        public string NombreNit { get; set; }

        /// <summary>
        /// Gets or sets the tipo identificacion.
        /// </summary>
        public string TipoIdentificacion { get; set; }

        /// <summary>
        /// Gets or sets the fecha nacimiento.
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Gets or sets the sector empresarial.
        /// </summary>
        public string SectorEmpresarial { get; set; }
    }
}
