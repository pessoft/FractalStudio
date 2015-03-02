namespace FractalStudio
{
    partial class MinkowskiWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinkowskiWindow));
            this.groupBoxMinkowskiDimension = new System.Windows.Forms.GroupBox();
            this.pictureShortHelp = new System.Windows.Forms.PictureBox();
            this.panelMinkowskiDimension = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SizeEpsilon = new System.Windows.Forms.GroupBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblStep = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.numericUpDownStep = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMin = new System.Windows.Forms.NumericUpDown();
            this.toolTipShortHepl = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSizeEpsilon = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialogImgDimension = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxMinkowskiDimension.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShortHelp)).BeginInit();
            this.panelMinkowskiDimension.SuspendLayout();
            this.SizeEpsilon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMinkowskiDimension
            // 
            this.groupBoxMinkowskiDimension.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBoxMinkowskiDimension.Controls.Add(this.pictureShortHelp);
            this.groupBoxMinkowskiDimension.Controls.Add(this.panelMinkowskiDimension);
            this.groupBoxMinkowskiDimension.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxMinkowskiDimension.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxMinkowskiDimension.ForeColor = System.Drawing.SystemColors.Info;
            this.groupBoxMinkowskiDimension.Location = new System.Drawing.Point(13, 10);
            this.groupBoxMinkowskiDimension.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxMinkowskiDimension.Name = "groupBoxMinkowskiDimension";
            this.groupBoxMinkowskiDimension.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxMinkowskiDimension.Size = new System.Drawing.Size(273, 165);
            this.groupBoxMinkowskiDimension.TabIndex = 0;
            this.groupBoxMinkowskiDimension.TabStop = false;
            this.groupBoxMinkowskiDimension.Text = "Конструктор";
            // 
            // pictureShortHelp
            // 
            this.pictureShortHelp.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureShortHelp.Image = ((System.Drawing.Image)(resources.GetObject("pictureShortHelp.Image")));
            this.pictureShortHelp.Location = new System.Drawing.Point(235, 26);
            this.pictureShortHelp.Name = "pictureShortHelp";
            this.pictureShortHelp.Size = new System.Drawing.Size(31, 31);
            this.pictureShortHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureShortHelp.TabIndex = 3;
            this.pictureShortHelp.TabStop = false;
            this.toolTipShortHepl.SetToolTip(this.pictureShortHelp, resources.GetString("pictureShortHelp.ToolTip"));
            // 
            // panelMinkowskiDimension
            // 
            this.panelMinkowskiDimension.Controls.Add(this.btnCancel);
            this.panelMinkowskiDimension.Controls.Add(this.btnOk);
            this.panelMinkowskiDimension.Controls.Add(this.SizeEpsilon);
            this.panelMinkowskiDimension.Location = new System.Drawing.Point(7, 26);
            this.panelMinkowskiDimension.Name = "panelMinkowskiDimension";
            this.panelMinkowskiDimension.Size = new System.Drawing.Size(227, 136);
            this.panelMinkowskiDimension.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCancel.Location = new System.Drawing.Point(125, 99);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancelClick);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.Window;
            this.btnOk.Enabled = false;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnOk.Location = new System.Drawing.Point(3, 99);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(94, 29);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // SizeEpsilon
            // 
            this.SizeEpsilon.Controls.Add(this.btnOpen);
            this.SizeEpsilon.Controls.Add(this.lblStep);
            this.SizeEpsilon.Controls.Add(this.lblMax);
            this.SizeEpsilon.Controls.Add(this.lblMin);
            this.SizeEpsilon.Controls.Add(this.numericUpDownStep);
            this.SizeEpsilon.Controls.Add(this.numericUpDownMax);
            this.SizeEpsilon.Controls.Add(this.numericUpDownMin);
            this.SizeEpsilon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SizeEpsilon.ForeColor = System.Drawing.SystemColors.Info;
            this.SizeEpsilon.Location = new System.Drawing.Point(3, 3);
            this.SizeEpsilon.Name = "SizeEpsilon";
            this.SizeEpsilon.Size = new System.Drawing.Size(216, 90);
            this.SizeEpsilon.TabIndex = 0;
            this.SizeEpsilon.TabStop = false;
            this.SizeEpsilon.Text = "Размер сетки";
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.SystemColors.Window;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpen.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnOpen.Location = new System.Drawing.Point(145, 51);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(59, 26);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "...";
            this.toolTipSizeEpsilon.SetToolTip(this.btnOpen, "Выберети одно или несколько изображений, \r\nпо которым нужно расчитать размерность" +
        "");
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpenClick);
            // 
            // lblStep
            // 
            this.lblStep.AutoSize = true;
            this.lblStep.Location = new System.Drawing.Point(6, 53);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(31, 17);
            this.lblStep.TabIndex = 5;
            this.lblStep.Text = "шаг";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(109, 22);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(24, 17);
            this.lblMax.TabIndex = 4;
            this.lblMax.Text = "до";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(8, 22);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(22, 17);
            this.lblMin.TabIndex = 3;
            this.lblMin.Text = "от";
            // 
            // numericUpDownStep
            // 
            this.numericUpDownStep.Location = new System.Drawing.Point(44, 51);
            this.numericUpDownStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownStep.Name = "numericUpDownStep";
            this.numericUpDownStep.Size = new System.Drawing.Size(59, 25);
            this.numericUpDownStep.TabIndex = 2;
            this.numericUpDownStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipSizeEpsilon.SetToolTip(this.numericUpDownStep, "Шаг изменения сетки");
            this.numericUpDownStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownMax
            // 
            this.numericUpDownMax.Location = new System.Drawing.Point(145, 20);
            this.numericUpDownMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMax.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownMax.Name = "numericUpDownMax";
            this.numericUpDownMax.Size = new System.Drawing.Size(59, 25);
            this.numericUpDownMax.TabIndex = 1;
            this.numericUpDownMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipSizeEpsilon.SetToolTip(this.numericUpDownMax, "Конечный размер сетки");
            this.numericUpDownMax.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownMin
            // 
            this.numericUpDownMin.Location = new System.Drawing.Point(44, 20);
            this.numericUpDownMin.Name = "numericUpDownMin";
            this.numericUpDownMin.Size = new System.Drawing.Size(59, 25);
            this.numericUpDownMin.TabIndex = 0;
            this.numericUpDownMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipSizeEpsilon.SetToolTip(this.numericUpDownMin, "Начальный размер сетки\r\n");
            this.numericUpDownMin.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // toolTipShortHepl
            // 
            this.toolTipShortHepl.AutoPopDelay = 35000;
            this.toolTipShortHepl.InitialDelay = 100;
            this.toolTipShortHepl.IsBalloon = true;
            this.toolTipShortHepl.ReshowDelay = 100;
            this.toolTipShortHepl.ToolTipTitle = "Размерность Минковского";
            // 
            // toolTipSizeEpsilon
            // 
            this.toolTipSizeEpsilon.AutoPopDelay = 5000;
            this.toolTipSizeEpsilon.InitialDelay = 100;
            this.toolTipSizeEpsilon.IsBalloon = true;
            this.toolTipSizeEpsilon.ReshowDelay = 100;
            this.toolTipSizeEpsilon.ToolTipTitle = "Размер сетки, шаг, изображение";
            // 
            // openFileDialogImgDimension
            // 
            this.openFileDialogImgDimension.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";
            this.openFileDialogImgDimension.Multiselect = true;
            this.openFileDialogImgDimension.Title = "Выбор изображений";
            // 
            // MinkowskiWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(299, 182);
            this.Controls.Add(this.groupBoxMinkowskiDimension);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MinkowskiWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MinkowskoWindow";
            this.groupBoxMinkowskiDimension.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureShortHelp)).EndInit();
            this.panelMinkowskiDimension.ResumeLayout(false);
            this.SizeEpsilon.ResumeLayout(false);
            this.SizeEpsilon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMinkowskiDimension;
        private System.Windows.Forms.Panel panelMinkowskiDimension;
        private System.Windows.Forms.GroupBox SizeEpsilon;
        private System.Windows.Forms.NumericUpDown numericUpDownMin;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.NumericUpDown numericUpDownStep;
        private System.Windows.Forms.NumericUpDown numericUpDownMax;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.PictureBox pictureShortHelp;
        private System.Windows.Forms.ToolTip toolTipShortHepl;
        private System.Windows.Forms.ToolTip toolTipSizeEpsilon;
        private System.Windows.Forms.OpenFileDialog openFileDialogImgDimension;
    }
}