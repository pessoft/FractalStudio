using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fractals
{
    public class CompletedFractalEventArgs :EventArgs
    {
        public Bitmap Img
        { get; set; }
    }
}
