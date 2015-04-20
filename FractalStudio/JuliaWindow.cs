using System;
using System.Windows.Forms;

namespace FractalStudio
{
    public partial class JuliaWindow : Form,IWindowModal
    {

        private IGroupCreate _groupCrt;
        private EventHandler<CreateJuliaEventArgs> _create;
        public JuliaWindow(EventHandler<CreateJuliaEventArgs> create)
        {
            InitializeComponent();

            _create = create;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtFz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isLexem(e))
                e.Handled = true;
            if (txtFz.Text.Length != 0 && txtFz.Text != placeholderJulia.GetPlaceholder(txtFz))
                btnOk.Enabled = true;
            else
                btnOk.Enabled = false;
        }

        private bool isLexem(KeyPressEventArgs e)
        {
            bool result = false;

            if (char.IsDigit(e.KeyChar) 
                ||"zi()+-*/pow,.".IndexOf(e.KeyChar) != -1
                ||char.IsControl(e.KeyChar))
            {
                result = true;
            }

            return result;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
            _groupCrt.ContainerGroup.Controls.Clear();
            _groupCrt.ContainerGroup.Text = this.Text;
            panelJulia.Controls.Remove(btnCancel);
            panelJulia.Location = new System.Drawing.Point(6,panelJulia.Location.Y);
            //btnOk.Left = btnCancel.Left;
            _groupCrt.ContainerGroup.Controls.Add(panelJulia);

            var args = new CreateJuliaEventArgs
            {
                ComplexFunction = txtFz.Text,
                Xmin = Convert.ToDouble(numericUpDownXmin.Value),
                Xmax = Convert.ToDouble(numericUpDownXmax.Value),
                Ymin = Convert.ToDouble(numericUpDownYmin.Value),
                Ymax = Convert.ToDouble(numericUpDownYmax.Value),
                Iteration = Convert.ToInt32(numericUpDownIteration.Value)
            };

            _create(this, args);
            this.Close();

        }

        public DialogResult ShowDialog(IGroupCreate owner)
        {
            _groupCrt = owner;
            return this.ShowDialog();
        }

        private void txtFz_Leave(object sender, EventArgs e)
        {
            if (txtFz.Text.Length != 0 && txtFz.Text != placeholderJulia.GetPlaceholder(txtFz))
                btnOk.Enabled = true;
            else
                btnOk.Enabled = false;
        }
    }
}
