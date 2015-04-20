namespace FractalStudio
{
    partial class JuliaWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JuliaWindow));
            this.groupCreateJulia = new System.Windows.Forms.GroupBox();
            this.panelJulia = new System.Windows.Forms.Panel();
            this.groupBoxFz = new System.Windows.Forms.GroupBox();
            this.txtFz = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownYmax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownYmin = new System.Windows.Forms.NumericUpDown();
            this.groupBoxX = new System.Windows.Forms.GroupBox();
            this.numericUpDownXmax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownXmin = new System.Windows.Forms.NumericUpDown();
            this.pictureShortHelp = new System.Windows.Forms.PictureBox();
            this.toolTipFunc = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipXminMax = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipYminMax = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipShortHelp = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxIteration = new System.Windows.Forms.GroupBox();
            this.numericUpDownIteration = new System.Windows.Forms.NumericUpDown();
            this.placeholderJulia = new FractalStudio.Placeholder();
            this.groupCreateJulia.SuspendLayout();
            this.panelJulia.SuspendLayout();
            this.groupBoxFz.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYmin)).BeginInit();
            this.groupBoxX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShortHelp)).BeginInit();
            this.groupBoxIteration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIteration)).BeginInit();
            this.SuspendLayout();
            // 
            // groupCreateJulia
            // 
            this.groupCreateJulia.Controls.Add(this.panelJulia);
            this.groupCreateJulia.Controls.Add(this.pictureShortHelp);
            this.groupCreateJulia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupCreateJulia.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupCreateJulia.ForeColor = System.Drawing.SystemColors.Info;
            this.groupCreateJulia.Location = new System.Drawing.Point(12, 5);
            this.groupCreateJulia.Name = "groupCreateJulia";
            this.groupCreateJulia.Size = new System.Drawing.Size(324, 259);
            this.groupCreateJulia.TabIndex = 0;
            this.groupCreateJulia.TabStop = false;
            this.groupCreateJulia.Text = "Конструктор";
            // 
            // panelJulia
            // 
            this.panelJulia.Controls.Add(this.groupBoxIteration);
            this.panelJulia.Controls.Add(this.btnOk);
            this.panelJulia.Controls.Add(this.groupBoxFz);
            this.panelJulia.Controls.Add(this.btnCancel);
            this.panelJulia.Controls.Add(this.groupBox1);
            this.panelJulia.Controls.Add(this.groupBoxX);
            this.panelJulia.Location = new System.Drawing.Point(37, 28);
            this.panelJulia.Name = "panelJulia";
            this.panelJulia.Size = new System.Drawing.Size(235, 222);
            this.panelJulia.TabIndex = 7;
            // 
            // groupBoxFz
            // 
            this.groupBoxFz.Controls.Add(this.txtFz);
            this.groupBoxFz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxFz.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxFz.ForeColor = System.Drawing.SystemColors.Info;
            this.groupBoxFz.Location = new System.Drawing.Point(13, 5);
            this.groupBoxFz.Name = "groupBoxFz";
            this.groupBoxFz.Size = new System.Drawing.Size(214, 54);
            this.groupBoxFz.TabIndex = 8;
            this.groupBoxFz.TabStop = false;
            this.groupBoxFz.Text = "f(z)";
            // 
            // txtFz
            // 
            this.txtFz.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFz.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFz.Location = new System.Drawing.Point(19, 23);
            this.txtFz.Name = "txtFz";
            this.placeholderJulia.SetPlaceholder(this.txtFz, "Функция");
            this.txtFz.Size = new System.Drawing.Size(180, 25);
            this.txtFz.TabIndex = 1;
            this.txtFz.Text = "Функция";
            this.toolTipFunc.SetToolTip(this.txtFz, resources.GetString("txtFz.ToolTip"));
            this.txtFz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFz_KeyPress);
            this.txtFz.Leave += new System.EventHandler(this.txtFz_Leave);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCancel.Location = new System.Drawing.Point(132, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.Window;
            this.btnOk.Enabled = false;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnOk.Location = new System.Drawing.Point(132, 185);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(94, 29);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownYmax);
            this.groupBox1.Controls.Add(this.numericUpDownYmin);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.groupBox1.Location = new System.Drawing.Point(133, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 89);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "y";
            // 
            // numericUpDownYmax
            // 
            this.numericUpDownYmax.DecimalPlaces = 1;
            this.numericUpDownYmax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownYmax.Location = new System.Drawing.Point(19, 55);
            this.numericUpDownYmax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownYmax.Name = "numericUpDownYmax";
            this.numericUpDownYmax.Size = new System.Drawing.Size(53, 25);
            this.numericUpDownYmax.TabIndex = 5;
            this.numericUpDownYmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipYminMax.SetToolTip(this.numericUpDownYmax, "Укажите Ymax");
            this.numericUpDownYmax.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDownYmin
            // 
            this.numericUpDownYmin.DecimalPlaces = 1;
            this.numericUpDownYmin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownYmin.Location = new System.Drawing.Point(19, 24);
            this.numericUpDownYmin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownYmin.Name = "numericUpDownYmin";
            this.numericUpDownYmin.Size = new System.Drawing.Size(53, 25);
            this.numericUpDownYmin.TabIndex = 4;
            this.numericUpDownYmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipYminMax.SetToolTip(this.numericUpDownYmin, "Укажите Ymin");
            this.numericUpDownYmin.Value = new decimal(new int[] {
            12,
            0,
            0,
            -2147418112});
            // 
            // groupBoxX
            // 
            this.groupBoxX.Controls.Add(this.numericUpDownXmax);
            this.groupBoxX.Controls.Add(this.numericUpDownXmin);
            this.groupBoxX.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxX.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxX.ForeColor = System.Drawing.SystemColors.Info;
            this.groupBoxX.Location = new System.Drawing.Point(13, 55);
            this.groupBoxX.Name = "groupBoxX";
            this.groupBoxX.Size = new System.Drawing.Size(94, 89);
            this.groupBoxX.TabIndex = 3;
            this.groupBoxX.TabStop = false;
            this.groupBoxX.Text = "x";
            // 
            // numericUpDownXmax
            // 
            this.numericUpDownXmax.DecimalPlaces = 1;
            this.numericUpDownXmax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownXmax.Location = new System.Drawing.Point(19, 55);
            this.numericUpDownXmax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownXmax.Name = "numericUpDownXmax";
            this.numericUpDownXmax.Size = new System.Drawing.Size(53, 25);
            this.numericUpDownXmax.TabIndex = 3;
            this.numericUpDownXmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipXminMax.SetToolTip(this.numericUpDownXmax, "Укажите Xmax");
            this.numericUpDownXmax.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDownXmin
            // 
            this.numericUpDownXmin.DecimalPlaces = 1;
            this.numericUpDownXmin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownXmin.Location = new System.Drawing.Point(19, 24);
            this.numericUpDownXmin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownXmin.Name = "numericUpDownXmin";
            this.numericUpDownXmin.Size = new System.Drawing.Size(53, 25);
            this.numericUpDownXmin.TabIndex = 2;
            this.numericUpDownXmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipXminMax.SetToolTip(this.numericUpDownXmin, "Укажите Xmin");
            this.numericUpDownXmin.Value = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            // 
            // pictureShortHelp
            // 
            this.pictureShortHelp.Image = ((System.Drawing.Image)(resources.GetObject("pictureShortHelp.Image")));
            this.pictureShortHelp.Location = new System.Drawing.Point(287, 28);
            this.pictureShortHelp.Name = "pictureShortHelp";
            this.pictureShortHelp.Size = new System.Drawing.Size(31, 31);
            this.pictureShortHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureShortHelp.TabIndex = 2;
            this.pictureShortHelp.TabStop = false;
            this.toolTipShortHelp.SetToolTip(this.pictureShortHelp, "Для того, что бы построить множество Жюлиа  нужно:\r\n указать функцию f(z)\r\n указа" +
        "ть минимальные и максимальные значения X и Y");
            // 
            // toolTipFunc
            // 
            this.toolTipFunc.AutoPopDelay = 30000;
            this.toolTipFunc.InitialDelay = 100;
            this.toolTipFunc.IsBalloon = true;
            this.toolTipFunc.ReshowDelay = 100;
            this.toolTipFunc.ToolTipTitle = "Функция f(z)";
            // 
            // toolTipXminMax
            // 
            this.toolTipXminMax.AutoPopDelay = 5000;
            this.toolTipXminMax.InitialDelay = 100;
            this.toolTipXminMax.IsBalloon = true;
            this.toolTipXminMax.ReshowDelay = 100;
            this.toolTipXminMax.ToolTipTitle = "Xmin и Xmax";
            // 
            // toolTipYminMax
            // 
            this.toolTipYminMax.AutoPopDelay = 5000;
            this.toolTipYminMax.InitialDelay = 100;
            this.toolTipYminMax.IsBalloon = true;
            this.toolTipYminMax.ReshowDelay = 100;
            this.toolTipYminMax.ToolTipTitle = "Ymin и Ymax";
            // 
            // toolTipShortHelp
            // 
            this.toolTipShortHelp.AutoPopDelay = 15000;
            this.toolTipShortHelp.InitialDelay = 100;
            this.toolTipShortHelp.IsBalloon = true;
            this.toolTipShortHelp.ReshowDelay = 100;
            this.toolTipShortHelp.ToolTipTitle = "Множество Жюлиа";
            // 
            // groupBoxIteration
            // 
            this.groupBoxIteration.Controls.Add(this.numericUpDownIteration);
            this.groupBoxIteration.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxIteration.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxIteration.ForeColor = System.Drawing.SystemColors.Info;
            this.groupBoxIteration.Location = new System.Drawing.Point(13, 150);
            this.groupBoxIteration.Name = "groupBoxIteration";
            this.groupBoxIteration.Size = new System.Drawing.Size(94, 64);
            this.groupBoxIteration.TabIndex = 9;
            this.groupBoxIteration.TabStop = false;
            this.groupBoxIteration.Text = "Итерация";
            // 
            // numericUpDownIteration
            // 
            this.numericUpDownIteration.Location = new System.Drawing.Point(19, 24);
            this.numericUpDownIteration.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownIteration.Name = "numericUpDownIteration";
            this.numericUpDownIteration.Size = new System.Drawing.Size(53, 25);
            this.numericUpDownIteration.TabIndex = 0;
            this.numericUpDownIteration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownIteration.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // JuliaWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(347, 271);
            this.Controls.Add(this.groupCreateJulia);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JuliaWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Julia";
            this.groupCreateJulia.ResumeLayout(false);
            this.panelJulia.ResumeLayout(false);
            this.groupBoxFz.ResumeLayout(false);
            this.groupBoxFz.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYmin)).EndInit();
            this.groupBoxX.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShortHelp)).EndInit();
            this.groupBoxIteration.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIteration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupCreateJulia;
        private System.Windows.Forms.TextBox txtFz;
        private System.Windows.Forms.PictureBox pictureShortHelp;
        private System.Windows.Forms.GroupBox groupBoxX;
        private System.Windows.Forms.NumericUpDown numericUpDownXmax;
        private System.Windows.Forms.NumericUpDown numericUpDownXmin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownYmax;
        private System.Windows.Forms.NumericUpDown numericUpDownYmin;
        private System.Windows.Forms.ToolTip toolTipFunc;
        private System.Windows.Forms.ToolTip toolTipXminMax;
        private System.Windows.Forms.ToolTip toolTipYminMax;
        private System.Windows.Forms.ToolTip toolTipShortHelp;
        private System.Windows.Forms.Panel panelJulia;
        private System.Windows.Forms.GroupBox groupBoxFz;
        private Placeholder placeholderJulia;
        private System.Windows.Forms.GroupBox groupBoxIteration;
        private System.Windows.Forms.NumericUpDown numericUpDownIteration;
    }
}