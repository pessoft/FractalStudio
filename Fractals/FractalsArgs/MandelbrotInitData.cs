﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Fractals
{
    public class MandelbrotInitData
    {
        public Func<Complex, Complex> ComplexFunction
        { get; set; }

        public ScaleXY xyScale
        { get; set; }

        public bool Fill
        { get; set; }

        public int Iteration { get; set; }
        public int NoName { get; set; }
    }
}
