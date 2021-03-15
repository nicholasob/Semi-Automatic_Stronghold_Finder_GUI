using System;
using System.Drawing;

namespace Stronghold_Finder
{
    class MCImage
    {
        /// <summary>
        /// Cropping the image to chosen size.
        /// </summary>
        /// <param name="source">The image to crop</param>
        /// <param name="x">The X-position to crop from</param>
        /// <param name="y">The Y-position to crop from</param>
        /// <param name="width">Width the cropped image should have</param>
        /// <param name="height">Height the cropped image should have</param>
        /// <param name="percentage">Is the image calculates through percentage or pixels</param>
        /// <returns></returns>
        public static Bitmap CropImage(Image source, Decimal x, Decimal y, Decimal width, Decimal height, bool percentage)
        {
            Rectangle crop;
            if(percentage == true)
            {
                int imageWidth = source.Width;
                int imageHeight = source.Height;

                crop = new Rectangle((int)(imageWidth * x), (int)(imageHeight * y), (int)(imageWidth * width), (int)(imageHeight * height));
            }
            else
            {
                crop = new Rectangle((int)x, (int)y, (int)width, (int)height);
            }

            var bmp = new Bitmap(crop.Width, crop.Height);
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);
            }
            return bmp;
        }

        /// <summary>
        /// Setting the screenshoted image to black and white using passed refference so it is possible for sellenium to read the text.
        /// </summary>
        /// <param name="bitmap">The refference bitmap you want in black and white</param>
        public static void setBlackWhiteImage(ref Bitmap bitmap)
        {
            Bitmap blackWhiteBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color actualColor = bitmap.GetPixel(x, y);
                    if (actualColor.R == 221 && actualColor.G == 221 && actualColor.B == 221)
                    {
                        blackWhiteBitmap.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        blackWhiteBitmap.SetPixel(x, y, Color.White);
                    }
                }
            }
            bitmap = blackWhiteBitmap;
        }
        /// <summary>
        ///  returning a black and white bitmap of the screenshoted image so it is possible for sellenium to read the text.
        /// </summary>
        /// <param name="bitmap">Bitmap you want in black and white</param>
        /// <returns></returns>
        public static Bitmap getBlackWhiteImage(Bitmap bitmap)
        {
            Bitmap blackWhiteBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color actualColor = bitmap.GetPixel(x, y);
                    if (actualColor.R == 221 && actualColor.G == 221 && actualColor.B == 221)
                    {
                        blackWhiteBitmap.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        blackWhiteBitmap.SetPixel(x, y, Color.White);
                    }
                }
            }
            return blackWhiteBitmap;
        }
    }
}
