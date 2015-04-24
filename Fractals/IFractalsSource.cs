using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fractals.Dimension;
using Fractals.Fractal;

namespace Fractals
{
    public interface IFractalsSource
    {
        #region Fractal
        
        /// <summary>
        /// Запрашивает интерфейс работы с L-системами
        /// </summary>
        /// <param name="fractalInit">Исходные данные</param>
        /// <returns>Возвращает интерфейс работы с фракталом</returns>
        IFractal GetFractal(LsysInitData fractalInit);
       
        /// <summary>
        /// Запрашивает интерфейс работы с множеством Жюлиа
        /// </summary>
        /// <param name="fractalInit">Исходные данные</param>
        /// <returns>Возвращает интерфейс работы с фракталом</returns>
        IFractal GetFractal(JuliaInitData fractalInit);
        IFractal GetFractal(MandelbrotInitData fractalInit);
        #endregion

        #region Dimension

        /// <summary>
        /// Запрашивает интерфейс работы с размерностью Минковского
        /// </summary>
        /// <param name="dimensionInit">Исходные данные</param>
        /// <returns>Возвращает интерфейс работы с размерностью Минковского</returns>
        IDimension GetDimension(MinkowskiInitData dimensionInit);

        #endregion
    }
}
