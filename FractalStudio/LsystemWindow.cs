using System;
using System.Windows.Forms;


namespace FractalStudio
{
    public partial class LsystemWindow : Form, IWindowModal
    {
        CreateLsystemEventArgs _LsysArg;
        EventHandler<CreateLsystemEventArgs> _Create;
        IGroupCreate _groupCrt;

        public LsystemWindow(EventHandler<CreateLsystemEventArgs> create)
        {
            InitializeComponent();
           
            _Create = create;
        }

        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOkClick(object sender, EventArgs e)
        {
            _groupCrt.ContainerGroup.Controls.Clear();
            _groupCrt.ContainerGroup.Text = this.Text;
            panelLsystem.Controls.Remove(btnCancel);
            btnOk.Left = btnCancel.Left;
            
            _groupCrt.ContainerGroup.Controls.Add(panelLsystem);

            _LsysArg = new CreateLsystemEventArgs();
            _LsysArg.Angle = Convert.ToInt32(numericUpDownAngle.Value);
            _LsysArg.InitAngle = Convert.ToInt32(numericUpDownInitAngle.Value);
            _LsysArg.Axioma = txtAxiom.Text;
            
            _Create(this, _LsysArg);
            this.Close();
        }


        public DialogResult ShowDialog(IGroupCreate owner)
        {
            _groupCrt = owner;
            return this.ShowDialog();
        }
    }
}
