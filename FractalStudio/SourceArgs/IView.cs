using System;
using System.Drawing;
using System.Collections.Generic;

namespace FractalStudio
{
    public interface IView
    {
        #region Event
        event EventHandler<CreateLsystemEventArgs> CreateLsystem;
        event EventHandler<CreateJuliaEventArgs> CreateJulia;
        event EventHandler<CreateMinkowskiEventArgs> CreateMinkowskiDimesion;
        event EventHandler<CreateCorrelationEventArgs> CreateCorrelationDimesion;
        event EventHandler<CreateMandelbrotEventArgs> CreateMandelbrot;
        event EventHandler<ImgSizeEventArgs> ChangeSizeImg;
        event EventHandler Start;
        event EventHandler Stop;
        #endregion

        #region Methods

        void ResultDimension(Dictionary<string, string> file, Dictionary<string, string> minkDimension);
        void ChangedProgress(int min, int max, int value);
        void ChangedImage(string fileName);
        void ChangedImage(Bitmap image);
        void ResetState();
        #endregion
    }
}
