using System;
using System.Drawing;

namespace Fractals.Tools
{
    /// <summary>
    /// Класс аффинных преобразований.
    /// </summary>
    public class Matrix
    {

        double[,] _transformMatrix;
        PointF[] _pointsOld;
        
        /// <summary>
        /// Конструирует обхект Matriix аффинных преобразований.
        /// </summary>
        /// <param name="points">Набор точек над которыми буду проводиться преобразования</param>
        public Matrix(PointF[] points)
        {
            _transformMatrix = new double[,] { {1,0,0},
                                               {0,1,0},
                                               {0,0,1}
                                             };
            _pointsOld = points;
        }

        /// <summary>
        /// Перенос объекта.
        /// </summary>
        /// <param name="dx">Велечина x, на которую смещается объект.</param>
        /// <param name="dy">Велечина y, на которую смещается объект.</param>
        public void Transform(double dx, double dy)
        {
            double[,] transform = new double[,] {{1,0,dx},
                                                 {0,1,dy},
                                                 {0,0,1 }
                                                };
            Multipl(transform);
        }

        /// <summary>
        /// Маштабирование объекта.
        /// </summary>
        /// <param name="sx">Коэффициент изменения масштаба объекта вдоль оси Х.</param>
        /// <param name="sy">Коэффициент изменения масштаба объекта вдоль оси Y.</param>
        public void Scale(double sx, double sy)
        {
            Scale(sx, sy, 0, 0);
        }

        /// <summary>
        /// Маштабирование объекта.
        /// </summary>
        /// <param name="sx">Коэффициент изменения масштаба объекта вдоль оси Х.</param>
        /// <param name="sy">Коэффициент изменения масштаба объекта вдоль оси Y.</param>
        /// <param name="cx">Координата x центрамасс объекта.</param>
        /// <param name="cy">Координата y центрамасс объекта.</param>
        public void Scale(double sx, double sy, double cx, double cy)
        {
            double[,] scale = new double[,] {{sx,0,0},
                                             {0,sy,0},
                                             {0, 0,1}
                                            };

            Transform(-cx, -cy);
            Multipl(scale);
            Transform(cx, cy);
        }

        /// <summary>
        /// Поворот объекта по часовой стрелке вокруг начала координат на указанный угол.
        /// </summary>
        /// <param name="angle">Угол поворота в градусах.</param>
        public void Rotate(double angle)
        {

            Rotate(angle, 0, 0);
        }

        /// <summary>
        /// Поворот объекта по часовой стрелке вокруг начала координат на указанный угол.
        /// </summary>
        /// <param name="angle">Угол поворота в градусах.</param>
        /// <param name="cx">Координата x центрамасс объекта.</param>
        /// <param name="cy">Координата y центрамасс объекта.</param>
        public void Rotate(double angle, double cx, double cy)
        {
            double[,] rotate = new double[,] {{Math.Cos(angle*Math.PI/180),-Math.Sin(angle*Math.PI/180),0},
                                              {Math.Sin(angle*Math.PI/180),Math.Cos(angle*Math.PI/180),0},
                                              {0, 0,1}
                                             };
            Transform(-cx, -cy);
            Multipl(rotate);
            Transform(cx, cy);
        }

        /// <summary>
        /// Перемножение матриц.
        /// </summary>
        /// <param name="matrix">Матрица преобразования.</param>
        private void Multipl(double[,] matrix)
        {
            double sumCol;
            double[,] tmpMatrix = new double[3,3];

            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    sumCol = 0;
                    for (int k = 0; k < 3; ++k)
                    {
                        sumCol += matrix[i, k] * _transformMatrix[k,j];
                    }
                    tmpMatrix[i, j] = sumCol;
                }
            }

            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    _transformMatrix[i, j] = tmpMatrix[i, j];
            
        }
     
        /// <summary>
        /// Возвращает набор точек с преобразованиями.
        /// </summary>
        /// <returns>Массив преобразованных точек.</returns>
        public PointF[] GetPoints()
        {
            PointF[] pointsNew = new PointF[_pointsOld.Length];

            for (int i = 0; i < _pointsOld.Length; ++i)
            {
                PointF oldCoor, newCoor = new PointF();
                oldCoor = _pointsOld[i];
                newCoor.X = (float)Math.Round(oldCoor.X*_transformMatrix[0,0]+oldCoor.Y*_transformMatrix[0,1]+_transformMatrix[0,2]);
                newCoor.Y = (float)Math.Round(oldCoor.X * _transformMatrix[1, 0] + oldCoor.Y * _transformMatrix[1, 1] + _transformMatrix[1, 2]);
                pointsNew[i] = newCoor;
            }

            return pointsNew;
        }
    }
}
