namespace Gagagu_VR_Streamer_Server
{
    partial class Mainwindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainwindow));
            this.btStartServer = new System.Windows.Forms.Button();
            this.btStopServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProcessList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nCustomWindowHeight = new System.Windows.Forms.NumericUpDown();
            this.nCustomWindowWidth = new System.Windows.Forms.NumericUpDown();
            this.nCustomWindowY = new System.Windows.Forms.NumericUpDown();
            this.nCustomWindowX = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbCustomWindow = new System.Windows.Forms.CheckBox();
            this.btReloadWindowPositionAndSize = new System.Windows.Forms.Button();
            this.tbScrollRight = new System.Windows.Forms.TextBox();
            this.tbScrollLeft = new System.Windows.Forms.TextBox();
            this.tbScrollBottom = new System.Windows.Forms.TextBox();
            this.tbScrollTop = new System.Windows.Forms.TextBox();
            this.hScrollRight = new System.Windows.Forms.HScrollBar();
            this.hScrollLeft = new System.Windows.Forms.HScrollBar();
            this.hScrollBottom = new System.Windows.Forms.HScrollBar();
            this.hScrollTop = new System.Windows.Forms.HScrollBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbScrollImageQuality = new System.Windows.Forms.TextBox();
            this.hScrollImageQuality = new System.Windows.Forms.HScrollBar();
            this.label12 = new System.Windows.Forms.Label();
            this.cbDirectX = new System.Windows.Forms.CheckBox();
            this.cbCrosshair = new System.Windows.Forms.CheckBox();
            this.cbSimulate3D = new System.Windows.Forms.CheckBox();
            this.cbShowCursor = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbProfiles = new System.Windows.Forms.ComboBox();
            this.btDeleteProfile = new System.Windows.Forms.Button();
            this.btNewProfile = new System.Windows.Forms.Button();
            this.btSaveProfile = new System.Windows.Forms.Button();
            this.tbProcess = new System.Windows.Forms.TextBox();
            this.btTakeProcess = new System.Windows.Forms.Button();
            this.btReloadProcessList = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btAbout = new System.Windows.Forms.Button();
            this.lbIPAddress = new System.Windows.Forms.Label();
            this.cbIPAdresses = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCursorCorrection = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbScrollCursorSize = new System.Windows.Forms.TextBox();
            this.hScrollCursorSize = new System.Windows.Forms.HScrollBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbScrollAdjWidth = new System.Windows.Forms.TextBox();
            this.tbScrollAdjHeight = new System.Windows.Forms.TextBox();
            this.hScrollAdjWidth = new System.Windows.Forms.HScrollBar();
            this.hScrollAdjHeight = new System.Windows.Forms.HScrollBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCursorColors = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.tbAppearance = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCustomWindowHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCustomWindowWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCustomWindowY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCustomWindowX)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.tbAppearance.SuspendLayout();
            this.SuspendLayout();
            // 
            // btStartServer
            // 
            this.btStartServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStartServer.Location = new System.Drawing.Point(12, 14);
            this.btStartServer.Name = "btStartServer";
            this.btStartServer.Size = new System.Drawing.Size(146, 34);
            this.btStartServer.TabIndex = 0;
            this.btStartServer.Tag = "";
            this.btStartServer.Text = "Start Server";
            this.btStartServer.UseVisualStyleBackColor = true;
            this.btStartServer.Click += new System.EventHandler(this.btStartServer_Click);
            // 
            // btStopServer
            // 
            this.btStopServer.Enabled = false;
            this.btStopServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStopServer.Location = new System.Drawing.Point(164, 14);
            this.btStopServer.Name = "btStopServer";
            this.btStopServer.Size = new System.Drawing.Size(141, 34);
            this.btStopServer.TabIndex = 1;
            this.btStopServer.Text = "Stop Server";
            this.btStopServer.UseVisualStyleBackColor = true;
            this.btStopServer.Click += new System.EventHandler(this.btStopServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Network Port:";
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(86, 19);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(60, 20);
            this.tbServerPort.TabIndex = 3;
            this.tbServerPort.Text = "6666";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Process:";
            // 
            // cbProcessList
            // 
            this.cbProcessList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProcessList.FormattingEnabled = true;
            this.cbProcessList.Location = new System.Drawing.Point(254, 48);
            this.cbProcessList.Name = "cbProcessList";
            this.cbProcessList.Size = new System.Drawing.Size(166, 21);
            this.cbProcessList.Sorted = true;
            this.cbProcessList.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nCustomWindowHeight);
            this.groupBox1.Controls.Add(this.nCustomWindowWidth);
            this.groupBox1.Controls.Add(this.nCustomWindowY);
            this.groupBox1.Controls.Add(this.nCustomWindowX);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cbCustomWindow);
            this.groupBox1.Controls.Add(this.btReloadWindowPositionAndSize);
            this.groupBox1.Controls.Add(this.tbScrollRight);
            this.groupBox1.Controls.Add(this.tbScrollLeft);
            this.groupBox1.Controls.Add(this.tbScrollBottom);
            this.groupBox1.Controls.Add(this.tbScrollTop);
            this.groupBox1.Controls.Add(this.hScrollRight);
            this.groupBox1.Controls.Add(this.hScrollLeft);
            this.groupBox1.Controls.Add(this.hScrollBottom);
            this.groupBox1.Controls.Add(this.hScrollTop);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(7, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 227);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Capture Window Tools";
            // 
            // nCustomWindowHeight
            // 
            this.nCustomWindowHeight.Enabled = false;
            this.nCustomWindowHeight.Location = new System.Drawing.Point(280, 162);
            this.nCustomWindowHeight.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.nCustomWindowHeight.Name = "nCustomWindowHeight";
            this.nCustomWindowHeight.Size = new System.Drawing.Size(76, 20);
            this.nCustomWindowHeight.TabIndex = 61;
            this.nCustomWindowHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nCustomWindowHeight.ValueChanged += new System.EventHandler(this.nCustomWindowHeight_ValueChanged);
            // 
            // nCustomWindowWidth
            // 
            this.nCustomWindowWidth.Enabled = false;
            this.nCustomWindowWidth.Location = new System.Drawing.Point(280, 136);
            this.nCustomWindowWidth.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.nCustomWindowWidth.Name = "nCustomWindowWidth";
            this.nCustomWindowWidth.Size = new System.Drawing.Size(76, 20);
            this.nCustomWindowWidth.TabIndex = 60;
            this.nCustomWindowWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nCustomWindowWidth.ValueChanged += new System.EventHandler(this.nCustomWindowWidth_ValueChanged);
            // 
            // nCustomWindowY
            // 
            this.nCustomWindowY.Enabled = false;
            this.nCustomWindowY.Location = new System.Drawing.Point(154, 162);
            this.nCustomWindowY.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.nCustomWindowY.Name = "nCustomWindowY";
            this.nCustomWindowY.Size = new System.Drawing.Size(76, 20);
            this.nCustomWindowY.TabIndex = 59;
            this.nCustomWindowY.ValueChanged += new System.EventHandler(this.nCustomWindowY_ValueChanged);
            // 
            // nCustomWindowX
            // 
            this.nCustomWindowX.Enabled = false;
            this.nCustomWindowX.Location = new System.Drawing.Point(154, 136);
            this.nCustomWindowX.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.nCustomWindowX.Name = "nCustomWindowX";
            this.nCustomWindowX.Size = new System.Drawing.Size(76, 20);
            this.nCustomWindowX.TabIndex = 48;
            this.nCustomWindowX.ValueChanged += new System.EventHandler(this.nCustomWindowX_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(233, 164);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 58;
            this.label18.Text = "Height:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(236, 138);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 13);
            this.label19.TabIndex = 56;
            this.label19.Text = "Width:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(137, 164);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 13);
            this.label17.TabIndex = 54;
            this.label17.Text = "Y:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(137, 138);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 13);
            this.label16.TabIndex = 52;
            this.label16.Text = "X:";
            // 
            // cbCustomWindow
            // 
            this.cbCustomWindow.AutoSize = true;
            this.cbCustomWindow.Location = new System.Drawing.Point(22, 137);
            this.cbCustomWindow.Name = "cbCustomWindow";
            this.cbCustomWindow.Size = new System.Drawing.Size(103, 17);
            this.cbCustomWindow.TabIndex = 51;
            this.cbCustomWindow.Text = "Custom Window";
            this.cbCustomWindow.UseVisualStyleBackColor = true;
            this.cbCustomWindow.CheckedChanged += new System.EventHandler(this.cbCustomWindow_CheckedChanged);
            // 
            // btReloadWindowPositionAndSize
            // 
            this.btReloadWindowPositionAndSize.Location = new System.Drawing.Point(68, 187);
            this.btReloadWindowPositionAndSize.Name = "btReloadWindowPositionAndSize";
            this.btReloadWindowPositionAndSize.Size = new System.Drawing.Size(382, 23);
            this.btReloadWindowPositionAndSize.TabIndex = 50;
            this.btReloadWindowPositionAndSize.Text = "Refresh Process Window Position and Size";
            this.btReloadWindowPositionAndSize.UseVisualStyleBackColor = true;
            this.btReloadWindowPositionAndSize.Click += new System.EventHandler(this.btReloadWindowPositionAndSize_Click);
            // 
            // tbScrollRight
            // 
            this.tbScrollRight.Location = new System.Drawing.Point(395, 100);
            this.tbScrollRight.Name = "tbScrollRight";
            this.tbScrollRight.ReadOnly = true;
            this.tbScrollRight.Size = new System.Drawing.Size(55, 20);
            this.tbScrollRight.TabIndex = 39;
            this.tbScrollRight.Text = "0";
            this.tbScrollRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbScrollLeft
            // 
            this.tbScrollLeft.Location = new System.Drawing.Point(395, 74);
            this.tbScrollLeft.Name = "tbScrollLeft";
            this.tbScrollLeft.ReadOnly = true;
            this.tbScrollLeft.Size = new System.Drawing.Size(55, 20);
            this.tbScrollLeft.TabIndex = 38;
            this.tbScrollLeft.Text = "0";
            this.tbScrollLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbScrollBottom
            // 
            this.tbScrollBottom.Location = new System.Drawing.Point(395, 48);
            this.tbScrollBottom.Name = "tbScrollBottom";
            this.tbScrollBottom.ReadOnly = true;
            this.tbScrollBottom.Size = new System.Drawing.Size(55, 20);
            this.tbScrollBottom.TabIndex = 37;
            this.tbScrollBottom.Text = "0";
            this.tbScrollBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbScrollTop
            // 
            this.tbScrollTop.Location = new System.Drawing.Point(395, 22);
            this.tbScrollTop.Name = "tbScrollTop";
            this.tbScrollTop.ReadOnly = true;
            this.tbScrollTop.Size = new System.Drawing.Size(55, 20);
            this.tbScrollTop.TabIndex = 36;
            this.tbScrollTop.Text = "0";
            this.tbScrollTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollRight
            // 
            this.hScrollRight.Location = new System.Drawing.Point(69, 100);
            this.hScrollRight.Maximum = 1000;
            this.hScrollRight.Name = "hScrollRight";
            this.hScrollRight.Size = new System.Drawing.Size(323, 20);
            this.hScrollRight.TabIndex = 35;
            this.hScrollRight.ValueChanged += new System.EventHandler(this.hScrollRight_ValueChanged);
            // 
            // hScrollLeft
            // 
            this.hScrollLeft.Location = new System.Drawing.Point(69, 74);
            this.hScrollLeft.Maximum = 1000;
            this.hScrollLeft.Name = "hScrollLeft";
            this.hScrollLeft.Size = new System.Drawing.Size(323, 20);
            this.hScrollLeft.TabIndex = 34;
            this.hScrollLeft.ValueChanged += new System.EventHandler(this.hScrollLeft_ValueChanged);
            // 
            // hScrollBottom
            // 
            this.hScrollBottom.Location = new System.Drawing.Point(69, 48);
            this.hScrollBottom.Maximum = 1000;
            this.hScrollBottom.Name = "hScrollBottom";
            this.hScrollBottom.Size = new System.Drawing.Size(323, 20);
            this.hScrollBottom.TabIndex = 33;
            this.hScrollBottom.ValueChanged += new System.EventHandler(this.hScrollBottom_ValueChanged);
            // 
            // hScrollTop
            // 
            this.hScrollTop.Location = new System.Drawing.Point(69, 22);
            this.hScrollTop.Maximum = 1000;
            this.hScrollTop.Name = "hScrollTop";
            this.hScrollTop.Size = new System.Drawing.Size(323, 20);
            this.hScrollTop.TabIndex = 32;
            this.hScrollTop.ValueChanged += new System.EventHandler(this.hScrollTop_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "right:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "left:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "bottom:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "top:";
            // 
            // tbStatus
            // 
            this.tbStatus.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbStatus.Location = new System.Drawing.Point(6, 399);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.Size = new System.Drawing.Size(392, 20);
            this.tbStatus.TabIndex = 30;
            this.tbStatus.Text = "Status: ready";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbScrollImageQuality);
            this.groupBox2.Controls.Add(this.hScrollImageQuality);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cbDirectX);
            this.groupBox2.Controls.Add(this.cbCrosshair);
            this.groupBox2.Controls.Add(this.cbSimulate3D);
            this.groupBox2.Location = new System.Drawing.Point(6, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 136);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extras";
            // 
            // tbScrollImageQuality
            // 
            this.tbScrollImageQuality.Location = new System.Drawing.Point(385, 105);
            this.tbScrollImageQuality.Name = "tbScrollImageQuality";
            this.tbScrollImageQuality.ReadOnly = true;
            this.tbScrollImageQuality.Size = new System.Drawing.Size(55, 20);
            this.tbScrollImageQuality.TabIndex = 49;
            this.tbScrollImageQuality.Text = "50";
            this.tbScrollImageQuality.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollImageQuality
            // 
            this.hScrollImageQuality.Location = new System.Drawing.Point(103, 105);
            this.hScrollImageQuality.Maximum = 109;
            this.hScrollImageQuality.Minimum = 1;
            this.hScrollImageQuality.Name = "hScrollImageQuality";
            this.hScrollImageQuality.Size = new System.Drawing.Size(278, 20);
            this.hScrollImageQuality.TabIndex = 48;
            this.hScrollImageQuality.Value = 50;
            this.hScrollImageQuality.ValueChanged += new System.EventHandler(this.hScrollImageQuality_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Image Quality:";
            // 
            // cbDirectX
            // 
            this.cbDirectX.AutoSize = true;
            this.cbDirectX.Location = new System.Drawing.Point(22, 19);
            this.cbDirectX.Name = "cbDirectX";
            this.cbDirectX.Size = new System.Drawing.Size(83, 17);
            this.cbDirectX.TabIndex = 2;
            this.cbDirectX.Text = "Use DirectX";
            this.cbDirectX.UseVisualStyleBackColor = true;
            this.cbDirectX.CheckedChanged += new System.EventHandler(this.cbDirectX_CheckedChanged);
            // 
            // cbCrosshair
            // 
            this.cbCrosshair.AutoSize = true;
            this.cbCrosshair.Location = new System.Drawing.Point(22, 69);
            this.cbCrosshair.Name = "cbCrosshair";
            this.cbCrosshair.Size = new System.Drawing.Size(99, 17);
            this.cbCrosshair.TabIndex = 1;
            this.cbCrosshair.Text = "Show Crosshair";
            this.cbCrosshair.UseVisualStyleBackColor = true;
            this.cbCrosshair.CheckedChanged += new System.EventHandler(this.cbCrosshair_CheckedChanged);
            // 
            // cbSimulate3D
            // 
            this.cbSimulate3D.AutoSize = true;
            this.cbSimulate3D.Location = new System.Drawing.Point(22, 42);
            this.cbSimulate3D.Name = "cbSimulate3D";
            this.cbSimulate3D.Size = new System.Drawing.Size(83, 17);
            this.cbSimulate3D.TabIndex = 0;
            this.cbSimulate3D.Text = "Simulate 3D";
            this.cbSimulate3D.UseVisualStyleBackColor = true;
            this.cbSimulate3D.CheckedChanged += new System.EventHandler(this.cbSimulate3D_CheckedChanged);
            // 
            // cbShowCursor
            // 
            this.cbShowCursor.AutoSize = true;
            this.cbShowCursor.Location = new System.Drawing.Point(22, 19);
            this.cbShowCursor.Name = "cbShowCursor";
            this.cbShowCursor.Size = new System.Drawing.Size(86, 17);
            this.cbShowCursor.TabIndex = 1;
            this.cbShowCursor.Text = "Show Cursor";
            this.cbShowCursor.UseVisualStyleBackColor = true;
            this.cbShowCursor.CheckedChanged += new System.EventHandler(this.cbShowCursor_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbProfiles);
            this.groupBox3.Controls.Add(this.btDeleteProfile);
            this.groupBox3.Controls.Add(this.btNewProfile);
            this.groupBox3.Controls.Add(this.btSaveProfile);
            this.groupBox3.Location = new System.Drawing.Point(6, 297);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(475, 77);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Profiles";
            // 
            // cbProfiles
            // 
            this.cbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfiles.FormattingEnabled = true;
            this.cbProfiles.Location = new System.Drawing.Point(24, 19);
            this.cbProfiles.Name = "cbProfiles";
            this.cbProfiles.Size = new System.Drawing.Size(426, 21);
            this.cbProfiles.Sorted = true;
            this.cbProfiles.TabIndex = 3;
            this.cbProfiles.SelectedValueChanged += new System.EventHandler(this.cbProfiles_SelectedValueChanged);
            // 
            // btDeleteProfile
            // 
            this.btDeleteProfile.Location = new System.Drawing.Point(184, 46);
            this.btDeleteProfile.Name = "btDeleteProfile";
            this.btDeleteProfile.Size = new System.Drawing.Size(75, 23);
            this.btDeleteProfile.TabIndex = 2;
            this.btDeleteProfile.Text = "delete";
            this.btDeleteProfile.UseVisualStyleBackColor = true;
            this.btDeleteProfile.Click += new System.EventHandler(this.btDeleteProfile_Click);
            // 
            // btNewProfile
            // 
            this.btNewProfile.Location = new System.Drawing.Point(22, 46);
            this.btNewProfile.Name = "btNewProfile";
            this.btNewProfile.Size = new System.Drawing.Size(75, 23);
            this.btNewProfile.TabIndex = 1;
            this.btNewProfile.Text = "new";
            this.btNewProfile.UseVisualStyleBackColor = true;
            this.btNewProfile.Click += new System.EventHandler(this.btNewProfile_Click);
            // 
            // btSaveProfile
            // 
            this.btSaveProfile.Location = new System.Drawing.Point(103, 46);
            this.btSaveProfile.Name = "btSaveProfile";
            this.btSaveProfile.Size = new System.Drawing.Size(75, 23);
            this.btSaveProfile.TabIndex = 0;
            this.btSaveProfile.Text = "save";
            this.btSaveProfile.UseVisualStyleBackColor = true;
            this.btSaveProfile.Click += new System.EventHandler(this.btSaveProfile_Click);
            // 
            // tbProcess
            // 
            this.tbProcess.Location = new System.Drawing.Point(85, 48);
            this.tbProcess.Name = "tbProcess";
            this.tbProcess.Size = new System.Drawing.Size(137, 20);
            this.tbProcess.TabIndex = 33;
            // 
            // btTakeProcess
            // 
            this.btTakeProcess.Location = new System.Drawing.Point(226, 47);
            this.btTakeProcess.Name = "btTakeProcess";
            this.btTakeProcess.Size = new System.Drawing.Size(24, 23);
            this.btTakeProcess.TabIndex = 34;
            this.btTakeProcess.Text = "<-";
            this.btTakeProcess.UseVisualStyleBackColor = true;
            this.btTakeProcess.Click += new System.EventHandler(this.btTakeProcess_Click);
            // 
            // btReloadProcessList
            // 
            this.btReloadProcessList.Location = new System.Drawing.Point(423, 47);
            this.btReloadProcessList.Name = "btReloadProcessList";
            this.btReloadProcessList.Size = new System.Drawing.Size(44, 23);
            this.btReloadProcessList.TabIndex = 35;
            this.btReloadProcessList.Text = "reload";
            this.btReloadProcessList.UseVisualStyleBackColor = true;
            this.btReloadProcessList.Click += new System.EventHandler(this.btReloadProcessList_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.btReloadProcessList);
            this.groupBox4.Controls.Add(this.tbServerPort);
            this.groupBox4.Controls.Add(this.btTakeProcess);
            this.groupBox4.Controls.Add(this.cbProcessList);
            this.groupBox4.Controls.Add(this.tbProcess);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(6, 65);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(475, 84);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // btAbout
            // 
            this.btAbout.Location = new System.Drawing.Point(406, 398);
            this.btAbout.Name = "btAbout";
            this.btAbout.Size = new System.Drawing.Size(75, 23);
            this.btAbout.TabIndex = 37;
            this.btAbout.Text = "About";
            this.btAbout.UseVisualStyleBackColor = true;
            this.btAbout.Click += new System.EventHandler(this.btAbout_Click);
            // 
            // lbIPAddress
            // 
            this.lbIPAddress.AutoSize = true;
            this.lbIPAddress.Location = new System.Drawing.Point(342, 34);
            this.lbIPAddress.Name = "lbIPAddress";
            this.lbIPAddress.Size = new System.Drawing.Size(0, 13);
            this.lbIPAddress.TabIndex = 38;
            // 
            // cbIPAdresses
            // 
            this.cbIPAdresses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIPAdresses.FormattingEnabled = true;
            this.cbIPAdresses.Location = new System.Drawing.Point(103, 16);
            this.cbIPAdresses.Name = "cbIPAdresses";
            this.cbIPAdresses.Size = new System.Drawing.Size(365, 21);
            this.cbIPAdresses.Sorted = true;
            this.cbIPAdresses.TabIndex = 39;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.cbIPAdresses);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(6, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(475, 48);
            this.groupBox5.TabIndex = 40;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Info";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Local IP Address:";
            // 
            // cbCursorCorrection
            // 
            this.cbCursorCorrection.AutoSize = true;
            this.cbCursorCorrection.Enabled = false;
            this.cbCursorCorrection.Location = new System.Drawing.Point(22, 98);
            this.cbCursorCorrection.Name = "cbCursorCorrection";
            this.cbCursorCorrection.Size = new System.Drawing.Size(131, 17);
            this.cbCursorCorrection.TabIndex = 2;
            this.cbCursorCorrection.Text = "Cursor SBS Correction";
            this.cbCursorCorrection.UseVisualStyleBackColor = true;
            this.cbCursorCorrection.CheckedChanged += new System.EventHandler(this.cbCursorCorrection_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbScrollCursorSize);
            this.groupBox6.Controls.Add(this.hScrollCursorSize);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.tbScrollAdjWidth);
            this.groupBox6.Controls.Add(this.tbScrollAdjHeight);
            this.groupBox6.Controls.Add(this.hScrollAdjWidth);
            this.groupBox6.Controls.Add(this.hScrollAdjHeight);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.cbCursorColors);
            this.groupBox6.Controls.Add(this.cbCursorCorrection);
            this.groupBox6.Controls.Add(this.cbShowCursor);
            this.groupBox6.Location = new System.Drawing.Point(7, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(475, 187);
            this.groupBox6.TabIndex = 41;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Cursor";
            // 
            // tbScrollCursorSize
            // 
            this.tbScrollCursorSize.Location = new System.Drawing.Point(395, 65);
            this.tbScrollCursorSize.Name = "tbScrollCursorSize";
            this.tbScrollCursorSize.ReadOnly = true;
            this.tbScrollCursorSize.Size = new System.Drawing.Size(55, 20);
            this.tbScrollCursorSize.TabIndex = 47;
            this.tbScrollCursorSize.Text = "0";
            this.tbScrollCursorSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollCursorSize
            // 
            this.hScrollCursorSize.Location = new System.Drawing.Point(114, 65);
            this.hScrollCursorSize.Minimum = 1;
            this.hScrollCursorSize.Name = "hScrollCursorSize";
            this.hScrollCursorSize.Size = new System.Drawing.Size(278, 20);
            this.hScrollCursorSize.TabIndex = 46;
            this.hScrollCursorSize.Value = 1;
            this.hScrollCursorSize.ValueChanged += new System.EventHandler(this.hScrollCursorSize_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(81, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Size:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(74, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Color:";
            // 
            // tbScrollAdjWidth
            // 
            this.tbScrollAdjWidth.Location = new System.Drawing.Point(395, 154);
            this.tbScrollAdjWidth.Name = "tbScrollAdjWidth";
            this.tbScrollAdjWidth.ReadOnly = true;
            this.tbScrollAdjWidth.Size = new System.Drawing.Size(55, 20);
            this.tbScrollAdjWidth.TabIndex = 43;
            this.tbScrollAdjWidth.Text = "0";
            this.tbScrollAdjWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbScrollAdjHeight
            // 
            this.tbScrollAdjHeight.Location = new System.Drawing.Point(395, 128);
            this.tbScrollAdjHeight.Name = "tbScrollAdjHeight";
            this.tbScrollAdjHeight.ReadOnly = true;
            this.tbScrollAdjHeight.Size = new System.Drawing.Size(55, 20);
            this.tbScrollAdjHeight.TabIndex = 42;
            this.tbScrollAdjHeight.Text = "0";
            this.tbScrollAdjHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hScrollAdjWidth
            // 
            this.hScrollAdjWidth.Location = new System.Drawing.Point(114, 154);
            this.hScrollAdjWidth.Maximum = 1000;
            this.hScrollAdjWidth.Minimum = -1000;
            this.hScrollAdjWidth.Name = "hScrollAdjWidth";
            this.hScrollAdjWidth.Size = new System.Drawing.Size(278, 20);
            this.hScrollAdjWidth.TabIndex = 41;
            this.hScrollAdjWidth.ValueChanged += new System.EventHandler(this.hScrollAdjWidth_ValueChanged);
            // 
            // hScrollAdjHeight
            // 
            this.hScrollAdjHeight.Location = new System.Drawing.Point(114, 128);
            this.hScrollAdjHeight.Maximum = 1000;
            this.hScrollAdjHeight.Minimum = -1000;
            this.hScrollAdjHeight.Name = "hScrollAdjHeight";
            this.hScrollAdjHeight.Size = new System.Drawing.Size(278, 20);
            this.hScrollAdjHeight.TabIndex = 40;
            this.hScrollAdjHeight.ValueChanged += new System.EventHandler(this.hScrollAdjHeight_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Adjust Width:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Adjust Height:";
            // 
            // cbCursorColors
            // 
            this.cbCursorColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCursorColors.Enabled = false;
            this.cbCursorColors.FormattingEnabled = true;
            this.cbCursorColors.Location = new System.Drawing.Point(114, 40);
            this.cbCursorColors.Name = "cbCursorColors";
            this.cbCursorColors.Size = new System.Drawing.Size(199, 21);
            this.cbCursorColors.Sorted = true;
            this.cbCursorColors.TabIndex = 6;
            this.cbCursorColors.SelectedIndexChanged += new System.EventHandler(this.cbCursors_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpMain);
            this.tabControl1.Controls.Add(this.tbAppearance);
            this.tabControl1.Location = new System.Drawing.Point(12, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(495, 458);
            this.tabControl1.TabIndex = 42;
            // 
            // tpMain
            // 
            this.tpMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tpMain.Controls.Add(this.groupBox5);
            this.tpMain.Controls.Add(this.groupBox2);
            this.tpMain.Controls.Add(this.groupBox4);
            this.tpMain.Controls.Add(this.btAbout);
            this.tpMain.Controls.Add(this.tbStatus);
            this.tpMain.Controls.Add(this.groupBox3);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(487, 432);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "Main";
            // 
            // tbAppearance
            // 
            this.tbAppearance.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbAppearance.Controls.Add(this.groupBox1);
            this.tbAppearance.Controls.Add(this.groupBox6);
            this.tbAppearance.Location = new System.Drawing.Point(4, 22);
            this.tbAppearance.Name = "tbAppearance";
            this.tbAppearance.Padding = new System.Windows.Forms.Padding(3);
            this.tbAppearance.Size = new System.Drawing.Size(487, 432);
            this.tbAppearance.TabIndex = 1;
            this.tbAppearance.Text = "Appearance";
            // 
            // Mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(513, 525);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbIPAddress);
            this.Controls.Add(this.btStopServer);
            this.Controls.Add(this.btStartServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Mainwindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gagagu VR Streamer Server - v1.4.0";
            this.Load += new System.EventHandler(this.Mainwindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCustomWindowHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCustomWindowWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCustomWindowY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCustomWindowX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.tpMain.PerformLayout();
            this.tbAppearance.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStartServer;
        private System.Windows.Forms.Button btStopServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbProcessList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbScrollRight;
        private System.Windows.Forms.TextBox tbScrollLeft;
        private System.Windows.Forms.TextBox tbScrollBottom;
        private System.Windows.Forms.TextBox tbScrollTop;
        private System.Windows.Forms.HScrollBar hScrollRight;
        private System.Windows.Forms.HScrollBar hScrollLeft;
        private System.Windows.Forms.HScrollBar hScrollBottom;
        private System.Windows.Forms.HScrollBar hScrollTop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbSimulate3D;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbProfiles;
        private System.Windows.Forms.Button btDeleteProfile;
        private System.Windows.Forms.Button btNewProfile;
        private System.Windows.Forms.Button btSaveProfile;
        private System.Windows.Forms.TextBox tbProcess;
        private System.Windows.Forms.Button btTakeProcess;
        private System.Windows.Forms.Button btReloadProcessList;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btAbout;
        private System.Windows.Forms.Label lbIPAddress;
        private System.Windows.Forms.ComboBox cbIPAdresses;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbShowCursor;
        private System.Windows.Forms.CheckBox cbCursorCorrection;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbCursorColors;
        private System.Windows.Forms.CheckBox cbCrosshair;
        private System.Windows.Forms.TextBox tbScrollAdjWidth;
        private System.Windows.Forms.TextBox tbScrollAdjHeight;
        private System.Windows.Forms.HScrollBar hScrollAdjWidth;
        private System.Windows.Forms.HScrollBar hScrollAdjHeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbScrollCursorSize;
        private System.Windows.Forms.HScrollBar hScrollCursorSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbDirectX;
        private System.Windows.Forms.HScrollBar hScrollImageQuality;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbScrollImageQuality;
        private System.Windows.Forms.Button btReloadWindowPositionAndSize;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.TabPage tbAppearance;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox cbCustomWindow;
        private System.Windows.Forms.NumericUpDown nCustomWindowHeight;
        private System.Windows.Forms.NumericUpDown nCustomWindowWidth;
        private System.Windows.Forms.NumericUpDown nCustomWindowY;
        private System.Windows.Forms.NumericUpDown nCustomWindowX;
    }
}

