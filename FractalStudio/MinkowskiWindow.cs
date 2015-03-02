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
    public partial class MinkowskiWindow : Form, IWindowModal
    {

        private IGroupCreate _groupCrt;
        private EventHandler<CreateMinkowskiEventArgs> _create;
        private CreateMinkowskiEventArgs args;
        public MinkowskiWindow(EventHandler<CreateMinkowskiEventArgs> create)
        {
            InitializeComponent();
            args = new CreateMinkowskiEventArgs() ;
            _create = create;
        }

        public DialogResult ShowDialog(IGroupCreate owner)
        {
            _groupCrt = owner;

            return this.ShowDialog();
        }

        private void btnOpenClick(object sender, EventArgs e)
        {
            if (openFileDialogImgDimension.ShowDialog() == DialogResult.OK)
            {
                args.FileNames = openFileDialogImgDimension.FileNames.ToList();
                btnOk.Enabled = true;
            }

        }

        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            args.StartSize = Convert.ToInt32(numericUpDownMin.Value);
            args.FinishSize = Convert.ToInt32(numericUpDownMax.Value);
            args.Step = Convert.ToInt32(numericUpDownStep.Value);

            _create(this, args);

            _groupCrt.ContainerGroup.Controls.Clear();

            btnOk.Left = btnCancel.Left;
            panelMinkowskiDimension.Controls.Remove(btnCancel);

            _groupCrt.ContainerGroup.Controls.Add(panelMinkowskiDimension);
            _groupCrt.ContainerGroup.Text = "Размерность Минковского";

            this.Close();
        }
    }
}
