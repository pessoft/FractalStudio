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
    public partial class MandelbrotWindow : Form, IWindowModal
    {
        private IGroupCreate _groupCrt;
        private EventHandler<CreateMandelbrotEventArgs> _create;


        public MandelbrotWindow(EventHandler<CreateMandelbrotEventArgs> create)
        {
            InitializeComponent();

            _create = create;
        }

        private void BtnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TxtFzKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isLexem(e))
                e.Handled = true;
            else

            if (txtFz.Text.Length != 0 && txtFz.Text != placeholderMandelbrot.GetPlaceholder(txtFz))
                btnOk.Enabled = true;
            else
                btnOk.Enabled = false;
        }

        private void ParserSyntax(KeyEventArgs e)
        {
            char chr = (char)e.KeyCode;
            switch (chr)
            {
                case 'P': txtFz.AppendText("ow(z,2)"); break;
                case 'I': txtFz.AppendText("(0,0)"); break;
                case 'Z':
                    if (txtFz.TextLength > 1 && txtFz.Text[txtFz.TextLength - 2] == 'z')
                    {
                        txtFz.Select(txtFz.TextLength - 1, 1);
                        txtFz.Cut();

                    }
                    break;
                case (char)Keys.OemPeriod:
                    if (txtFz.TextLength > 1 && (txtFz.Text[txtFz.TextLength - 2] == '.' || txtFz.Text[txtFz.TextLength - 2] == ','))
                    {
                        txtFz.Select(txtFz.TextLength - 1, 1);
                        txtFz.Cut();

                    }
                    break;
                case (char)Keys.Oemcomma:

                    if (txtFz.TextLength > 1 && (txtFz.Text[txtFz.TextLength - 2] == '.' || txtFz.Text[txtFz.TextLength - 2] == ','))
                    {
                        txtFz.Select(txtFz.TextLength - 1, 1);
                        txtFz.Cut();

                    }
                    break;
            }
        }

        private bool isLexem(KeyPressEventArgs e)
        {
            bool result = false;

            if (char.IsDigit(e.KeyChar)
                || "zi()+-*/p,.".IndexOf(e.KeyChar) != -1
                || char.IsControl(e.KeyChar))
            {
                result = true;
            }

            return result;
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            //this.Hide();
            _groupCrt.ContainerGroup.Controls.Clear();
            _groupCrt.ContainerGroup.Text = this.Text;
            panelJulia.Controls.Remove(btnCancel);
            panelJulia.Location = new System.Drawing.Point(6, panelJulia.Location.Y);
            btnOk.Left = btnCancel.Left;
            _groupCrt.ContainerGroup.Controls.Add(panelJulia);

            var args = new CreateMandelbrotEventArgs
            {
                ComplexFunction = txtFz.Text,
                Xmin = Convert.ToDouble(numericUpDownXmin.Value),
                Xmax = Convert.ToDouble(numericUpDownXmax.Value),
                Ymin = Convert.ToDouble(numericUpDownYmin.Value),
                Ymax = Convert.ToDouble(numericUpDownYmax.Value),
                Iteration = Convert.ToInt32(numericUpDownIteration.Value),
                NoName = Convert.ToInt32(numericUpDownNoName.Value),
                Fill = radioButtonFill.Checked
            };

            _create(this, args);
            this.Close();

        }

        public DialogResult ShowDialog(IGroupCreate owner)
        {
            _groupCrt = owner;
            return this.ShowDialog();
        }

        private void TxtFzLeave(object sender, EventArgs e)
        {
            if (txtFz.Text.Length != 0 && txtFz.Text != placeholderMandelbrot.GetPlaceholder(txtFz))
                btnOk.Enabled = true;
            else
                btnOk.Enabled = false;
        }

        private void TxtFzTextChanged(object sender, EventArgs e)
        {

            if (txtFz.Text.Length != 0 && txtFz.Text != placeholderMandelbrot.GetPlaceholder(txtFz))
                btnOk.Enabled = true;
            else
                btnOk.Enabled = false;
        }

        private void txtFz_KeyUp(object sender, KeyEventArgs e)
        {

            ParserSyntax(e);
        }
    }
}
