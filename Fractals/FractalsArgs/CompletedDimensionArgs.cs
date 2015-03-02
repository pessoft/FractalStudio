using System;
using System.Collections.Generic;
using Fractals.Dimension;
namespace Fractals
{
    public class CompletedDimensionArgs : EventArgs
    {
        public List<CompletedDimensionData> Result
        { get; set; }
        
    }
}
