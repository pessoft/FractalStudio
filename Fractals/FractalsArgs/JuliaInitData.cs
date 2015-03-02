using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractals
{
    public class JuliaInitData
    {
        public string ComplexFunction
        { get; set; }

        public double Xmin
        { get; set; }

        public double Xmax
        { get; set; }

        public double Ymin
        { get; set; }

        public double Ymax
        { get; set; }

        public int Iteration{ get; set; } = 20;
    }
}
