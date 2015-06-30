namespace FractalStudio
{
    partial class LsystemWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LsystemWindow));
            this.toolTipLsys = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBoxHelp = new System.Windows.Forms.PictureBox();
            this.groupBoxGenerLsys = new System.Windows.Forms.GroupBox();
            this.panelLsystem = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownIteration = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAxiom = new System.Windows.Forms.TextBox();
            this.comboBoxRules = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownInitAngle = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAngle = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.toolTipAngle = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipAxiom = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipRules = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipIteration = new System.Windows.Forms.ToolTip(this.components);
            this.placeholderLsys = new FractalStudio.Placeholder();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelp)).BeginInit();
            this.groupBoxGenerLsys.SuspendLayout();
            this.panelLsystem.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIteration)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipLsys
            // 
            this.toolTipLsys.AutoPopDelay = 15000;
            this.toolTipLsys.InitialDelay = 100;
            this.toolTipLsys.IsBalloon = true;
            this.toolTipLsys.ReshowDelay = 100;
            this.toolTipLsys.ToolTipTitle = "L-системы";
            // 
            // pictureBoxHelp
            // 
            this.pictureBoxHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxHelp.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxHelp.Image")));
            this.pictureBoxHelp.Location = new System.Drawing.Point(255, 18);
            this.pictureBoxHelp.Name = "pictureBoxHelp";
            this.pictureBoxHelp.Size = new System.Drawing.Size(31, 31);
            this.pictureBoxHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxHelp.TabIndex = 0;
            this.pictureBoxHelp.TabStop = false;
            this.toolTipLsys.SetToolTip(this.pictureBoxHelp, resources.GetString("pictureBoxHelp.ToolTip"));
            // 
            // groupBoxGenerLsys
            // 
            this.groupBoxGenerLsys.Controls.Add(this.panelLsystem);
            this.groupBoxGenerLsys.Controls.Add(this.pictureBoxHelp);
            this.groupBoxGenerLsys.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxGenerLsys.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxGenerLsys.ForeColor = System.Drawing.SystemColors.Info;
            this.groupBoxGenerLsys.Location = new System.Drawing.Point(25, 3);
            this.groupBoxGenerLsys.Name = "groupBoxGenerLsys";
            this.groupBoxGenerLsys.Size = new System.Drawing.Size(292, 226);
            this.groupBoxGenerLsys.TabIndex = 0;
            this.groupBoxGenerLsys.TabStop = false;
            this.groupBoxGenerLsys.Text = "Конструктор";
            // 
            // panelLsystem
            // 
            this.panelLsystem.Controls.Add(this.groupBox3);
            this.panelLsystem.Controls.Add(this.groupBox2);
            this.panelLsystem.Controls.Add(this.groupBox1);
            this.panelLsystem.Controls.Add(this.btnCancel);
            this.panelLsystem.Controls.Add(this.btnOk);
            this.panelLsystem.Location = new System.Drawing.Point(25, 24);
            this.panelLsystem.Name = "panelLsystem";
            this.panelLsystem.Size = new System.Drawing.Size(209, 200);
            this.panelLsystem.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownIteration);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Info;
            this.groupBox3.Location = new System.Drawing.Point(117, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(84, 62);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Итерация";
            // 
            // numericUpDownIteration
            // 
            this.numericUpDownIteration.Location = new System.Drawing.Point(19, 24);
            this.numericUpDownIteration.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownIteration.Name = "numericUpDownIteration";
            this.numericUpDownIteration.Size = new System.Drawing.Size(50, 25);
            this.numericUpDownIteration.TabIndex = 4;
            this.numericUpDownIteration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipIteration.SetToolTip(this.numericUpDownIteration, "Укажите номер итерации");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAxiom);
            this.groupBox2.Controls.Add(this.comboBoxRules);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Info;
            this.groupBox2.Location = new System.Drawing.Point(7, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 89);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Аксиома и правила";
            // 
            // txtAxiom
            // 
            this.txtAxiom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAxiom.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAxiom.Location = new System.Drawing.Point(17, 24);
            this.txtAxiom.Name = "txtAxiom";
            this.placeholderLsys.SetPlaceholder(this.txtAxiom, "Аксиома");
            this.txtAxiom.Size = new System.Drawing.Size(156, 25);
            this.txtAxiom.TabIndex = 5;
            this.txtAxiom.Text = "Аксиома";
            this.toolTipAxiom.SetToolTip(this.txtAxiom, "Введите аксиому.\r\nF - линия\r\nf - прозрачная линия\r\nПример аксиом:\r\n Кривая Коха F" +
        "\r\n Cнижинка Коха F++F++F\r\n");
            // 
            // comboBoxRules
            // 
            this.comboBoxRules.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxRules.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxRules.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBoxRules.FormattingEnabled = true;
            this.comboBoxRules.Location = new System.Drawing.Point(17, 58);
            this.comboBoxRules.Name = "comboBoxRules";
            this.placeholderLsys.SetPlaceholder(this.comboBoxRules, "Правила");
            this.comboBoxRules.Size = new System.Drawing.Size(156, 25);
            this.comboBoxRules.TabIndex = 6;
            this.comboBoxRules.Text = "Правила";
            this.toolTipRules.SetToolTip(this.comboBoxRules, "Введите пораждающее правило:\r\nПример:\r\n F->F+F--F+F\r\n X->XY+Ff+Z\r\n Z ->F-F+Ff");
            this.comboBoxRules.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRulesSelectedIndexChanged);
            this.comboBoxRules.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxRules_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownInitAngle);
            this.groupBox1.Controls.Add(this.numericUpDownAngle);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 62);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Углы";
            // 
            // numericUpDownInitAngle
            // 
            this.numericUpDownInitAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownInitAngle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownInitAngle.Location = new System.Drawing.Point(4, 24);
            this.numericUpDownInitAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownInitAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownInitAngle.Name = "numericUpDownInitAngle";
            this.numericUpDownInitAngle.Size = new System.Drawing.Size(46, 25);
            this.numericUpDownInitAngle.TabIndex = 2;
            this.numericUpDownInitAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipAngle.SetToolTip(this.numericUpDownInitAngle, "Начальный угол: от -360 до 360 градусов.");
            // 
            // numericUpDownAngle
            // 
            this.numericUpDownAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownAngle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownAngle.Location = new System.Drawing.Point(55, 24);
            this.numericUpDownAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownAngle.Name = "numericUpDownAngle";
            this.numericUpDownAngle.Size = new System.Drawing.Size(46, 25);
            this.numericUpDownAngle.TabIndex = 3;
            this.numericUpDownAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipAngle.SetToolTip(this.numericUpDownAngle, "Угол поворта : от -360 до 360 градусов.");
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancel.Location = new System.Drawing.Point(114, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 34);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancelClick);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.Window;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOk.Location = new System.Drawing.Point(7, 160);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 34);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOkClick);
            // 
            // toolTipAngle
            // 
            this.toolTipAngle.IsBalloon = true;
            this.toolTipAngle.ToolTipTitle = "Углы";
            // 
            // toolTipAxiom
            // 
            this.toolTipAxiom.IsBalloon = true;
            this.toolTipAxiom.ToolTipTitle = "Аксиома";
            // 
            // toolTipRules
            // 
            this.toolTipRules.IsBalloon = true;
            this.toolTipRules.ToolTipTitle = "Пораждающее правило";
            // 
            // toolTipIteration
            // 
            this.toolTipIteration.IsBalloon = true;
            this.toolTipIteration.ToolTipTitle = "Итерация";
            // 
            // LsystemWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(340, 234);
            this.Controls.Add(this.groupBoxGenerLsys);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LsystemWindow";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "L-системы";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelp)).EndInit();
            this.groupBoxGenerLsys.ResumeLayout(false);
            this.panelLsystem.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIteration)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTipLsys;
        private System.Windows.Forms.PictureBox pictureBoxHelp;
        private System.Windows.Forms.GroupBox groupBoxGenerLsys;
        private System.Windows.Forms.NumericUpDown numericUpDownAngle;
        private System.Windows.Forms.ToolTip toolTipAngle;
        private System.Windows.Forms.NumericUpDown numericUpDownInitAngle;
        private System.Windows.Forms.ComboBox comboBoxRules;
        private System.Windows.Forms.ToolTip toolTipRules;
        private System.Windows.Forms.ToolTip toolTipAxiom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panelLsystem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownIteration;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAxiom;
        private Placeholder placeholderLsys;
        private System.Windows.Forms.ToolTip toolTipIteration;
    }
}