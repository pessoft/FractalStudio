using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Numerics;

namespace Fractals.Fractal
{
    public class Julia : Fractal
    {
        
        bool _fill;
        int _iteration,_noName;
        double _xMin,_xMax,_yMin,_yMax,_dX,_dY;
        Func<Complex, Complex> _calculate;
        Complex z,tmpZ;
        int iter;

        public Julia(ScaleXY scaleXY,int iteration,int noName,bool fill ,Func<Complex,Complex> calculate)
        {
            _fill = fill;
            _iteration = iteration;
            _noName = noName;
            _xMin = scaleXY.xMin;
            _xMax = scaleXY.xMax;
            _yMin = scaleXY.yMin;
            _yMax = scaleXY.yMax;
            _calculate = calculate;
            
        }

        #region methods IFractal
        protected override void Run()
        {
            OnStarting();
            _changedProgressEventArgs = new ChangedProgressEventArgs() { Minimum = 0, Maximum = _width, Value = 0 };
            _bmp = new Bitmap(_width, _height);
            _dX = (_xMax - _xMin) / (_width - 1);
            _dY = (_yMax - _yMin) / (_height - 1);
            //_bmp.SetResolution(600, 600);
            using (var g = Graphics.FromImage(_bmp))
                g.Clear(Color.White);

            Complex ppp = new Complex();
            double p1=0, p2=0;
            for (int width = 0; width < _width; ++width)
            {
                
               // Множество Мандельброта
                //p1 = (0-3.2 * _height / 4 + width) / 200;
                
                for (int height = 0; height < _height; ++height)
                {
                    z = new Complex(_xMin + width * _dX, _yMin + height * _dY);
                    iter = 0;
                    while (iter < _iteration)
                    {
                        ++iter;
                        tmpZ = _calculate(z);
                        z = tmpZ;
                        if (_fill)
                        {
                            if (Math.Pow(z.Magnitude, 2) >= _noName)
                                break;
                        }
                        else
                        {
                            if (Math.Pow(z.Magnitude, 2) == _noName)
                                break;
                        }
                    }

                    #region Множество мандельброта
                    //p2 = (0 - _height / 2 + height) / 200;
                    //ppp = new Complex(_xMin + width * _dX, _yMin + height * _dY);
                    //z = new Complex(0, 0);
                    //iter = 0;
                    //while (iter < _iteration)
                    //{
                    //    ++iter;
                    //    tmpZ = _calculate(z) + ppp;
                    //    z = tmpZ;
                    //    if (_fill)
                    //    {
                    //        if (Math.Pow(z.Magnitude, 2) >= _noName)
                    //            break;
                    //    }
                    //    else
                    //    {
                    //        if (Math.Pow(z.Magnitude, 2) == _noName)
                    //            break;
                    //    }
                    //}
                    #endregion

                    if (_fill)
                    {
                        if (Math.Pow(z.Magnitude, 2) < _noName)
                            _bmp.SetPixel(width, height, Color.Black);
                    }
                    else
                    {
                        if (Math.Pow(z.Magnitude, 2) > _noName)
                            _bmp.SetPixel(width, height, Color.Black);
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

       
    }
}
