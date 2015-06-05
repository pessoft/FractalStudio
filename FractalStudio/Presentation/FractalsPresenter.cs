using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Fractals;
using Fractals.Dimension;
using Fractals.Fractal;
using System.Numerics;

namespace FractalStudio.Presentation
{
    public class FractalsPresenter
    {
        private IView _view;
        private IFractalsSource _fractalSource;
        private IFractalElements _fractalElements;
        private IDimension _dimension;
        private IFractal _fractal;
        private Thread thk;
        private ComplexParser.ComplexParser _complexParser;
        public FractalsPresenter(IView view, IFractalsSource fractalsSource)
        {
            _view = view;
            _fractalSource = fractalsSource;

            _view.ChangeSizeImg += ViewChangeSizeImg;
            _view.CreateMinkowskiDimesion += ViewCreateMinkowskiDimesion;
            _view.CreateJulia += ViewCreateJulia;
            _view.CreateMandelbrot += ViewCreateMandelbrot;
            _view.CreateCorrelationDimesion += ViewCreateCorrelationDimesion;
            _view.CreateLsystem += ViewCreateLsystem;
            _view.Start += ViewStart;
            _view.Stop += ViewStop;
        }

        private void ViewChangeSizeImg(object sender, ImgSizeEventArgs e)
        {
            if (_fractal != null)
                _fractal.SetSize(e.Width, e.Height);
        }

        private void ViewCreateLsystem(object sender, CreateLsystemEventArgs e)
        {
            var initData = new LsysInitData()
            {
                Axiom = e.Axioma,
                Rules = e.Rules,
                InitAngle = e.InitAngle,
                Angle = e.Angle,
                Iteration = e.Iteration
            };

            _fractal = _fractalSource.GetFractal(initData);

            AddEventsFractal();
        }

        private void ViewCreateCorrelationDimesion(object sender, CreateCorrelationEventArgs e)
        {
            var initData = new CorrelationInitData()
            {
                FileNames = e.FileNames,
                StartSize = e.StartSize,
                FinishSize = e.FinishSize,
                Step = e.Step
            };

            _dimension = _fractalSource.GetDimension(initData);

            AddEventsDimension();
        }

        private void ViewCreateMandelbrot(object sender, CreateMandelbrotEventArgs e)
        {
            _complexParser = new ComplexParser.ComplexParser(e.ComplexFunction);
            var scaleXY = new ScaleXY();
            scaleXY.xMin = e.Xmin;
            scaleXY.xMax = e.Xmax;
            scaleXY.yMin = e.Ymin;
            scaleXY.yMax = e.Ymax;
            var initData = new MandelbrotInitData()
            { xyScale = scaleXY, ComplexFunction = _complexParser.Calculate, Iteration = e.Iteration, NoName = e.NoName, Fill = e.Fill };
            _fractal = _fractalSource.GetFractal(initData);
            AddEventsFractal();
        }

        private void ViewCreateJulia(object sender, CreateJuliaEventArgs e)
        {
            _complexParser = new ComplexParser.ComplexParser(e.ComplexFunction);
            var scaleXY = new ScaleXY();
            scaleXY.xMin = e.Xmin;
            scaleXY.xMax = e.Xmax;
            scaleXY.yMin = e.Ymin;
            scaleXY.yMax = e.Ymax;
            var initData = new JuliaInitData()
            { xyScale = scaleXY, ComplexFunction = _complexParser.Calculate,Iteration = e.Iteration,NoName=e.NoName, Fill = e.Fill };
            _fractal = _fractalSource.GetFractal(initData);
            AddEventsFractal();
        }

        private void ViewStop(object sender, EventArgs e)
        {
            if (thk != null && thk.IsAlive)
                thk.Abort();
        }

        private void ViewStart(object sender, EventArgs e)
        {
            thk = new Thread(_fractalElements.Start);

            thk.Start();
        }

        private void ViewCreateMinkowskiDimesion(object sender, CreateMinkowskiEventArgs e)
        {
            var initData = new MinkowskiInitData()
            {
                FileNames = e.FileNames,
                StartSize = e.StartSize,
                FinishSize = e.FinishSize,
                Step = e.Step
            };

            _dimension = _fractalSource.GetDimension(initData);

            AddEventsDimension();
        }
        private void AddEventsDimension()
        {
            _dimension.ChangedProgress += DimensionChangedProgress;
            _dimension.ChangedImage += DimensionChangedImage;
            _dimension.Completed += DimensionCompleted;
            _fractalElements = _dimension;
        }

        private void AddEventsFractal()
        {
            _fractal.ChangedProgress += FractalChangedProgress;
            _fractal.Completed += FractalCompleted;        
            _fractalElements = _fractal;
        }

        private void FractalCompleted(object sender, CompletedFractalEventArgs e)
        {
            _view.ChangedImage(e.Img);
            _view.ResetState();
        }

        private void FractalChangedProgress(object sender, ChangedProgressEventArgs e)
        {
            _view.ChangedProgress(e.Minimum, e.Maximum, e.Value);
        }

        private void DimensionCompleted(object sender, CompletedDimensionArgs e)
        {
            

            Dictionary<string, string> fileName = e.Result.ToDictionary(result => result.ShortName, result => result.PathFile);
            
            Dictionary<string, string> minkDimension = e.Result.ToDictionary(result => result.ShortName, result => result.Dim.ToString());
            
            _view.ResultDimension(fileName, minkDimension);

            _view.ResetState();
        }

        private void DimensionChangedImage(object sender, ChangedImageEventAgrs e)
        {
            _view.ChangedImage(e.Img);
        }

        private void DimensionChangedProgress(object sender, ChangedProgressEventArgs e)
        {
            _view.ChangedProgress(e.Minimum, e.Maximum, e.Value);
        }
    }
}
