// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BitmapInfo.cs" company="Op@ SAS">
//   MIT License
// </copyright>
// <summary>
//   The bitmap info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Opa.Poc.ComLibrary.DTO
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// The bitmap info.
    /// </summary>
    [Guid("8a6ea9b8-f247-42f7-8ddf-45c2c6893ba9")]
    [ComVisible(true)]
    public class BitmapInfo
    {
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the horizontal pixel resolution.
        /// </summary>
        public float HorizontalPixelResolution { get; set; }

        /// <summary>
        /// Gets or sets the vertical pixel resolution.
        /// </summary>
        public float VerticalPixelResolution { get; set; }
    }
}
