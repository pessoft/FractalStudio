using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Fractals;
using Fractals.Dimension;
using Fractals.Fractal;

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
        public FractalsPresenter(IView view, IFractalsSource fractalsSource)
        {
            _view = view;
            _fractalSource = fractalsSource;

            _view.CreateMinkowskiDimesion += ViewCreateMinkowskiDimesion;
            _view.Start += ViewStart;
            _view.Stop += ViewStop;
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

        private void DimensionCompleted(object sender, CompletedDimensionArgs e)
        {
            

            Dictionary<string, string> fileName = e.Result.ToDictionary(result => result.ShortName, result => result.PathFile);
            
            Dictionary<string, double> minkDimension = e.Result.ToDictionary(result => result.ShortName, result => result.Dim);
            
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
