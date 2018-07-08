namespace Opa.Poc.ComLibrary.DTO
{
    using System;

    public interface INit
    {
        /// <summary>
        /// Gets or sets the nit id.
        /// </summary>
        string NitId { get; set; }

        /// <summary>
        /// Gets or sets the nombre nit.
        /// </summary>
        string NombreNit { get; set; }

        /// <summary>
        /// Gets or sets the tipo identificacion.
        /// </summary>
        string TipoIdentificacion { get; set; }

        /// <summary>
        /// Gets or sets the fecha nacimiento.
        /// </summary>
        DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Gets or sets the sector empresarial.
        /// </summary>
        string SectorEmpresarial { get; set; }
    }
}