namespace FractalStudio
{
    partial class MainWindow
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseAppMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FractalsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.lsystemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.affineTransformMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.juliaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mandelbrotMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DimensionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.minkowskiDimensionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mainSatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.panelContent = new System.Windows.Forms.Panel();
            this.contextImageMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фракталыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lсистемыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.аффиныеПреобразованияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.множествоЖюлиаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.множествоМандельбротаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размерностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MinkowskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerContent = new System.Windows.Forms.SplitContainer();
            this.groupBoxCreate = new System.Windows.Forms.GroupBox();
            this.lblShortHelp = new System.Windows.Forms.Label();
            this.groupBoxBtn = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.saveFileDialogImg = new System.Windows.Forms.SaveFileDialog();
            this.CorrelationDimensionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CorrelationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.mainSatusStrip.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.contextImageMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerContent)).BeginInit();
            this.splitContainerContent.Panel1.SuspendLayout();
            this.splitContainerContent.Panel2.SuspendLayout();
            this.splitContainerContent.SuspendLayout();
            this.groupBoxCreate.SuspendLayout();
            this.groupBoxBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.FractalsMenu,
            this.DimensionsMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(701, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsMenu,
            this.CloseAppMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.ShortcutKeyDisplayString = "";
            this.fileMenu.Size = new System.Drawing.Size(48, 20);
            this.fileMenu.Text = "Файл";
            // 
            // saveAsMenu
            // 
            this.saveAsMenu.Name = "saveAsMenu";
            this.saveAsMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsMenu.Size = new System.Drawing.Size(276, 22);
            this.saveAsMenu.Text = "Сохранить изображение как..";
            this.saveAsMenu.Click += new System.EventHandler(this.SaveAsMenuClick);
            // 
            // CloseAppMenu
            // 
            this.CloseAppMenu.Name = "CloseAppMenu";
            this.CloseAppMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.CloseAppMenu.Size = new System.Drawing.Size(276, 22);
            this.CloseAppMenu.Text = "Закрыть";
            this.CloseAppMenu.Click += new System.EventHandler(this.CloseAppMenu_Click);
            // 
            // FractalsMenu
            // 
            this.FractalsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lsystemMenu,
            this.affineTransformMenu,
            this.juliaMenu,
            this.mandelbrotMenu});
            this.FractalsMenu.Name = "FractalsMenu";
            this.FractalsMenu.Size = new System.Drawing.Size(74, 20);
            this.FractalsMenu.Text = "Фракталы";
            // 
            // lsystemMenu
            // 
            this.lsystemMenu.Name = "lsystemMenu";
            this.lsystemMenu.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.lsystemMenu.Size = new System.Drawing.Size(297, 22);
            this.lsystemMenu.Tag = "0";
            this.lsystemMenu.Text = "L-системы";
            this.lsystemMenu.Click += new System.EventHandler(this.WindowShowFractal);
            // 
            // affineTransformMenu
            // 
            this.affineTransformMenu.Name = "affineTransformMenu";
            this.affineTransformMenu.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.affineTransformMenu.Size = new System.Drawing.Size(297, 22);
            this.affineTransformMenu.Tag = "1";
            this.affineTransformMenu.Text = "Аффиные преобразования";
            this.affineTransformMenu.Click += new System.EventHandler(this.WindowShowFractal);
            // 
            // juliaMenu
            // 
            this.juliaMenu.Name = "juliaMenu";
            this.juliaMenu.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.J)));
            this.juliaMenu.Size = new System.Drawing.Size(297, 22);
            this.juliaMenu.Tag = "2";
            this.juliaMenu.Text = "Жюлиа";
            this.juliaMenu.Click += new System.EventHandler(this.WindowShowFractal);
            // 
            // mandelbrotMenu
            // 
            this.mandelbrotMenu.Name = "mandelbrotMenu";
            this.mandelbrotMenu.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.T)));
            this.mandelbrotMenu.Size = new System.Drawing.Size(297, 22);
            this.mandelbrotMenu.Tag = "3";
            this.mandelbrotMenu.Text = "Мандельброт";
            this.mandelbrotMenu.Click += new System.EventHandler(this.WindowShowFractal);
            // 
            // DimensionsMenu
            // 
            this.DimensionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minkowskiDimensionMenu,
            this.CorrelationDimensionMenu});
            this.DimensionsMenu.Name = "DimensionsMenu";
            this.DimensionsMenu.Size = new System.Drawing.Size(91, 20);
            this.DimensionsMenu.Text = "Размерности";
            // 
            // minkowskiDimensionMenu
            // 
            this.minkowskiDimensionMenu.Name = "minkowskiDimensionMenu";
            this.minkowskiDimensionMenu.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.minkowskiDimensionMenu.Size = new System.Drawing.Size(241, 22);
            this.minkowskiDimensionMenu.Tag = "0";
            this.minkowskiDimensionMenu.Text = "Минковского";
            this.minkowskiDimensionMenu.Click += new System.EventHandler(this.WindowShowDimension);
            // 
            // mainSatusStrip
            // 
            this.mainSatusStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainSatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar});
            this.mainSatusStrip.Location = new System.Drawing.Point(0, 429);
            this.mainSatusStrip.Name = "mainSatusStrip";
            this.mainSatusStrip.Size = new System.Drawing.Size(701, 22);
            this.mainSatusStrip.TabIndex = 1;
            this.mainSatusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.AutoSize = false;
            this.toolStripProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripProgressBar.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripProgressBar.MarqueeAnimationSpeed = 10;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Padding = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.toolStripProgressBar.Size = new System.Drawing.Size(206, 22);
            this.toolStripProgressBar.Step = 1;
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // panelContent
            // 
            this.panelContent.ContextMenuStrip = this.contextImageMenu;
            this.panelContent.Controls.Add(this.splitContainerContent);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 24);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(3);
            this.panelContent.Size = new System.Drawing.Size(701, 405);
            this.panelContent.TabIndex = 2;
            // 
            // contextImageMenu
            // 
            this.contextImageMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьКакToolStripMenuItem,
            this.фракталыToolStripMenuItem,
            this.размерностьToolStripMenuItem});
            this.contextImageMenu.Name = "contextImageMenu";
            this.contextImageMenu.Size = new System.Drawing.Size(237, 70);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить изображение как..";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.SaveAsMenuClick);
            // 
            // фракталыToolStripMenuItem
            // 
            this.фракталыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lсистемыToolStripMenuItem,
            this.аффиныеПреобразованияToolStripMenuItem,
            this.множествоЖюлиаToolStripMenuItem,
            this.множествоМандельбротаToolStripMenuItem});
            this.фракталыToolStripMenuItem.Name = "фракталыToolStripMenuItem";
            this.фракталыToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.фракталыToolStripMenuItem.Text = "Фрактал";
            // 
            // lсистемыToolStripMenuItem
            // 
            this.lсистемыToolStripMenuItem.Name = "lсистемыToolStripMenuItem";
            this.lсистемыToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.lсистемыToolStripMenuItem.Tag = "0";
            this.lсистемыToolStripMenuItem.Text = "L-системы";
            this.lсистемыToolStripMenuItem.Click += new System.EventHandler(this.WindowShowFractal);
            // 
            // аффиныеПреобразованияToolStripMenuItem
            // 
            this.аффиныеПреобразованияToolStripMenuItem.Name = "аффиныеПреобразованияToolStripMenuItem";
            this.аффиныеПреобразованияToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.аффиныеПреобразованияToolStripMenuItem.Tag = "1";
            this.аффиныеПреобразованияToolStripMenuItem.Text = "Аффиные преобразования";
            this.аффиныеПреобразованияToolStripMenuItem.Click += new System.EventHandler(this.WindowShowFractal);
            // 
            // множествоЖюлиаToolStripMenuItem
            // 
            this.множествоЖюлиаToolStripMenuItem.Name = "множествоЖюлиаToolStripMenuItem";
            this.множествоЖюлиаToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.множествоЖюлиаToolStripMenuItem.Tag = "2";
            this.множествоЖюлиаToolStripMenuItem.Text = "Множество Жюлиа";
            this.множествоЖюлиаToolStripMenuItem.Click += new System.EventHandler(this.WindowShowFractal);
            // 
            // множествоМандельбротаToolStripMenuItem
            // 
            this.множествоМандельбротаToolStripMenuItem.Name = "множествоМандельбротаToolStripMenuItem";
            this.множествоМандельбротаToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.множествоМандельбротаToolStripMenuItem.Tag = "3";
            this.множествоМандельбротаToolStripMenuItem.Text = "Множество Мандельброта";
            this.множествоМандельбротаToolStripMenuItem.Click += new System.EventHandler(this.WindowShowFractal);
            // 
            // размерностьToolStripMenuItem
            // 
            this.размерностьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MinkowskiToolStripMenuItem,
            this.CorrelationToolStripMenuItem});
            this.размерностьToolStripMenuItem.Name = "размерностьToolStripMenuItem";
            this.размерностьToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.размерностьToolStripMenuItem.Text = "Размерность";
            // 
            // MinkowskiToolStripMenuItem
            // 
            this.MinkowskiToolStripMenuItem.Name = "MinkowskiToolStripMenuItem";
            this.MinkowskiToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.MinkowskiToolStripMenuItem.Tag = "0";
            this.MinkowskiToolStripMenuItem.Text = "Минковского";
            this.MinkowskiToolStripMenuItem.Click += new System.EventHandler(this.WindowShowDimension);
            // 
            // splitContainerContent
            // 
            this.splitContainerContent.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainerContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerContent.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerContent.Location = new System.Drawing.Point(3, 3);
            this.splitContainerContent.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerContent.Name = "splitContainerContent";
            // 
            // splitContainerContent.Panel1
            // 
            this.splitContainerContent.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.splitContainerContent.Panel1.Controls.Add(this.groupBoxCreate);
            this.splitContainerContent.Panel1.Controls.Add(this.groupBoxBtn);
            this.splitContainerContent.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerContent.Panel1MinSize = 280;
            // 
            // splitContainerContent.Panel2
            // 
            this.splitContainerContent.Panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.splitContainerContent.Panel2.Controls.Add(this.pictureBoxResult);
            this.splitContainerContent.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerContent.Panel2MinSize = 0;
            this.splitContainerContent.Size = new System.Drawing.Size(695, 399);
            this.splitContainerContent.SplitterDistance = 280;
            this.splitContainerContent.SplitterIncrement = 2;
            this.splitContainerContent.SplitterWidth = 2;
            this.splitContainerContent.TabIndex = 10;
            this.splitContainerContent.TabStop = false;
            // 
            // groupBoxCreate
            // 
            this.groupBoxCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxCreate.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBoxCreate.Controls.Add(this.lblShortHelp);
            this.groupBoxCreate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxCreate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxCreate.ForeColor = System.Drawing.SystemColors.Info;
            this.groupBoxCreate.Location = new System.Drawing.Point(19, 18);
            this.groupBoxCreate.Name = "groupBoxCreate";
            this.groupBoxCreate.Size = new System.Drawing.Size(245, 306);
            this.groupBoxCreate.TabIndex = 1;
            this.groupBoxCreate.TabStop = false;
            this.groupBoxCreate.Text = "Fractal Studio";
            // 
            // lblShortHelp
            // 
            this.lblShortHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblShortHelp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblShortHelp.ForeColor = System.Drawing.SystemColors.Window;
            this.lblShortHelp.Location = new System.Drawing.Point(3, 21);
            this.lblShortHelp.Name = "lblShortHelp";
            this.lblShortHelp.Size = new System.Drawing.Size(239, 282);
            this.lblShortHelp.TabIndex = 0;
            this.lblShortHelp.Text = "Fractal Studio позволяет генерировать  фракталы с помощью L - систем, афинных пре" +
    "образований. Строить множества Жюлиа и Мандельброта. Растчитывать размерности Ми" +
    "нковского и может еще какие нить";
            this.lblShortHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxBtn
            // 
            this.groupBoxBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBoxBtn.Controls.Add(this.btnStop);
            this.groupBoxBtn.Controls.Add(this.btnStart);
            this.groupBoxBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxBtn.Location = new System.Drawing.Point(40, 324);
            this.groupBoxBtn.Margin = new System.Windows.Forms.Padding(7);
            this.groupBoxBtn.Name = "groupBoxBtn";
            this.groupBoxBtn.Padding = new System.Windows.Forms.Padding(7);
            this.groupBoxBtn.Size = new System.Drawing.Size(202, 58);
            this.groupBoxBtn.TabIndex = 0;
            this.groupBoxBtn.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.Window;
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Location = new System.Drawing.Point(114, 20);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 27);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Прервать";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStopClick);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.Window;
            this.btnStart.Enabled = false;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Location = new System.Drawing.Point(11, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 27);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Вычислить";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStartClick);
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxResult.Location = new System.Drawing.Point(5, 5);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(401, 387);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxResult.TabIndex = 0;
            this.pictureBoxResult.TabStop = false;
            // 
            // saveFileDialogImg
            // 
            this.saveFileDialogImg.FileName = "Изображение";
            this.saveFileDialogImg.Filter = "Image Files|*.jpeg;";
            this.saveFileDialogImg.Title = "Сохранить изображение как..";
            // 
            // CorrelationDimensionMenu
            // 
            this.CorrelationDimensionMenu.Name = "CorrelationDimensionMenu";
            this.CorrelationDimensionMenu.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.K)));
            this.CorrelationDimensionMenu.Size = new System.Drawing.Size(241, 22);
            this.CorrelationDimensionMenu.Tag = "1";
            this.CorrelationDimensionMenu.Text = "Корреляционная";
            this.CorrelationDimensionMenu.Click += new System.EventHandler(this.WindowShowDimension);
            // 
            // CorrelationToolStripMenuItem
            // 
            this.CorrelationToolStripMenuItem.Name = "CorrelationToolStripMenuItem";
            this.CorrelationToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.CorrelationToolStripMenuItem.Text = "Корреляционная";
            this.CorrelationToolStripMenuItem.Click += new System.EventHandler(this.WindowShowDimension);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 451);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.mainSatusStrip);
            this.Controls.Add(this.mainMenu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(709, 481);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fractal Studio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindowFormClosing);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.mainSatusStrip.ResumeLayout(false);
            this.mainSatusStrip.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.contextImageMenu.ResumeLayout(false);
            this.splitContainerContent.Panel1.ResumeLayout(false);
            this.splitContainerContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerContent)).EndInit();
            this.splitContainerContent.ResumeLayout(false);
            this.groupBoxCreate.ResumeLayout(false);
            this.groupBoxBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenu;
        private System.Windows.Forms.ToolStripMenuItem CloseAppMenu;
        private System.Windows.Forms.StatusStrip mainSatusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem FractalsMenu;
        private System.Windows.Forms.ToolStripMenuItem DimensionsMenu;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.SplitContainer splitContainerContent;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.ContextMenuStrip contextImageMenu;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxBtn;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBoxCreate;
        private System.Windows.Forms.Label lblShortHelp;
        private System.Windows.Forms.ToolStripMenuItem lsystemMenu;
        private System.Windows.Forms.ToolStripMenuItem affineTransformMenu;
        private System.Windows.Forms.ToolStripMenuItem juliaMenu;
        private System.Windows.Forms.ToolStripMenuItem mandelbrotMenu;
        private System.Windows.Forms.ToolStripMenuItem minkowskiDimensionMenu;
        private System.Windows.Forms.ToolStripMenuItem фракталыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lсистемыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem аффиныеПреобразованияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem множествоЖюлиаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem множествоМандельбротаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размерностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MinkowskiToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogImg;
        private System.Windows.Forms.ToolStripMenuItem CorrelationDimensionMenu;
        private System.Windows.Forms.ToolStripMenuItem CorrelationToolStripMenuItem;
    }
}

