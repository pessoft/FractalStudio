using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalStudio
{
    public class CreateMinkowskiEventArgs :EventArgs
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
