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
    public partial class CorrelationWindow : Form, IWindowModal
    {


        private IGroupCreate _groupCrt;
        private EventHandler<CreateCorrelationEventArgs> _create;
        private List<string> _filePaths;
        public CorrelationWindow(EventHandler<CreateCorrelationEventArgs> create)
        {
            InitializeComponent();
            
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
                _filePaths = openFileDialogImgDimension.FileNames.ToList();
                btnOk.Enabled = true;
            }

        }

        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOkClick(object sender, EventArgs e)
        {
            var args = new CreateCorrelationEventArgs()
            {
                StartSize = Convert.ToInt32(numericUpDownMin.Value),
                FinishSize = Convert.ToInt32(numericUpDownMax.Value),
                Step = Convert.ToInt32(numericUpDownStep.Value),
                FileNames = _filePaths
            };

            _create(this, args);

            _groupCrt.ContainerGroup.Controls.Clear();

            btnOk.Left = btnCancel.Left;
            panelMinkowskiDimension.Controls.Remove(btnCancel);

            _groupCrt.ContainerGroup.Controls.Add(panelMinkowskiDimension);
            _groupCrt.ContainerGroup.Text = this.Text;

            this.Close();
        }

    }
}
