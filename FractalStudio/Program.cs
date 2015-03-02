using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FractalStudio.Presentation;
using Fractals;

namespace FractalStudio
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainWindow = new MainWindow();
            var fractals = new FractalsSource();

            var presenter = new FractalsPresenter(mainWindow, fractals);

            Application.Run(mainWindow);
        }
    }
}
