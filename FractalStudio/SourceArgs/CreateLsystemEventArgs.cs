using System;
using System.Collections.Generic;

namespace FractalStudio
{
    public class CreateLsystemEventArgs :EventArgs
    {
        public int InitAngle
        { get; set; }

        public int Angle
        { get; set; }

        public string Axioma
        { get; set; }

        public Dictionary<char, string> Rules
        { get; set; }
    }
}
