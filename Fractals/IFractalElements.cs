using System;

namespace Fractals
{
    public interface IFractalElements
    {
        void Start();

        event EventHandler Starting;
        event EventHandler<ChangedProgressEventArgs> ChangedProgress;

    }
}
