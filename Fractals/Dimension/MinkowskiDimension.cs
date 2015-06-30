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
    public class MinkowskiDimension : Dimension
    {
        //#region Поля и события класса

        //List<CompletedDimensionData> _result;
        //List<string> _fileNames;
        //int _startSize, _finishSize, _step;
        //int _min, _max, _value;
        //string file;
        //Bitmap _bwContour;

        //public event EventHandler<ChangedImageEventAgrs> ChangedImage;
        //public event EventHandler<CompletedDimensionArgs> Completed;
        //public event EventHandler Starting;
        //public event EventHandler<ChangedProgressEventArgs> ChangedProgress;

        //#endregion

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
       
        protected override void Run()
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

                ++_value;
                OnChangedProgress();

                string mink;
                int lastSymb;
                string name;

                Dictionary<double, double> baList = ReceiveData(_bwContour);
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
                mink = OrdinaryLeastSquares(x, y);
                lastSymb = imgPath.LastIndexOf(@"\") + 1;
                name = imgPath.Substring(lastSymb, imgPath.Length - lastSymb);

                CompletedDimensionData CompletedResult = new CompletedDimensionData() { Dim = mink, PathFile = imgPath, ShortName = name };

                result.Add(CompletedResult);

            }
            _result = result;
            OnCompleted();
            _bwContour.Dispose();
            _bwContour = null;
        }

        #region Получение эксперементальных данных для МНК
        private Dictionary<double, double> ReceiveData(Bitmap img)
        {
            Dictionary<double, double> baList = new Dictionary<double, double>();
            Bitmap bmp = img;//BitmapBinary.ToBlackWhite(img);
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

                //OnChangedProgress();
            }

            return baList;
        }

        //private Dictionary<double, double> ReceiveData(Bitmap img)
        //{
        //    #region

        //    Dictionary<double, double> baList = new Dictionary<double, double>();
        //    Bitmap bmp = BitmapBinary.ToBlackWhite(img);
        //    int height = bmp.Height;
        //    int width = bmp.Width;
        //    bool[,] colorImg = new bool[width, height];
        //    bool[,] filledBoxes;

            
        //    //Получаем датасет цветов изображения для ускорения работы
        //    for (int x = 0; x < width; x++)
        //    {
        //        for (int y = 0; y < height; y++)
        //        {
        //            if (bmp.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())
        //                colorImg[x, y] = true;
        //        }
        //    }
        //    #endregion
        //    //Имитация предела с изменение размера ячейки epsilon
            
        //    for (int epsilon = _startSize; epsilon <= _finishSize; epsilon+=_step)
        //    {
        //        int hCount = height/ epsilon,
        //            wCount = width / epsilon;

        //        int countEpsilon = 0;

        //        filledBoxes = new bool[wCount, hCount];

        //        for (int i = 1; i < wCount; ++i)
        //            for (int j = 1; j < hCount; ++j)
        //            {
        //                for (int x = (i - 1) * epsilon+1 ; x <= i * epsilon; ++x)
        //                {
        //                    for (int y = (j - 1)* epsilon+1 ; y <= j * epsilon; ++y)
        //                    {
        //                        if (colorImg[x, y])
        //                        {
        //                            filledBoxes[i, j] = true;
        //                            break;
        //                        }
        //                    }
        //                    if (filledBoxes[i, j])
        //                        break;
        //                }

        //            }


        //        for (int i = 1; i < filledBoxes.GetLength(0); i++)
        //        {
        //            for (int j = 1; j < filledBoxes.GetLength(1); j++)
        //            {
        //                if (filledBoxes[i, j])
        //                {
        //                    ++countEpsilon;
        //                }
        //            }
        //        }

        //        baList.Add(Math.Log(1d / epsilon), Math.Log(countEpsilon));

        //        //_value = _value + _step >= _finishSize-_startSize ? _value = _finishSize - _startSize : _value + _step;

        //        //OnChangedProgress();
        //    }

        //    return baList;
        //}
  
        #endregion
                
    }
}
