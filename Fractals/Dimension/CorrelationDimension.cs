using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Fractals.Tools;
using System.Numerics;
namespace Fractals.Dimension
{
    public class CorrelationDimension : Dimension
    {
       

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

        protected override  void Run()
        {
            OnStarting();
            List<CompletedDimensionData> result = new List<CompletedDimensionData>();

            
            foreach (var imgPath in _fileNames)
            {
                string correlation;
                int lastSymb, inc = 0;
                string name;
                Dictionary<double, double> baList; 
                double[] y;
                double[] x;



                _value = 0;
                _bwContour = new Bitmap(imgPath)/*BitmapBinary.ToBlackWhite(new Bitmap(imgPath))*/;
                _finishSize = Math.Min(_bwContour.Height, _bwContour.Width);
                _finishSize = _finishSize / 10;

                OnChangedImage(imgPath);

                baList = ReceiveData(_bwContour);
                y = new double[baList.Count];
                x = new double[baList.Count];

                
                
                foreach (double key in baList.Keys)
                {
                    y[inc] = baList[key];
                    x[inc] = key;
                    inc++;
                }

                correlation = OrdinaryLeastSquares(x, y);
                lastSymb = imgPath.LastIndexOf(@"\") + 1;
                name = imgPath.Substring(lastSymb, imgPath.Length - lastSymb);

                CompletedDimensionData CompletedResult = new CompletedDimensionData() { Dim = correlation, PathFile = imgPath, ShortName = name };

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

        #region  Получение эксперементальных данных для МНК
        //private Dictionary<double, double> ReceiveData(Bitmap img)
        //{
        //    Dictionary<double, double> baList = new Dictionary<double, double>();
        //    Bitmap bmp = BitmapBinary.ToBlackWhite(img);
        //    int height = img.Height;
        //    int width = img.Width;
        //    bool[,] colorImg = new bool[width, height];
        //    List<Point> points;
        //    bool[,] filledBoxes;
        //    _max = 100;
        //    points = new List<Point>();
        //    //Получаем датасет цветов изображения для ускорения работы
        //    for (int x = 0; x < width; x++)
        //    {
        //        for (int y = 0; y < height; y++)
        //        {
        //            if (img.GetPixel(x, y).ToArgb() != Color.White.ToArgb())
        //            {
        //                colorImg[x, y] = true;
        //                points.Add(new Point(x, y));
        //            }
        //        }
        //    }



        //    int sum = 0; double ttt = 0; int count = points.Count;
        //    //Имитация предела с изменение размера ячейки epsilon
        //    for (int epsilon = 5; epsilon <= 100; epsilon += _step)
        //    {
        //        sum = 0;

        //        foreach (var point in points.AsParallel())
        //        {
        //            sum += points.AsParallel().Count(p => inSet(p, point, epsilon));
        //        }

        //        //foreach (var pointI in points)
        //        //{
        //        //    foreach (var pointJ in points)
        //        //    {
        //        //        if (pointI != pointJ)
        //        //        {
        //        //            ttt = Math.Sqrt(Math.Pow(pointJ.X - pointI.X, 2) + Math.Pow(pointJ.Y - pointI.Y, 2));
        //        //            sum += Heaviside(epsilon - ttt);
        //        //        }
        //        //    }
        //        //}
        //        ++_value;
        //        OnChangedProgress();
        //        baList.Add(Math.Log(epsilon), Math.Log(1 / Math.Pow(points.Count, 2) * sum));

        //        //_value = _value + _step >= _finishSize-_startSize ? _value = _finishSize - _startSize : _value + _step;

        //        //OnChangedProgress();
        //    }

        //    return baList;
        //}

        private Dictionary<double, double> ReceiveData(Bitmap img)
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
            _max = 100;

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
            int countInRadius = 0; int iStart = 0, jStart = 0, iEnd = 0, jEnd = 0;
            List<Point> tmpPoints;


            int jS = 0, jE = 0, iS = 0, iE = 0;

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

        private bool inSet(int i, int j,Point point, int radius)
        {
            return Math.Pow(i - point.X, 2) + Math.Pow(j - point.Y, 2) <= Math.Pow(radius, 2);
        }

        private bool inSet(Point point1, Point point2, int radius)
        {
            return Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2) <= Math.Pow(radius, 2);
        }

        #endregion


      
    }
}
