using System;
using System.Collections.Generic;
using System.Drawing;
using Fractals.Tools;
using System.Linq;

namespace Fractals.Dimension
{
    /// <summary>
    /// Размернеость Минковского
    /// </summary>
    public class MinkowskiDimension : IDimension
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
        /// Создает экземпляр класс размерности Минковского
        /// </summary>
        /// <param name="fileNames">Коллекция адресов изображений</param>
        /// <param name="startSize">Начальный размер сетик</param>
        /// <param name="finishSize">Конечный размер сетки</param>
        /// <param name="step">Шаг изменения сетки</param>
        public MinkowskiDimension(List<string> fileNames, int startSize, int finishSize, int step = 1)
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
            CallStarting();
            List<CompletedDimensionData> result = new List<CompletedDimensionData>();

            _value = 0;
            foreach (var imgPath in _fileNames)
            {
                _bwContour = new Bitmap(imgPath)/*BitmapBinary.ToBlackWhite(new Bitmap(imgPath))*/;
                _finishSize = Math.Min(_bwContour.Height, _bwContour.Width);
                _finishSize = _finishSize / 10 ;

                CallChangedImage(imgPath);

                ++_value;
                CallChangedProgress();

                double mink;
                int lastSymb;
                string name;

                Dictionary<double, double> baList = CountingDimension(_bwContour);
                double[] y = new double[baList.Count];
                double[] x = new double[baList.Count];

                int c = 0;
                foreach (double key in baList.Keys)
                {
                    y[c] = baList[key];
                    x[c] = key;
                    c++;
                }

                  //mink = NormalEquations2d(x, y);
                mink = _2NormalEquations2d(x, y);
                lastSymb = imgPath.LastIndexOf(@"\") + 1;
                name = imgPath.Substring(lastSymb, imgPath.Length - lastSymb);

                CompletedDimensionData CompletedResult = new CompletedDimensionData() { Dim = Math.Round(mink,2), PathFile = imgPath, ShortName = name };
                
                result.Add(CompletedResult);
                
           }
            _result = result;
            CallCompleted();
        }

        #region Нахождение размерности Минковского методом наименьших квадратов
        private Dictionary<double, double> CountingDimension(Bitmap img)
        {
            Dictionary<double, double> baList = new Dictionary<double, double>();
            Bitmap bmp = BitmapBinary.ToBlackWhite(img);
            int height = img.Height;
            int width = img.Width;
            bool[,] colorImg = new bool[width, height];
            bool[,] filledBoxes;
            
               
               //Получаем датасет цветов изображения для ускорения работы
               for (int x = 0; x < width; x++)
               {
                   for (int y = 0; y < height; y++)
                   {
                       if (img.GetPixel(x, y).ToArgb() != Color.White.ToArgb())
                           colorImg[x, y] = true;
                   }
               }
               
            //Имитация предела с изменение размера ячейки epsilon
            for (int epsilon = _startSize; epsilon <= _finishSize; epsilon += _step)
            {
                int hCount = img.Height / (epsilon),
                    wCount = img.Width / (epsilon );

                int countEpsilon = 0;

                filledBoxes = new bool[wCount + (img.Width > wCount *epsilon ? 1 : 0), hCount + (img.Height > hCount *epsilon ? 1 : 0)];

                for (int x = 0; x < width; ++x)
                    for (int y = 0; y < height; ++y)
                    {
                        if (colorImg[x, y])
                        {
                            int xBox = x/ (epsilon);
                            int yBox = y / (epsilon);

                            filledBoxes[xBox, yBox] = true;
                        }
                    }


                for (int i = 0; i < filledBoxes.GetLength(0); i++)
                {
                    for (int j = 0; j < filledBoxes.GetLength(1); j++)
                    {
                        if (filledBoxes[i, j])
                        {
                            ++countEpsilon;
                        }
                    }
                }

                baList.Add(Math.Log(1d / epsilon), Math.Log(countEpsilon));

                //_value = _value + _step >= _finishSize-_startSize ? _value = _finishSize - _startSize : _value + _step;

                //CallChangedProgress();
            }

            return baList;
        }

