using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractals
{
    public class LsysInitData
    {
        public string Axiom
        { get; set; }

        public Dictionary<char, string> Rules
        { get; set; }

        public int InitAngle
        { get; set; }

        public int Angle
        { get; set; }

        public int Iteration
        { get; set; }
    }
}
