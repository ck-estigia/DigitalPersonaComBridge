// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FingerprintSerializer.cs" company="Op@ SAS">
//   MIT License
// </copyright>
// <summary>
//   The fingerprint serializer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Opa.Poc.Fingerprint.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;

    using DPUruNet;

    /// <summary>
    /// The fingerprint serializer.
    /// </summary>
    internal static class FingerprintSerializer
    {
        /// <summary>
        /// The get fingerprint bitmap.
        /// </summary>
        /// <param name="fivs">
        /// The fivs.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetFingerprintStringBitmap(IList<Fid.Fiv> fivs)
        {
            return fivs.Select(
                fiv => FingerprintSerializer.BitmapToString(
                    FingerprintSerializer.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height))).First();
        }

        /// <summary>
        /// The get fingerprint file.
        /// </summary>
        /// <param name="fivs">
        /// The fivs.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetFingerprintFile(IList<Fid.Fiv> fivs)
        {
            var bitmap = fivs.Select(fiv => FingerprintSerializer.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height)).First();
            var filename = $"{Path.GetTempPath()}{Guid.NewGuid()}.png";
            bitmap.Save(filename, ImageFormat.Png);
            return filename;
        }

        /// <summary>
        /// The get fingerprint bitmap.
        /// </summary>
        /// <param name="fivs">
        /// The fivs.
        /// </param>
        /// <returns>
        /// The <see cref="Bitmap"/>.
        /// </returns>
        public static Bitmap GetFingerprintBitmap(IList<Fid.Fiv> fivs)
        {
            return fivs.Select(fiv => FingerprintSerializer.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height)).First();
        }

        /// <summary>
        /// The create bitmap.
        /// </summary>
        /// <param name="bytes">
        /// The bytes.
        /// </param>
        /// <param name="width">
        /// The width.
        /// </param>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <returns>
        /// The <see cref="Bitmap"/>.
        /// </returns>
        private static Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + (data.Stride * i));
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            return bmp;
        }

        /// <summary>
        /// The bitmap to string.
        /// </summary>
        /// <param name="bitmap">
        /// The bitmap.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string BitmapToString(Bitmap bitmap)
        {
            var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Jpeg);
            byte[] byteImage = stream.ToArray();

            return Convert.ToBase64String(byteImage);
        }
    }
}
