using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Numerics;

namespace Fractals.Fractal
{
    public class Julia : IFractal
    {
        Bitmap _bmp;
        bool _fill;
        int _height, _width, _iteration,_noName;
        double _xMin,_xMax,_yMin,_yMax,_dX,_dY;
        Func<Complex, Complex> _calculate;
        ChangedProgressEventArgs _changedProgressEventArgs;
        Complex z,tmpZ;
        int iter;

        public Julia(ScaleXY scaleXY,int iteration,int noName,bool fill ,Func<Complex,Complex> calculate)
        {
            _fill = fill;
            _height = 480;
            _width = 640;
            _iteration = iteration;
            _noName = noName;
            _changedProgressEventArgs = new ChangedProgressEventArgs() { Minimum =0, Maximum = _width, Value = 0};
            _bmp = new Bitmap(_width, _height);
            _bmp.SetResolution(600, 600);
            using (var g = Graphics.FromImage(_bmp))
                g.Clear(Color.White);

                _xMin = scaleXY.xMin;
            _xMax = scaleXY.xMax;
            _yMin = scaleXY.yMin;
            _yMax = scaleXY.yMax;
            _calculate = calculate;
            _dX = (_xMax - _xMin) / (_width - 1);
            _dY = (_yMax - _yMin) / (_height - 1);
        }

        #region event IFtactal
        public event EventHandler<ChangedProgressEventArgs> ChangedProgress;
        public event EventHandler<CompletedFractalEventArgs> Completed;
        public event EventHandler Starting;
        #endregion

        #region methods IFractal
        public void Start()
        {
            OnStarting();
            for (int width = 0; width < _width; ++width)
            {
                for (int height = 0; height < _height; ++height)
                {
                    z = new Complex(_xMin+width*_dX, _yMin+height*_dY);
                    iter = 0;
                    while (iter < _iteration)
                    {
                        ++iter;
                        tmpZ = _calculate(z);
                        z = tmpZ;
                        if (_fill)
                        {
                            if (Math.Pow(z.Magnitude, 2) >= _noName)
                                iter = _iteration;
                        }
                        else
                        {
                            if (Math.Pow(z.Magnitude, 2) == _noName)
                                iter = _iteration;
                        }
                    }
                    if (_fill)
                    {
                        if (Math.Pow(z.Magnitude, 2) < _noName)
                        {
                            _bmp.SetPixel(width, height, Color.Black);
                        }
                    }
                    else
                    {
                        if (Math.Pow(z.Magnitude, 2) > _noName)
                        {
                            _bmp.SetPixel(width, height, Color.Black);
                        }
                    }
                   
                }

                ++_changedProgressEventArgs.Value;
                if (_width-width==1)
                    _changedProgressEventArgs.Value=0;
                OnChangedProgress();
            }
            OnCompleted();
        }
        #endregion

        #region event Methods
        protected void OnChangedProgress()
        {
            if (ChangedProgress != null)
                ChangedProgress(this, _changedProgressEventArgs);
        }

        protected void OnCompleted()
        {
            if (Completed != null)
                Completed(this, new CompletedFractalEventArgs() { Img = _bmp });
        }

        protected void OnStarting()
        {
            if (Starting != null)
                Starting(this, EventArgs.Empty);
        }
        #endregion
    }
}
