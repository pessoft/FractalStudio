using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalStudio
{
    public class CreateCorrelationEventArgs : EventArgs
    {
        public int Step { get; set; } = 1;
        public int FinishSize
        { get; set; }
        public int StartSize
        { get; set; }
        public List<string> FileNames
        { get; set; }


    }
}
