using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fractals.Tools
{
    public static class BitmapBinary
    {
        public static Bitmap ToBlackWhite(Bitmap src)
        {
            // 1.
            double treshold = 0.6;

            // 2.
            //int treshold = 150;
            int size = src.Width > src.Height ? src.Width : src.Height;
            Bitmap dst = new Bitmap(size, size);
            using (var g = Graphics.FromImage(dst))
            {
                g.Clear(Color.White);
            }

                for (int i = 0; i < src.Width; i++)
                {
                    for (int j = 0; j < src.Height; j++)
                    {
                        // 1.
                        if(src.GetPixel(i, j).GetBrightness() < treshold)
                            dst.SetPixel(i, j, Color.Black);

                        // 2 (пактически тоже, что 1).
                        //System.Drawing.Color color = src.GetPixel(i, j);
                        //int average = (int)(color.R + color.B + color.G) / 3;
                        //dst.SetPixel(i, j, average < treshold ? System.Drawing.Color.Black : System.Drawing.Color.White);
                    }
                }

            return dst;
        }
    }
}
