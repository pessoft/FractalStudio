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

        public IFractal GetFractal(JuliaInitData fractalInit)
        {
            throw new NotImplementedException();
        }

        public IFractal GetFractal(LsysInitData fractalInit)
        {
            throw new NotImplementedException();
        }
    }
}
