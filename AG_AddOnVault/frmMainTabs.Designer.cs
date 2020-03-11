namespace AG_AddOnTool
{
    partial class frmMainTabs
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
            KryptonOutlookGrid.Classes.OutlookGridGroupCollection outlookGridGroupCollection1 = new KryptonOutlookGrid.Classes.OutlookGridGroupCollection();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainTabs));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabCon = new System.Windows.Forms.TabControl();
            this.tabVault = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cbResizeImages = new System.Windows.Forms.CheckBox();
            this.cbOverlay = new System.Windows.Forms.CheckBox();
            this.cbVUseInternalCore = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtVIndex = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.picVBezelArt = new System.Windows.Forms.PictureBox();
            this.picVBoxArt = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboVGenre = new System.Windows.Forms.ComboBox();
            this.btnVROM = new System.Windows.Forms.Button();
            this.txtVROM = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnVCore = new System.Windows.Forms.Button();
            this.txtVCore = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnVBezelArt = new System.Windows.Forms.Button();
            this.txtVBezelArt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnVBoxArt = new System.Windows.Forms.Button();
            this.txtVBoxArt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVTitle = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonGrid = new KryptonOutlookGrid.Classes.KryptonOutlookGrid();
            this.kryptonGroupBox = new KryptonOutlookGrid.Controls.KryptonOutlookGridGroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildUSBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importUCEFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.mnuMoveToGenre = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imgListCore = new System.Windows.Forms.ImageList(this.components);
            this.dlgOpenGameRom = new System.Windows.Forms.OpenFileDialog();
            this.dlgOpenEmulatorCore = new System.Windows.Forms.OpenFileDialog();
            this.dlgOpenBoxArt = new System.Windows.Forms.OpenFileDialog();
            this.dlgOpenBezelArt = new System.Windows.Forms.OpenFileDialog();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonContextMenuVault = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuItems2 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItem2 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItems1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuHeading1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabCon.SuspendLayout();
            this.tabVault.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVBezelArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVBoxArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabCon);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Size = new System.Drawing.Size(1138, 701);
            this.splitContainer1.SplitterDistance = 674;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // tabCon
            // 
            this.tabCon.Controls.Add(this.tabVault);
            this.tabCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCon.Location = new System.Drawing.Point(0, 24);
            this.tabCon.Margin = new System.Windows.Forms.Padding(2);
            this.tabCon.Name = "tabCon";
            this.tabCon.SelectedIndex = 0;
            this.tabCon.Size = new System.Drawing.Size(1138, 650);
            this.tabCon.TabIndex = 1;
            // 
            // tabVault
            // 
            this.tabVault.Controls.Add(this.splitContainer2);
            this.tabVault.Location = new System.Drawing.Point(4, 22);
            this.tabVault.Name = "tabVault";
            this.tabVault.Padding = new System.Windows.Forms.Padding(3);
            this.tabVault.Size = new System.Drawing.Size(1130, 624);
            this.tabVault.TabIndex = 1;
            this.tabVault.Text = "The Vault";
            this.tabVault.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AllowDrop = true;
            this.splitContainer2.Panel1.Controls.Add(this.cbResizeImages);
            this.splitContainer2.Panel1.Controls.Add(this.cbOverlay);
            this.splitContainer2.Panel1.Controls.Add(this.cbVUseInternalCore);
            this.splitContainer2.Panel1.Controls.Add(this.btnSave);
            this.splitContainer2.Panel1.Controls.Add(this.btnClear);
            this.splitContainer2.Panel1.Controls.Add(this.txtVIndex);
            this.splitContainer2.Panel1.Controls.Add(this.label15);
            this.splitContainer2.Panel1.Controls.Add(this.label16);
            this.splitContainer2.Panel1.Controls.Add(this.picVBezelArt);
            this.splitContainer2.Panel1.Controls.Add(this.picVBoxArt);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.cboVGenre);
            this.splitContainer2.Panel1.Controls.Add(this.btnVROM);
            this.splitContainer2.Panel1.Controls.Add(this.txtVROM);
            this.splitContainer2.Panel1.Controls.Add(this.label10);
            this.splitContainer2.Panel1.Controls.Add(this.btnVCore);
            this.splitContainer2.Panel1.Controls.Add(this.txtVCore);
            this.splitContainer2.Panel1.Controls.Add(this.label11);
            this.splitContainer2.Panel1.Controls.Add(this.btnVBezelArt);
            this.splitContainer2.Panel1.Controls.Add(this.txtVBezelArt);
            this.splitContainer2.Panel1.Controls.Add(this.label12);
            this.splitContainer2.Panel1.Controls.Add(this.btnVBoxArt);
            this.splitContainer2.Panel1.Controls.Add(this.txtVBoxArt);
            this.splitContainer2.Panel1.Controls.Add(this.label13);
            this.splitContainer2.Panel1.Controls.Add(this.txtVTitle);
            this.splitContainer2.Panel1.Controls.Add(this.label14);
            this.splitContainer2.Panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.splitContainer2_Panel1_DragDrop);
            this.splitContainer2.Panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.splitContainer2_Panel1_DragEnter);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.kryptonHeaderGroup1);
            this.splitContainer2.Size = new System.Drawing.Size(1124, 618);
            this.splitContainer2.SplitterDistance = 255;
            this.splitContainer2.TabIndex = 0;
            // 
            // cbResizeImages
            // 
            this.cbResizeImages.AutoSize = true;
            this.cbResizeImages.Location = new System.Drawing.Point(359, 227);
            this.cbResizeImages.Name = "cbResizeImages";
            this.cbResizeImages.Size = new System.Drawing.Size(95, 17);
            this.cbResizeImages.TabIndex = 109;
            this.cbResizeImages.Text = "Resize Images";
            this.cbResizeImages.UseVisualStyleBackColor = true;
            // 
            // cbOverlay
            // 
            this.cbOverlay.AutoSize = true;
            this.cbOverlay.Location = new System.Drawing.Point(660, 213);
            this.cbOverlay.Name = "cbOverlay";
            this.cbOverlay.Size = new System.Drawing.Size(92, 17);
            this.cbOverlay.TabIndex = 108;
            this.cbOverlay.Text = "Show Overlay";
            this.cbOverlay.UseVisualStyleBackColor = true;
            this.cbOverlay.CheckedChanged += new System.EventHandler(this.cbOverlay_CheckedChanged);
            // 
            // cbVUseInternalCore
            // 
            this.cbVUseInternalCore.AutoSize = true;
            this.cbVUseInternalCore.Location = new System.Drawing.Point(522, 122);
            this.cbVUseInternalCore.Name = "cbVUseInternalCore";
            this.cbVUseInternalCore.Size = new System.Drawing.Size(89, 17);
            this.cbVUseInternalCore.TabIndex = 107;
            this.cbVUseInternalCore.Text = "Use Internal?";
            this.cbVUseInternalCore.UseVisualStyleBackColor = true;
            this.cbVUseInternalCore.CheckedChanged += new System.EventHandler(this.cbVUseInternalCore_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(474, 221);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 106;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(97, 221);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 104;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtVIndex
            // 
            this.txtVIndex.Location = new System.Drawing.Point(350, 35);
            this.txtVIndex.Name = "txtVIndex";
            this.txtVIndex.Size = new System.Drawing.Size(68, 20);
            this.txtVIndex.TabIndex = 103;
            this.txtVIndex.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(908, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 13);
            this.label15.TabIndex = 102;
            this.label15.Text = "Bezel Art Preview";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(671, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 13);
            this.label16.TabIndex = 101;
            this.label16.Text = "Cover Art Preview";
            // 
            // picVBezelArt
            // 
            this.picVBezelArt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picVBezelArt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picVBezelArt.Location = new System.Drawing.Point(795, 35);
            this.picVBezelArt.Name = "picVBezelArt";
            this.picVBezelArt.Size = new System.Drawing.Size(306, 172);
            this.picVBezelArt.TabIndex = 100;
            this.picVBezelArt.TabStop = false;
            // 
            // picVBoxArt
            // 
            this.picVBoxArt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picVBoxArt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picVBoxArt.Location = new System.Drawing.Point(650, 35);
            this.picVBoxArt.Name = "picVBoxArt";
            this.picVBoxArt.Size = new System.Drawing.Size(126, 172);
            this.picVBoxArt.TabIndex = 99;
            this.picVBoxArt.TabStop = false;
            this.picVBoxArt.Paint += new System.Windows.Forms.PaintEventHandler(this.picVBoxArt_Paint);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 98;
            this.label9.Text = "Initial Genre:";
            // 
            // cboVGenre
            // 
            this.cboVGenre.FormattingEnabled = true;
            this.cboVGenre.Location = new System.Drawing.Point(97, 178);
            this.cboVGenre.Name = "cboVGenre";
            this.cboVGenre.Size = new System.Drawing.Size(196, 21);
            this.cboVGenre.TabIndex = 97;
            this.cboVGenre.SelectedIndexChanged += new System.EventHandler(this.txtCtrl_TextChanged);
            // 
            // btnVROM
            // 
            this.btnVROM.Location = new System.Drawing.Point(424, 149);
            this.btnVROM.Name = "btnVROM";
            this.btnVROM.Size = new System.Drawing.Size(125, 22);
            this.btnVROM.TabIndex = 96;
            this.btnVROM.Text = "Choose ROM...";
            this.btnVROM.UseVisualStyleBackColor = true;
            this.btnVROM.Click += new System.EventHandler(this.btnVROM_Click);
            // 
            // txtVROM
            // 
            this.txtVROM.Location = new System.Drawing.Point(97, 151);
            this.txtVROM.Name = "txtVROM";
            this.txtVROM.Size = new System.Drawing.Size(321, 20);
            this.txtVROM.TabIndex = 95;
            this.txtVROM.TextChanged += new System.EventHandler(this.txtCtrl_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 94;
            this.label10.Text = "Game ROM:";
            // 
            // btnVCore
            // 
            this.btnVCore.Location = new System.Drawing.Point(424, 120);
            this.btnVCore.Name = "btnVCore";
            this.btnVCore.Size = new System.Drawing.Size(92, 22);
            this.btnVCore.TabIndex = 93;
            this.btnVCore.Text = "Choose Core...";
            this.btnVCore.UseVisualStyleBackColor = true;
            this.btnVCore.Click += new System.EventHandler(this.btnVCore_Click);
            // 
            // txtVCore
            // 
            this.txtVCore.Location = new System.Drawing.Point(97, 122);
            this.txtVCore.Name = "txtVCore";
            this.txtVCore.Size = new System.Drawing.Size(321, 20);
            this.txtVCore.TabIndex = 92;
            this.txtVCore.TextChanged += new System.EventHandler(this.txtCtrl_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 91;
            this.label11.Text = "Emulator Core:";
            // 
            // btnVBezelArt
            // 
            this.btnVBezelArt.Location = new System.Drawing.Point(424, 88);
            this.btnVBezelArt.Name = "btnVBezelArt";
            this.btnVBezelArt.Size = new System.Drawing.Size(125, 23);
            this.btnVBezelArt.TabIndex = 90;
            this.btnVBezelArt.Text = "Choose Bezel Art...";
            this.btnVBezelArt.UseVisualStyleBackColor = true;
            this.btnVBezelArt.Click += new System.EventHandler(this.btnVBezelArt_Click);
            // 
            // txtVBezelArt
            // 
            this.txtVBezelArt.Location = new System.Drawing.Point(97, 92);
            this.txtVBezelArt.Name = "txtVBezelArt";
            this.txtVBezelArt.Size = new System.Drawing.Size(321, 20);
            this.txtVBezelArt.TabIndex = 89;
            this.txtVBezelArt.TextChanged += new System.EventHandler(this.txtCtrl_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 88;
            this.label12.Text = "Bezel Art:";
            // 
            // btnVBoxArt
            // 
            this.btnVBoxArt.Location = new System.Drawing.Point(424, 61);
            this.btnVBoxArt.Name = "btnVBoxArt";
            this.btnVBoxArt.Size = new System.Drawing.Size(125, 21);
            this.btnVBoxArt.TabIndex = 87;
            this.btnVBoxArt.Text = "Choose Cover Art...";
            this.btnVBoxArt.UseVisualStyleBackColor = true;
            this.btnVBoxArt.Click += new System.EventHandler(this.btnVBoxArt_Click);
            // 
            // txtVBoxArt
            // 
            this.txtVBoxArt.Location = new System.Drawing.Point(97, 61);
            this.txtVBoxArt.Name = "txtVBoxArt";
            this.txtVBoxArt.Size = new System.Drawing.Size(321, 20);
            this.txtVBoxArt.TabIndex = 86;
            this.txtVBoxArt.TextChanged += new System.EventHandler(this.txtCtrl_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 85;
            this.label13.Text = "Cover Art:";
            // 
            // txtVTitle
            // 
            this.txtVTitle.Location = new System.Drawing.Point(97, 35);
            this.txtVTitle.Name = "txtVTitle";
            this.txtVTitle.Size = new System.Drawing.Size(222, 20);
            this.txtVTitle.TabIndex = 84;
            this.txtVTitle.TextChanged += new System.EventHandler(this.txtCtrl_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 83;
            this.label14.Text = "Game TItle";
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonGrid);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonGroupBox);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(1124, 359);
            this.kryptonHeaderGroup1.TabIndex = 2;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Vault Configs";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            // 
            // kryptonGrid
            // 
            this.kryptonGrid.AllowDrop = true;
            this.kryptonGrid.AllowUserToAddRows = false;
            this.kryptonGrid.AllowUserToDeleteRows = false;
            this.kryptonGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.kryptonGrid.FillMode = KryptonOutlookGrid.Classes.FillMode.GROUPSONLY;
            this.kryptonGrid.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.kryptonGrid.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.kryptonGrid.GroupBox = this.kryptonGroupBox;
            this.kryptonGrid.GroupCollection = outlookGridGroupCollection1;
            this.kryptonGrid.HideColumnOnGrouping = true;
            this.kryptonGrid.Location = new System.Drawing.Point(0, 29);
            this.kryptonGrid.Name = "kryptonGrid";
            this.kryptonGrid.PreviousSelectedGroupRow = -1;
            this.kryptonGrid.ReadOnly = true;
            this.kryptonGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kryptonGrid.ShowLines = false;
            this.kryptonGrid.Size = new System.Drawing.Size(1122, 277);
            this.kryptonGrid.TabIndex = 0;
            this.kryptonGrid.DoubleClick += new System.EventHandler(this.kryptonGrid_DoubleClick);
            this.kryptonGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.kryptonGrid_MouseClick);
            this.kryptonGrid.Resize += new System.EventHandler(this.kryptonGrid_Resize);
            // 
            // kryptonGroupBox
            // 
            this.kryptonGroupBox.AllowDrop = true;
            this.kryptonGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonGroupBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBox.Location = new System.Drawing.Point(0, 0);
            this.kryptonGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.kryptonGroupBox.Name = "kryptonGroupBox";
            this.kryptonGroupBox.Size = new System.Drawing.Size(1122, 29);
            this.kryptonGroupBox.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1138, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.buildUSBToolStripMenuItem,
            this.importUCEFilesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.settingsToolStripMenuItem.Text = "&Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // buildUSBToolStripMenuItem
            // 
            this.buildUSBToolStripMenuItem.Name = "buildUSBToolStripMenuItem";
            this.buildUSBToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.buildUSBToolStripMenuItem.Text = "&Build USB...";
            this.buildUSBToolStripMenuItem.Click += new System.EventHandler(this.buildUSBToolStripMenuItem_Click);
            // 
            // importUCEFilesToolStripMenuItem
            // 
            this.importUCEFilesToolStripMenuItem.Name = "importUCEFilesToolStripMenuItem";
            this.importUCEFilesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.importUCEFilesToolStripMenuItem.Text = "&Import UCE File(s)...";
            this.importUCEFilesToolStripMenuItem.Click += new System.EventHandler(this.importUCEFilesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1138, 25);
            this.progressBar1.TabIndex = 0;
            // 
            // mnuMoveToGenre
            // 
            this.mnuMoveToGenre.Name = "mnuMoveToGenre";
            this.mnuMoveToGenre.Size = new System.Drawing.Size(61, 4);
            this.mnuMoveToGenre.Text = "Move To Genre";
            // 
            // imgListCore
            // 
            this.imgListCore.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListCore.ImageStream")));
            this.imgListCore.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListCore.Images.SetKeyName(0, "Atari.png");
            this.imgListCore.Images.SetKeyName(1, "MAME.png");
            this.imgListCore.Images.SetKeyName(2, "NES.png");
            this.imgListCore.Images.SetKeyName(3, "Playstation.png");
            this.imgListCore.Images.SetKeyName(4, "PlaystationWhite.png");
            this.imgListCore.Images.SetKeyName(5, "SNES.png");
            // 
            // dlgOpenGameRom
            // 
            this.dlgOpenGameRom.FileName = "openFileDialog1";
            // 
            // dlgOpenEmulatorCore
            // 
            this.dlgOpenEmulatorCore.FileName = "openFileDialog1";
            // 
            // dlgOpenBoxArt
            // 
            this.dlgOpenBoxArt.FileName = "Select a PNG file";
            this.dlgOpenBoxArt.Filter = "Portable Network Graphics (PNG) files (*.png)|*.png";
            this.dlgOpenBoxArt.Title = "Open PNG File";
            // 
            // dlgOpenBezelArt
            // 
            this.dlgOpenBezelArt.FileName = "openFileDialog1";
            // 
            // kryptonContextMenuVault
            // 
            this.kryptonContextMenuVault.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItems2});
            // 
            // kryptonContextMenuItems2
            // 
            this.kryptonContextMenuItems2.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem1,
            this.kryptonContextMenuItem2});
            // 
            // kryptonContextMenuItem1
            // 
            this.kryptonContextMenuItem1.Text = "&Build Selected UCE(s)...";
            // 
            // kryptonContextMenuItem2
            // 
            this.kryptonContextMenuItem2.Text = "&Move to Genre";
            // 
            // kryptonContextMenuHeading1
            // 
            this.kryptonContextMenuHeading1.ExtraText = "";
            // 
            // frmMainTabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 701);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMainTabs";
            this.Text = "AG AddOn Vault Ex";
            this.Load += new System.EventHandler(this.frmMainTabs_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabCon.ResumeLayout(false);
            this.tabVault.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picVBezelArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVBoxArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabCon;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip mnuMoveToGenre;
        private System.Windows.Forms.ToolStripMenuItem buildUSBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ImageList imgListCore;
        private System.Windows.Forms.OpenFileDialog dlgOpenGameRom;
        private System.Windows.Forms.OpenFileDialog dlgOpenEmulatorCore;
        private System.Windows.Forms.OpenFileDialog dlgOpenBoxArt;
        private System.Windows.Forms.OpenFileDialog dlgOpenBezelArt;
        private System.Windows.Forms.TabPage tabVault;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private KryptonOutlookGrid.Classes.KryptonOutlookGrid kryptonGrid;
        private KryptonOutlookGrid.Controls.KryptonOutlookGridGroupBox kryptonGroupBox;
        private System.Windows.Forms.PictureBox picVBezelArt;
        private System.Windows.Forms.PictureBox picVBoxArt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboVGenre;
        private System.Windows.Forms.Button btnVROM;
        private System.Windows.Forms.TextBox txtVROM;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnVCore;
        private System.Windows.Forms.TextBox txtVCore;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnVBezelArt;
        private System.Windows.Forms.TextBox txtVBezelArt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnVBoxArt;
        private System.Windows.Forms.TextBox txtVBoxArt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtVTitle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu kryptonContextMenuVault;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems2;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem2;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading kryptonContextMenuHeading1;
        private System.Windows.Forms.TextBox txtVIndex;
        private System.Windows.Forms.CheckBox cbVUseInternalCore;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox cbOverlay;
        private System.Windows.Forms.CheckBox cbResizeImages;
        private System.Windows.Forms.ToolStripMenuItem importUCEFilesToolStripMenuItem;
    }
}