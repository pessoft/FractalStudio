using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fractals.Dimension
{
    public abstract class Dimension:IDimension
    {
        #region Поля и события класса

        protected List<CompletedDimensionData> _result;
        protected List<string> _fileNames;
        protected int _startSize, _finishSize, _step;
        protected int _min, _max, _value;
        protected string file;
        protected Bitmap _bwContour;
        
        public event EventHandler<ChangedImageEventAgrs> ChangedImage;
        public event EventHandler<CompletedDimensionArgs> Completed;
        public event EventHandler Starting;
        public event EventHandler<ChangedProgressEventArgs> ChangedProgress;

        #endregion

        /// <summary>
        /// Вычесление МНК для линейной функции
        /// </summary>
        /// <param name="x">Набор эксперентальных данных</param>
        /// <param name="y">Набор эксперентальных данных</param>
        /// <returns></returns>
        protected string OrdinaryLeastSquares(double[] x, double[] y)
        {
            double k = 0, sk = 0, b = 0;
            double sumXY = 0, sumX = 0, sumY = 0, sumSqrX = 0, sqrSumX = 0;
            int n = x.Length;
            sumX = x.Sum();
            sumY = y.Sum();
            sqrSumX = sumX * sumX;
            for (int i = 0; i < x.Length; ++i)
            {
                sumXY += x[i] * y[i];
                sumSqrX += x[i] * x[i];
            }

            k = (n * sumXY - sumX * sumY) / (n * sumSqrX - sqrSumX);
            b = (sumY - k * sumX) / n;
            Console.WriteLine("n={0}", n);
            double ndiv123 = 1f / (n - 1), f = 0;
            Console.WriteLine("ndiv={0}", ndiv123);
            for (int i = 0; i < x.Length; ++i)
            {
                f += Math.Pow(y[i] - k * x[i], 2);
            }
           
            sk = Math.Sqrt(ndiv123 * (f / sqrSumX));
           
            return string.Format("{0} {1} {2}", Math.Round(k, 2), (char)0177, Math.Round(sk, 2));
        }

        #region Инкупсуляция вызовов событий

        protected void OnStarting()
        {
            if (Starting != null)
                Starting(this, EventArgs.Empty);
        }
        protected void OnCompleted()
        {
            if (Completed != null)
                Completed(this, new CompletedDimensionArgs { Result = _result });
        }
        protected void OnChangedImage(string file)
        {
            if (ChangedImage != null)
                ChangedImage(this, new ChangedImageEventAgrs { Img = file });
        }
        protected void OnChangedProgress()
        {
            if (ChangedProgress != null)
                ChangedProgress(this, new ChangedProgressEventArgs { Minimum = _min, Maximum = _max, Value = _value });
        }


        public void Start()
        {
            Run();
        }

        protected abstract void Run();

        #endregion
    }
}
