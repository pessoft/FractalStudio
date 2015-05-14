using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Fractals.Tools;
using System.Numerics;
namespace Fractals.Dimension
{
    public class CorrelationDimension : IDimension
    {
        #region Поля и события класса

        List<CompletedDimensionData> _result;
        List<string> _fileNames;
        int _startSize, _finishSize, _step;
        int _min, _max, _value;
        string file;
        Bitmap _bwContour;

        public event EventHandler<ChangedImageEventAgrs> ChangedImage;
        public event EventHandler<CompletedDimensionArgs> Completed;
        public event EventHandler Starting;
        public event EventHandler<ChangedProgressEventArgs> ChangedProgress;

        #endregion

        /// <summary>
        /// Создает экземпляр класс Корреляционной размерности
        /// </summary>
        /// <param name="fileNames">Коллекция адресов изображений</param>
        /// <param name="startSize">Начальный размер сетик</param>
        /// <param name="finishSize">Конечный размер сетки</param>
        /// <param name="step">Шаг изменения сетки</param>
        public CorrelationDimension(List<string> fileNames, int startSize, int finishSize, int step = 1)
        {
            _fileNames = fileNames;
            _startSize = startSize;
            _finishSize = finishSize;
            _step = step;
            _min = 0;
            _max = fileNames.Count;
        }

        public void Start()
        {
            OnStarting();
            List<CompletedDimensionData> result = new List<CompletedDimensionData>();

            _value = 0;
            foreach (var imgPath in _fileNames)
            {
                _bwContour = new Bitmap(imgPath)/*BitmapBinary.ToBlackWhite(new Bitmap(imgPath))*/;
                _finishSize = Math.Min(_bwContour.Height, _bwContour.Width);
                _finishSize = _finishSize / 10;

                OnChangedImage(imgPath);

                

                double correlation;
                int lastSymb;
                string name;

                Dictionary<double, double> baList = CountingDimension3(_bwContour);
                double[] y = new double[baList.Count];
                double[] x = new double[baList.Count];

                int c = 0;
                foreach (double key in baList.Keys)
                {
                    y[c] = baList[key];
                    x[c] = key;
                    c++;
                }

                correlation = OrdinaryLeastSquares(x, y);
                lastSymb = imgPath.LastIndexOf(@"\") + 1;
                name = imgPath.Substring(lastSymb, imgPath.Length - lastSymb);

                CompletedDimensionData CompletedResult = new CompletedDimensionData() { Dim = Math.Round(correlation, 2), PathFile = imgPath, ShortName = name };

                result.Add(CompletedResult);

            }
            _result = result;
            OnCompleted();
            _bwContour.Dispose();
            _bwContour = null;
        }

        private int Heaviside(double value)
        {
            return value < 0 ? 0 : 1;
        }

        #region Нахождение корреляционноый размерности методом наименьших квадратов
        private Dictionary<double, double> CountingDimension(Bitmap img)
        {
            Dictionary<double, double> baList = new Dictionary<double, double>();
            Bitmap bmp = BitmapBinary.ToBlackWhite(img);
            int height = img.Height;
            int width = img.Width;
            bool[,] colorImg = new bool[width, height];
            List<Point> points;
            bool[,] filledBoxes;

            points = new List<Point>();
            //Получаем датасет цветов изображения для ускорения работы
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (img.GetPixel(x, y).ToArgb() != Color.White.ToArgb())
                    {
                        colorImg[x, y] = true;
                        points.Add(new Point(x, y));
                    }
                }
            }



            int sum = 0; double ttt = 0;int count = points.Count;
            //Имитация предела с изменение размера ячейки epsilon
            for (int epsilon = 5; epsilon <=100; epsilon += _step)
            {
                sum = 0;

                foreach (var point in points.AsParallel())
                {
                    sum+=points.AsParallel().Count(p => inSet(p, point, epsilon));
                }

                //foreach (var pointI in points)
                //{
                //    foreach (var pointJ in points)
                //    {
                //        if (pointI != pointJ)
                //        {
                //            ttt = Math.Sqrt(Math.Pow(pointJ.X - pointI.X, 2) + Math.Pow(pointJ.Y - pointI.Y, 2));
                //            sum += Heaviside(epsilon - ttt);
                //        }
                //    }
                //}
                ++_value;
                OnChangedProgress();
                baList.Add(Math.Log(epsilon), Math.Log(1/Math.Pow(points.Count,2) *sum));
                
                //_value = _value + _step >= _finishSize-_startSize ? _value = _finishSize - _startSize : _value + _step;

                //OnChangedProgress();
            }

            return baList;
        }

