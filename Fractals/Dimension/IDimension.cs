using System;

namespace Fractals.Dimension
{
    public interface IDimension :IFractalElements
    {
        event EventHandler<ChangedImageEventAgrs> ChangedImage;
        event EventHandler<CompletedDimensionArgs> Completed;
    }
}
