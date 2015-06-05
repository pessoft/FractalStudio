using System;

namespace Fractals.Fractal
{
    public interface IFractal :IFractalElements
    {
        event EventHandler<CompletedFractalEventArgs> Completed;
        void SetSize(int width, int height);
    }
}
