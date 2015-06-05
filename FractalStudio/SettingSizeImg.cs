using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalStudio
{
    public partial class SettingSizeImg : Form, IWindowModal
    {
        EventHandler<ImgSizeEventArgs> _changedSize;
        public SettingSizeImg(EventHandler<ImgSizeEventArgs> changedSize, int width, int height)
        {
            InitializeComponent();

            _changedSize = changedSize;
            numericWidth.Value = width;
            numericHeight.Value = height;

            btnOk.Click += BtnOkClick;
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            _changedSize(this, new ImgSizeEventArgs() { Width = (int)numericWidth.Value, Height = (int)numericHeight.Value });
            this.Close();    
        }

        public DialogResult ShowDialog(IGroupCreate owner)
        {
            return ShowDialog();
        }
    }
}
