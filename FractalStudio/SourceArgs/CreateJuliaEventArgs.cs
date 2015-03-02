using System;

namespace FractalStudio
{
    public class CreateJuliaEventArgs :EventArgs
    {
        public string ComplexFunction
        { get;set; }

        public double Xmin
        { get; set; }

        public double Xmax
        { get; set; }

        public double Ymin
        { get; set; }

        public double Ymax
        { get; set; }
    }
}