        private Dictionary<double, double> CountingDimension2(Bitmap img)
        {
            Dictionary<double, double> baList = new Dictionary<double, double>();
            Bitmap bmp = BitmapBinary.ToBlackWhite(img);
            int height = img.Height;
            int width = img.Width;
            bool[,] colorImg = new bool[width, height];
            List<Point> points;
            bool[,] filledBoxes;
            bool flagFor = false;
            points = new List<Point>();
            //Получаем датасет цветов изображения для ускорения работы
            Dictionary<Point, int> countIteration = new Dictionary<Point, int>();
            
                
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (img.GetPixel(x, y).ToArgb() != Color.White.ToArgb())
                    {
                        colorImg[x, y] = true;
                        Point point = new Point(x, y);
                        points.Add(point);
                        countIteration.Add(point, 0);
                    }
                }
            }


            int sum = 0; double ttt = 0; int count = points.Count;
            int countInRadius=0;int iStart = 0, jStart = 0, iEnd = 0, jEnd = 0;
            List<Point> tmpPoints;

           
            int jS=0,jE = 0,iS=0,iE=0;
            
            double eDSqr = 0;
            //Имитация предела с изменение размера ячейки epsilon
            for (int epsilon = 5; epsilon <= 100; epsilon += _step)
            {
                sum = 0;
                points.AsParallel().ForAll(point =>
                // for(int ind=0;ind<points.Count;++ind)
                {
                    // Point point = points[ind];
                    countInRadius = 0;
                    eDSqr = epsilon / Math.Sqrt(2);
                    iStart = point.X - epsilon < 0 ? 0 : point.X - epsilon;
                    jStart = point.Y - epsilon < 0 ? 0 : point.Y - epsilon;
                    iEnd = point.X + epsilon > width - 1 ? width - 1 : point.X + epsilon;
                    jEnd = point.Y + epsilon > height - 1 ? height - 1 : point.Y + epsilon;
                    // tmpPoints = new List<Point>();
                    iS = (int)(point.X - eDSqr) + 1;
                    iE = (int)(point.X + eDSqr) - 1;
                    jS = (int)(point.Y - eDSqr) + 1;
                    jE = (int)(point.Y + eDSqr) - 1;

                    for (int i = iStart; i <= iEnd; ++i)
                    {
                        for (int j = jStart; j <= jEnd; ++j)
                        {
                            if (flagFor && ((j > jS && j < jE) && (i > iS && i < iE)))
                            {
                                j = jE;
                                continue;
                            }

                            if (colorImg[i, j])
                            {
                                if ((new Point(i, j) != point) && (!flagFor || !inSet(i, j, point, epsilon - _step)) && inSet(i, j, point, epsilon))
                                {
                                    ++countInRadius;
                                }
                            }
                        }
                    }


                    countIteration[point] = countInRadius + countIteration[point];
                    sum += countIteration[point];
                    //sum += countInRadius;

                });

                ++_value;
                OnChangedProgress();
                baList.Add(Math.Log(epsilon), Math.Log(1 / Math.Pow(count, 2) * sum));
                flagFor = true;
            }

            return baList;
        }

        private Dictionary<double, double> CountingDimension3(Bitmap img)
        {
            Dictionary<double, double> baList = new Dictionary<double, double>();
            Dictionary<Point, ulong> countList;
            int countPoint;
            Bitmap bmp = BitmapBinary.ToBlackWhite(img);
            int height = img.Height;
            int width = img.Width;
            bool[,] colorImg = new bool[width, height];
            List<Point> points;
            bool[,] filledBoxes;
            bool flagFor = false;
            points = new List<Point>();
            //Получаем датасет цветов изображения для ускорения работы
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (img.GetPixel(x, y).ToArgb() != Color.White.ToArgb())
                    {
                        colorImg[x, y] = true;
                        points.Add(new Point(x, y));
                    }
                }
            }

            ulong sum = 0; int count = points.Count;
            //Имитация предела с изменение размера ячейки epsilon
            for (int epsilon = 5; epsilon <= 100; epsilon += _step)
            {
                countList = new Dictionary<Point, ulong>();
                int hCount = height / epsilon,
                    wCount = width / epsilon;
                sum = 0;
                int countEpsilon = 0;
                countPoint = 0;
                filledBoxes = new bool[wCount + (img.Width > wCount * epsilon ? 1 : 0), hCount + (img.Height > hCount * epsilon ? 1 : 0)];

                for (int x = 0; x < width; ++x)
                    for (int y = 0; y < height; ++y)
                    {
                        if (colorImg[x, y])
                        {
                            int xBox = x / (epsilon);
                            int yBox = y / (epsilon);

                            if (countList.ContainsKey(new Point(xBox, yBox)))
                            {
                                ++countList[new Point(xBox, yBox)];
                            }
                            else
                            {
                                countList.Add(new Point(xBox, yBox), 1);
                            }
                        }
                    }


                //for (int i = 0; i < filledBoxes.GetLength(0); i++)
                //{
                //    for (int j = 0; j < filledBoxes.GetLength(1); j++)
                //    {
                //        if (filledBoxes[i, j])
                //        {
                //            ++countEpsilon;
                //        }
                //    }
                //}

                ++_value;
                OnChangedProgress();
                foreach (var i in countList.Values)
                {
                    //sum += (ulong)(((BigInteger)(i + 1)).Factorial() / (2 * (((BigInteger)(i - 1)).Factorial())));
                    sum += (ulong)(i*(i-1));
                }
                
                baList.Add(Math.Log(epsilon), Math.Log(1 / Math.Pow(count, 2) * sum));

                //_value = _value + _step >= _finishSize-_startSize ? _value = _finishSize - _startSize : _value + _step;

                //OnChangedProgress();
            }

            return baList;
        }

        private Dictionary<double, double> CountingDimension4(Bitmap img)
        {
            Dictionary<double, double> baList = new Dictionary<double, double>();
            Bitmap bmp = BitmapBinary.ToBlackWhite(img);
            int height = img.Height;
            int width = img.Width;
            bool[,] colorImg = new bool[width, height];
            List<Point> points;
            bool[,] filledBoxes;
            bool flagFor = false;
            points = new List<Point>();
            //Получаем датасет цветов изображения для ускорения работы
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (img.GetPixel(x, y).ToArgb() != Color.White.ToArgb())
                    {
                        colorImg[x, y] = true;
                        points.Add(new Point(x, y));
                    }
                }
            }


            int sum = 0; double ttt = 0; int count = points.Count;
            int countInRadius = 0; int iStart = 0, jStart = 0, iEnd = 0, jEnd = 0;
            List<Point> tmpPoints;

            Dictionary<Point, int> countIteration = new Dictionary<Point, int>();
            foreach (var point in points)
                countIteration.Add(point, 0);
            int jS = 0, jE = 0, iS = 0, iE = 0;

            double eDSqr = 0;
            //Имитация предела с изменение размера ячейки epsilon
            for (int epsilon = 5; epsilon <= 100; epsilon += _step)
            {
                sum = 0;

                foreach (var point in points.AsParallel())
                {
                    sum += points.AsParallel().Count(p=>inSet(p,point,epsilon));
                }
               
                ++_value;
                OnChangedProgress();
                baList.Add(Math.Log(epsilon), Math.Log(1 / Math.Pow(count, 2) * sum));
                flagFor = true;
            }

            return baList;
        }
        private bool inSet(int i, int j,Point point, int radius)
        {
            return Math.Pow(i - point.X, 2) + Math.Pow(j - point.Y, 2) <= Math.Pow(radius, 2);
        }

        private bool inSet(Point point1, Point point2, int radius)
        {
            return Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2) <= Math.Pow(radius, 2);
        }

        //private double NormalEquations2d(double[] x, double[] y)
        //{
        //    //x^t * x
        //    double[,] xtx = new double[2, 2];
        //    for (int i = 0; i < x.Length; i++)
        //    {
        //        xtx[0, 1] += x[i];
        //        xtx[0, 0] += x[i] * x[i];
        //    }
        //    xtx[1, 0] = xtx[0, 1];
        //    xtx[1, 1] = x.Length;

        //    //inverse
        //    double[,] xtxInv = new double[2, 2];
        //    double d = 1 / (xtx[0, 0] * xtx[1, 1] - xtx[1, 0] * xtx[0, 1]);
        //    xtxInv[0, 0] = xtx[1, 1] * d;
        //    xtxInv[0, 1] = -xtx[0, 1] * d;
        //    xtxInv[1, 0] = -xtx[1, 0] * d;
        //    xtxInv[1, 1] = xtx[0, 0] * d;

        //    //times x^t
        //    double[,] xtxInvxt = new double[2, x.Length];
        //    for (int i = 0; i < 2; i++)
        //    {
        //        for (int j = 0; j < x.Length; j++)
        //        {
        //            xtxInvxt[i, j] = xtxInv[i, 0] * x[j] + xtxInv[i, 1];
        //        }
        //    }

        //    //times y
        //    double[] theta = new double[2];
        //    for (int i = 0; i < 2; i++)
        //    {
        //        for (int j = 0; j < x.Length; j++)
        //        {
        //            theta[i] += xtxInvxt[i, j] * y[j];
        //        }
        //    }

        //    return Math.Round(theta[0], 3);
        //}

        /// <summary>
        /// Вычесление МНК для линейной функции
        /// </summary>
        /// <param name="x">Набор эксперентальных данных</param>
        /// <param name="y">Набор эксперентальных данных</param>
        /// <returns></returns>
        private double OrdinaryLeastSquares(double[] x, double[] y)
        {
            double k = 0;
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

            return k;
        }

        #endregion


        #region Инкупсуляция вызовов событий

        private void OnStarting()
        {
            if (Starting != null)
                Starting(this, EventArgs.Empty);
        }
        private void OnCompleted()
        {
            if (Completed != null)
                Completed(this, new CompletedDimensionArgs { Result = _result });
        }
        private void OnChangedImage(string file)
        {
            if (ChangedImage != null)
                ChangedImage(this, new ChangedImageEventAgrs { Img = file });
        }
        private void OnChangedProgress()
        {
            //if (ChangedProgress != null)
            //    ChangedProgress(this, new ChangedProgressEventArgs { Minimum = _min, Maximum = _max, Value = _value });
            if (ChangedProgress != null)
                ChangedProgress(this, new ChangedProgressEventArgs { Minimum = _min, Maximum = 101, Value = _value });
            // ChangedProgress(this, new ChangedProgressEventArgs { Minimum = _min, Maximum = _max, Value = _value });
        }


        #endregion
    }
}
