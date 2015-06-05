using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalStudio
{
    public class ImgSizeEventArgs:EventArgs
    {
        /// <summary>
        /// Ширина изображения.
        /// </summary>
        public int Width
        {
            get;
            set;
        }

        /// <summary>
        /// Высота изображения.
        /// </summary>
        public int Height
        {
            get;
            set;
        }
    }
}
