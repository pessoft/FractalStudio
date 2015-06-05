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
        protected int _width = 640, _height = 640;


        #region event IFtactal

        public event EventHandler<ChangedProgressEventArgs> ChangedProgress;
        public event EventHandler<CompletedFractalEventArgs> Completed;
        public event EventHandler Starting;

        #endregion

        /// <summary>
        /// Устанавливает размер изображения.
        /// </summary>
        /// <param name="width">Ширина изображения.</param>
        /// <param name="height">Высота изображения.</param>
        public void SetSize(int width, int height)
        {
            _width = width;
            _height = height;
        }

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
