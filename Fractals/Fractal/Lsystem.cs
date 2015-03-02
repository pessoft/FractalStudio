using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fractals.Fractal
{
    public class Lsystem : IFractal
    {
        #region Поля и события класса

        StringBuilder _resultSting;
        string _axiom;
        double _initAngle, _angle;
        int _iteration;
        Dictionary<char, string> _rules;
        Bitmap bmpResult;


        public event EventHandler<CompletedFractalEventArgs> Completed;
        public event EventHandler Starting;
        public event EventHandler<ChangedProgressEventArgs> ChangedProgress;
        
        #endregion
        public Lsystem(string axiom, Dictionary<char,string> rules, double initAngle, double angle, int iteration)
        {
            _axiom = axiom;
            _rules = rules;
            _initAngle = initAngle;
            _angle = angle;
            _iteration = iteration;
        }

        public void Start()
        {
            CallStarting();

            CallCompleted();
        }

        private void CallStarting()
        {
            if (Starting != null)
                Starting(this, EventArgs.Empty);
        }

        private void CallCompleted()
        {
            if (Completed != null)
                Completed(this, new CompletedFractalEventArgs { Img = bmpResult });
        }
    }
}
