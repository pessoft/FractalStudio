using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FractalStudio
{
    public partial class MainWindow : Form, IGroupCreate, IView
    {

        #region Поля и события класса

        private IWindowModal _windowModal;

        public event EventHandler<CreateLsystemEventArgs> CreateLsystem;
        public event EventHandler<CreateJuliaEventArgs> CreateJulia;
        public event EventHandler<CreateMinkowskiEventArgs> CreateMinkowskiDimesion;

        public event EventHandler Start;
        public event EventHandler Stop;
        

        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Получтает или устанавливает содержание GroupBox
        /// </summary>
        public GroupBox ContainerGroup
        {
            get
            {
                return groupBoxCreate;
            }
            set
            {
                groupBoxCreate = value;
            }
        }

        #region IView
        /// <summary>
        /// Изменение прогресса
        /// </summary>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <param name="value">Текущее значение</param>
        public void ChangedProgress(int min, int max, int value)
        {
            Action method =  new Action(
                                        () =>
                                         {
                                             toolStripProgressBar.Minimum = min;
                                             toolStripProgressBar.Maximum = max;
                                             toolStripProgressBar.Value = value;
                                         }
                                        );

            InvokeMethod(method);
        }

        /// <summary>
        /// Устанавливает новое изображение
        /// </summary>
        /// <param name="fileName">Путь к изображению</param>
        public void ChangedImage(string fileName)
        {
            Action method = new Action(() =>
            {
                if (pictureBoxResult.Image != null)
                    pictureBoxResult.Image = null;
                pictureBoxResult.ImageLocation = fileName;
            });

            InvokeMethod(method);
        }

        /// <summary>
        /// Устанавливает новое изображение
        /// </summary>
        /// <param name="image">Новое изображение</param>
        public void ChangedImage(Bitmap image)
        {
            Action method = new Action(() =>
            {
                if (pictureBoxResult.Image != null)
                    pictureBoxResult.Image = null;
                pictureBoxResult.Image = image;
            });

            InvokeMethod(method);
        }

        /// <summary>
        /// Сброс в исходное состояние
        /// </summary>
        public void ResetState()
        {
            Action method = new Action(
                () =>
                {
                    if (_windowModal == null)
                        btnStart.Enabled = false;
                    else
                        btnStart.Enabled = true;
                    btnStop.Enabled = false;

                    toolStripProgressBar.Minimum = 0;
                    toolStripProgressBar.Value = 0;

                    foreach (Control control in groupBoxCreate.Controls[0].Controls)
                    {
                        if (control is Button)
                            ((Button)control).Enabled = true;
                    }
                });

            InvokeMethod(method);
        }

        #endregion

        /// <summary>
        /// Обеспечивает потокобезопасное выполнение метода
        /// </summary>
        /// <param name="method">Метод которому нужно обеспечить потокобезопасное выполнение</param>
        private void InvokeMethod(Action method)
        {
            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }


        private Dictionary<string, string> _dimensionResultFile;
        private Dictionary<string, double> _dimensionResult;
        public void ResultDimension(Dictionary<string,string> file, Dictionary<string,double> minkDimension)
        {
            Action method = new Action(
                    ()=>
                    {
                        _dimensionResultFile = file;
                        _dimensionResult = minkDimension;

                        GroupBox resultDimension = new GroupBox();

                        resultDimension.Text = "Размерность";
                        resultDimension.ForeColor = groupBoxCreate.ForeColor;
                        resultDimension.Top = groupBoxCreate.Controls[0].Location.Y + groupBoxCreate.Controls[0].Height;
                        resultDimension.Left = groupBoxCreate.Controls[0].Left;
                        resultDimension.Width = groupBoxCreate.Controls[0].Width;
                        resultDimension.Height = groupBoxCreate.Height - resultDimension.Top - groupBoxCreate.Margin.Bottom - 5;
                        resultDimension.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;


                        ListView listViewResult = new ListView();
                        listViewResult.View = View.Details;
                        listViewResult.Dock = DockStyle.Fill;
                        listViewResult.FullRowSelect = true;
                        listViewResult.HeaderStyle = ColumnHeaderStyle.Nonclickable;
                        listViewResult.BackColor = SystemColors.Window;
                        listViewResult.BorderStyle = BorderStyle.Fixed3D;
                        listViewResult.Columns.Add("Имя файла").AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        listViewResult.Columns.Add("Размерность").AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        listViewResult.Sorting = SortOrder.Ascending;
                        listViewResult.ItemSelectionChanged += ListViewResultItemSelectionChanged;

                        List<ListViewItem> rangeItems = new List<ListViewItem>();

                        foreach (var key in file.Keys)
                        {
                            rangeItems.Add(new ListViewItem(new string[] { key, minkDimension[key].ToString() }));
                        }

                        listViewResult.Items.AddRange(rangeItems.ToArray());

                        resultDimension.Controls.Add(listViewResult);

                        groupBoxCreate.Controls.Add(resultDimension);
                    }
                    );

            InvokeMethod(method);
            
        }

        private void ListViewResultItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                ChangedImage(_dimensionResultFile[e.Item.Text]);
        }

        #region Проброс событий главного и модальных оконо

        private void WindowShowFractal(object sender, EventArgs e)
        {
            if (btnStop.Enabled)
            {
                MessageBox.Show("Остановите текущую операцию","Фракталы", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            ToolStripMenuItem menuItemFractal = sender as ToolStripMenuItem;

            int tag = Convert.ToInt32(menuItemFractal.Tag);

            switch (tag)
            {
                case 0: _windowModal = new LsystemWindow(CreateLsys); break;
                case 1: _windowModal = null; break;
                case 2: _windowModal = new JuliaWindow(CreateJuliaSet); break;
                case 3: MessageBox.Show("3"); break;
            }

            if (_windowModal != null)
                _windowModal.ShowDialog(this);
        }

        private void WindowShowDimension(object sender, EventArgs e)
        {
            if (btnStop.Enabled)
            {
                MessageBox.Show("Остановите текущую операцию", "Фракталы", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            ToolStripMenuItem menuItemFractal = sender as ToolStripMenuItem;

            int tag = Convert.ToInt32(menuItemFractal.Tag);

            switch (tag)
            {
                case 0: _windowModal = new MinkowskiWindow(CreateMinkowski); break;
                case 1: _windowModal =null; break;
                case 2: _windowModal = null; break;
                case 3: MessageBox.Show("3"); break;
            }

            if (_windowModal != null)
                _windowModal.ShowDialog(this);
        }
        private void CreateLsys(object sender, CreateLsystemEventArgs e)
        {
            btnStart.Enabled = true;

            if (CreateLsystem != null)
                CreateLsystem(this, e);
        }

        private void CreateJuliaSet(object sender, CreateJuliaEventArgs e)
        {
            btnStart.Enabled = true;

            if (CreateJulia != null)
                CreateJulia(this, e);
        }

        private void CreateMinkowski(object sender, CreateMinkowskiEventArgs e)
        {
            btnStart.Enabled = true;

            if (CreateMinkowskiDimesion != null)
                CreateMinkowskiDimesion(this, e);

        }


        private void btnStartClick(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            foreach (Control control in groupBoxCreate.Controls[0].Controls)
            {
                if (control is Button)
                    ((Button)control).Enabled = false;
            }

            if (Start != null)
                Start(this, EventArgs.Empty);
        }

        private void btnStopClick(object sender, EventArgs e)
        {
            if (Stop != null)
                Stop(this, EventArgs.Empty);

            ResetState();
        }

        #endregion

        private void MainWindowFormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindosStop();
        }

        private void CloseAppMenu_Click(object sender, EventArgs e)
        {
            MainWindosStop();
            Close();
        }

        private void MainWindosStop()
        {
            if (Stop != null)
                Stop(this, EventArgs.Empty);
        }

        private void SaveAsMenuClick(object sender, EventArgs e)
        {
            if (saveFileDialogImg.ShowDialog() == DialogResult.OK)
            {
                
                    pictureBoxResult.Image.Save(saveFileDialogImg.FileName);

            }
        }

       }
}
