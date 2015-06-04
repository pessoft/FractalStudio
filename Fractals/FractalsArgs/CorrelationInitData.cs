using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractals
{
    public class CorrelationInitData
    {
        public int Step { get; set; }
        public int FinishSize
        { get; set; }
        public int StartSize
        { get; set; }
        public List<string> FileNames
        { get; set; }
    }
}
