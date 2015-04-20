using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace Fractals
{
    public class JuliaInitData
    {
        public Func<Complex,Complex> ComplexFunction
        { get; set; }

        public ScaleXY xyScale
        { get; set; }


        public int Iteration{ get; set; } = 20;
        public int NoName { get; set; } = 4;
    }
}
