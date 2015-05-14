using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fractals.Tools
{
    public class Matrix
    {
        /// <summary>
        /// Конструирует обхект Matriix аффинных преобразований.
        /// </summary>
        /// <param name="points">Набор точек над которыми буду проводиться преобразования</param>
        public Matrix(PointF[] points)
        { }

        /// <summary>
        /// Перенос объекта.
        /// </summary>
        /// <param name="dx">Велечина x, на которую смещается объект.</param>
        /// <param name="dy">Велечина y, на которую смещается объект.</param>
        public void Transform(double dx, double dy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Маштабирование объекта.
        /// </summary>
        /// <param name="sx">Коэффициент изменения масштаба объекта вдоль оси Х.</param>
        /// <param name="sy">Коэффициент изменения масштаба объекта вдоль оси Y.</param>
        public void Scale(double sx, double sy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Поворот объекта по часовой стрелке вокруг начала координат на указанный угол.
        /// </summary>
        /// <param name="angle">Угол поворота в градусах.</param>
        public void Rotate(double angle)
        {
            throw new NotImplementedException();
        }
    }
}
