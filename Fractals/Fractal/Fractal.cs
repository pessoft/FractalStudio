using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Fractals.Fractal
{
    public abstract class Fractal : IFractal
    {
        protected Bitmap _bmp;
        protected ChangedProgressEventArgs _changedProgressEventArgs;

        #region event IFtactal

        public event EventHandler<ChangedProgressEventArgs> ChangedProgress;
        public event EventHandler<CompletedFractalEventArgs> Completed;
        public event EventHandler Starting;
        
        #endregion

        public void Start()
        {
            Run();
        }

        protected abstract void Run();

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
