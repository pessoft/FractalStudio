using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fractals.Dimension;
using Fractals.Fractal;

namespace Fractals
{
    public class FractalsSource : IFractalsSource
    {
        public IDimension GetDimension(MinkowskiInitData dimensionInit)
        {
            var dimension = new MinkowskiDimension
                (dimensionInit.FileNames, dimensionInit.StartSize, dimensionInit.FinishSize, dimensionInit.Step);

            return dimension;
        }

        public IDimension GetDimension(CorrelationInitData dimensionInit)
        {
            var dimension = new CorrelationDimension
                (dimensionInit.FileNames, dimensionInit.StartSize, dimensionInit.FinishSize, dimensionInit.Step);

            return dimension;
        }

        public IFractal GetFractal(JuliaInitData fractalInit)
        {
            var julia = new Julia(fractalInit.xyScale, fractalInit.Iteration,fractalInit.NoName,fractalInit.Fill,fractalInit.ComplexFunction);
            
            return julia;
        }

        public IFractal GetFractal(MandelbrotInitData fractalInit)
        {
            var mandelbrot = new Mandelbrot(fractalInit.xyScale, fractalInit.Iteration, fractalInit.NoName, fractalInit.Fill, fractalInit.ComplexFunction);

            return mandelbrot;
        }

        public IFractal GetFractal(LsysInitData fractalInit)
        {
            var lSys = new Lsystem(fractalInit.Axiom, fractalInit.Rules, fractalInit.InitAngle, fractalInit.Angle, fractalInit.Iteration);
            return lSys;
        }
    }
}
