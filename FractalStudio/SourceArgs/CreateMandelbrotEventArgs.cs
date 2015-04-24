using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalStudio
{
    public class CreateMandelbrotEventArgs :EventArgs
    {
        public string ComplexFunction
        { get; set; }

        public bool Fill
        { get; set; }
        public int Iteration
        { get; set; }

        public int NoName
        { get; set; }

        public double Xmin
        { get; set; }

        public double Xmax
        { get; set; }

        public double Ymin
        { get; set; }

        public double Ymax
        { get; set; }
    }
}
