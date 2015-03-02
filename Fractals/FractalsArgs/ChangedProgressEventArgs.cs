using System;

namespace Fractals
{
    public class ChangedProgressEventArgs : EventArgs
    {
        public int Minimum
        { get; set; }
        public int Maximum
        { get; set; }
        public int Value
        { get; set; }
    }
}