        private Dictionary<double, double> CountingDimension2(Bitmap img)
        {
            #region

            Dictionary<double, double> baList = new Dictionary<double, double>();
            Bitmap bmp = BitmapBinary.ToBlackWhite(img);
            int height = bmp.Height;
            int width = bmp.Width;
            bool[,] colorImg = new bool[width, height];
            bool[,] filledBoxes;

            
            //Получаем датасет цветов изображения для ускорения работы
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (bmp.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())
                        colorImg[x, y] = true;
                }
            }
            #endregion
            //Имитация предела с изменение размера ячейки epsilon
            
            for (int epsilon = _startSize; epsilon <= _finishSize; epsilon+=_step)
            {
                int hCount = height/ epsilon,
                    wCount = width / epsilon;

                int countEpsilon = 0;

                filledBoxes = new bool[wCount, hCount];

                for (int i = 1; i < wCount; ++i)
                    for (int j = 1; j < hCount; ++j)
                    {
                        for (int x = (i - 1) * epsilon+1 ; x <= i * epsilon; ++x)
                        {
                            for (int y = (j - 1)* epsilon+1 ; y <= j * epsilon; ++y)
                            {
                                if (colorImg[x, y])
                                {
                                    filledBoxes[i, j] = true;
                                    break;
                                }
                            }
                            if (filledBoxes[i, j])
                                break;
                        }

                    }


                for (int i = 1; i < filledBoxes.GetLength(0); i++)
                {
                    for (int j = 1; j < filledBoxes.GetLength(1); j++)
                    {
                        if (filledBoxes[i, j])
                        {
                            ++countEpsilon;
                        }
                    }
                }

                baList.Add(Math.Log(1d / epsilon), Math.Log(countEpsilon));

                //_value = _value + _step >= _finishSize-_startSize ? _value = _finishSize - _startSize : _value + _step;

                //CallChangedProgress();
            }

            return baList;
        }

        private double NormalEquations2d(double[] x, double[] y)
        {
            //x^t * x
            double[,] xtx = new double[2, 2];
            for (int i = 0; i < x.Length; i++)
            {
                xtx[0, 1] += x[i];
                xtx[0, 0] += x[i] * x[i];
            }
            xtx[1, 0] = xtx[0, 1];
            xtx[1, 1] = x.Length;

            //inverse
            double[,] xtxInv = new double[2, 2];
            double d = 1 / (xtx[0, 0] * xtx[1, 1] - xtx[1, 0] * xtx[0, 1]);
            xtxInv[0, 0] = xtx[1, 1] * d;
            xtxInv[0, 1] = -xtx[0, 1] * d;
            xtxInv[1, 0] = -xtx[1, 0] * d;
            xtxInv[1, 1] = xtx[0, 0] * d;

            //times x^t
            double[,] xtxInvxt = new double[2, x.Length];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    xtxInvxt[i, j] = xtxInv[i, 0] * x[j] + xtxInv[i, 1];
                }
            }

            //times y
            double[] theta = new double[2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    theta[i] += xtxInvxt[i, j] * y[j];
                }
            }

            return Math.Round(theta[0], 3);
        }

        private double _2NormalEquations2d(double[] x, double[] y)
        {
            double k=0;
            double sumXY = 0, sumX = 0, sumY = 0, sumSqrX = 0, sqrSumX = 0;
            int n = x.Length ;
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

        private void CallStarting()
        {
            if (Starting != null)
                Starting(this, EventArgs.Empty);
        }
        private void CallCompleted()
        {
            if (Completed != null)
                Completed(this, new CompletedDimensionArgs { Result = _result });
        }
        private void CallChangedImage(string file)
        {
            if (ChangedImage != null)
                ChangedImage(this, new ChangedImageEventAgrs { Img = file });
        }
        private void CallChangedProgress()
        {
            if (ChangedProgress != null)
                ChangedProgress(this, new ChangedProgressEventArgs { Minimum = _min, Maximum = _max, Value = _value });
        }


        #endregion
    }
}
