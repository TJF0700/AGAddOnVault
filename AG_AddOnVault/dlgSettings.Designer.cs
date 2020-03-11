namespace AG_AddOnTool
{
    partial class dlgSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbUseTabs = new System.Windows.Forms.CheckBox();
            this.cbShowBuildWindow = new System.Windows.Forms.CheckBox();
            this.btnCreateVault = new System.Windows.Forms.Button();
            this.btnVaultLocation = new System.Windows.Forms.Button();
            this.txtVaultLocation = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnMusicDir = new System.Windows.Forms.Button();
            this.txtBackgroundMusicLocation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAttractDir = new System.Windows.Forms.Button();
            this.txtAttractLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBackgroundImage = new System.Windows.Forms.Button();
            this.txtBackgroundImageLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuildDir = new System.Windows.Forms.Button();
            this.txtFinalUCELocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenGameROM = new System.Windows.Forms.Button();
            this.txtGameROM = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOpenEmulatorCore = new System.Windows.Forms.Button();
            this.txtEmulatorCore = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOpenBezelArt = new System.Windows.Forms.Button();
            this.txtBezelArt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOpenBoxArt = new System.Windows.Forms.Button();
            this.txtBoxArtFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dlgFolderBoxArt = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgFolderBezelArt = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgFolderCore = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgFolderRom = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgFolderBuilds = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgFolderBackgroundImage = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgFolderAttract = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgFolderMusic = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbUseTabs);
            this.groupBox1.Controls.Add(this.cbShowBuildWindow);
            this.groupBox1.Controls.Add(this.btnCreateVault);
            this.groupBox1.Controls.Add(this.btnVaultLocation);
            this.groupBox1.Controls.Add(this.txtVaultLocation);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnMusicDir);
            this.groupBox1.Controls.Add(this.txtBackgroundMusicLocation);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnAttractDir);
            this.groupBox1.Controls.Add(this.txtAttractLocation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBackgroundImage);
            this.groupBox1.Controls.Add(this.txtBackgroundImageLocation);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBuildDir);
            this.groupBox1.Controls.Add(this.txtFinalUCELocation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOpenGameROM);
            this.groupBox1.Controls.Add(this.txtGameROM);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnOpenEmulatorCore);
            this.groupBox1.Controls.Add(this.txtEmulatorCore);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnOpenBezelArt);
            this.groupBox1.Controls.Add(this.txtBezelArt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnOpenBoxArt);
            this.groupBox1.Controls.Add(this.txtBoxArtFile);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 517);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default Directories";
            // 
            // cbUseTabs
            // 
            this.cbUseTabs.AutoSize = true;
            this.cbUseTabs.Location = new System.Drawing.Point(38, 477);
            this.cbUseTabs.Name = "cbUseTabs";
            this.cbUseTabs.Size = new System.Drawing.Size(262, 17);
            this.cbUseTabs.TabIndex = 68;
            this.cbUseTabs.Text = "Use Tabs for USB View (Alpha - Requires Restart)";
            this.cbUseTabs.UseVisualStyleBackColor = true;
            // 
            // cbShowBuildWindow
            // 
            this.cbShowBuildWindow.AutoSize = true;
            this.cbShowBuildWindow.Location = new System.Drawing.Point(38, 441);
            this.cbShowBuildWindow.Name = "cbShowBuildWindow";
            this.cbShowBuildWindow.Size = new System.Drawing.Size(182, 17);
            this.cbShowBuildWindow.TabIndex = 67;
            this.cbShowBuildWindow.Text = "Show Build Window (Debugging)";
            this.cbShowBuildWindow.UseVisualStyleBackColor = true;
            // 
            // btnCreateVault
            // 
            this.btnCreateVault.Location = new System.Drawing.Point(518, 49);
            this.btnCreateVault.Name = "btnCreateVault";
            this.btnCreateVault.Size = new System.Drawing.Size(150, 23);
            this.btnCreateVault.TabIndex = 66;
            this.btnCreateVault.Text = "Create Vault";
            this.btnCreateVault.UseVisualStyleBackColor = true;
            this.btnCreateVault.Click += new System.EventHandler(this.btnCreateVault_Click);
            // 
            // btnVaultLocation
            // 
            this.btnVaultLocation.Location = new System.Drawing.Point(369, 49);
            this.btnVaultLocation.Name = "btnVaultLocation";
            this.btnVaultLocation.Size = new System.Drawing.Size(131, 23);
            this.btnVaultLocation.TabIndex = 65;
            this.btnVaultLocation.Text = "Choose Vault Location...";
            this.btnVaultLocation.UseVisualStyleBackColor = true;
            this.btnVaultLocation.Click += new System.EventHandler(this.btnVaultLocation_Click);
            // 
            // txtVaultLocation
            // 
            this.txtVaultLocation.Location = new System.Drawing.Point(38, 51);
            this.txtVaultLocation.Name = "txtVaultLocation";
            this.txtVaultLocation.Size = new System.Drawing.Size(311, 20);
            this.txtVaultLocation.TabIndex = 64;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "UCE Vault location:";
            // 
            // btnMusicDir
            // 
            this.btnMusicDir.Location = new System.Drawing.Point(518, 381);
            this.btnMusicDir.Name = "btnMusicDir";
            this.btnMusicDir.Size = new System.Drawing.Size(150, 23);
            this.btnMusicDir.TabIndex = 62;
            this.btnMusicDir.Text = "Choose Music Dir...";
            this.btnMusicDir.UseVisualStyleBackColor = true;
            this.btnMusicDir.Click += new System.EventHandler(this.btnMusicDir_Click);
            // 
            // txtBackgroundMusicLocation
            // 
            this.txtBackgroundMusicLocation.Location = new System.Drawing.Point(38, 385);
            this.txtBackgroundMusicLocation.Name = "txtBackgroundMusicLocation";
            this.txtBackgroundMusicLocation.Size = new System.Drawing.Size(462, 20);
            this.txtBackgroundMusicLocation.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 369);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 13);
            this.label8.TabIndex = 60;
            this.label8.Text = "Background Music Location:";
            // 
            // btnAttractDir
            // 
            this.btnAttractDir.Location = new System.Drawing.Point(518, 342);
            this.btnAttractDir.Name = "btnAttractDir";
            this.btnAttractDir.Size = new System.Drawing.Size(150, 23);
            this.btnAttractDir.TabIndex = 59;
            this.btnAttractDir.Text = "Choose Attract Dir...";
            this.btnAttractDir.UseVisualStyleBackColor = true;
            this.btnAttractDir.Click += new System.EventHandler(this.btnAttractDir_Click);
            // 
            // txtAttractLocation
            // 
            this.txtAttractLocation.Location = new System.Drawing.Point(38, 346);
            this.txtAttractLocation.Name = "txtAttractLocation";
            this.txtAttractLocation.Size = new System.Drawing.Size(462, 20);
            this.txtAttractLocation.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Attract Video Location:";
            // 
            // btnBackgroundImage
            // 
            this.btnBackgroundImage.Location = new System.Drawing.Point(518, 301);
            this.btnBackgroundImage.Name = "btnBackgroundImage";
            this.btnBackgroundImage.Size = new System.Drawing.Size(150, 23);
            this.btnBackgroundImage.TabIndex = 56;
            this.btnBackgroundImage.Text = "Choose Background Dir...";
            this.btnBackgroundImage.UseVisualStyleBackColor = true;
            this.btnBackgroundImage.Click += new System.EventHandler(this.btnBackgroundImage_Click);
            // 
            // txtBackgroundImageLocation
            // 
            this.txtBackgroundImageLocation.Location = new System.Drawing.Point(38, 305);
            this.txtBackgroundImageLocation.Name = "txtBackgroundImageLocation";
            this.txtBackgroundImageLocation.Size = new System.Drawing.Size(462, 20);
            this.txtBackgroundImageLocation.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Background Image Location:";
            // 
            // btnBuildDir
            // 
            this.btnBuildDir.Location = new System.Drawing.Point(518, 262);
            this.btnBuildDir.Name = "btnBuildDir";
            this.btnBuildDir.Size = new System.Drawing.Size(150, 23);
            this.btnBuildDir.TabIndex = 53;
            this.btnBuildDir.Text = "Choose Build Dir...";
            this.btnBuildDir.UseVisualStyleBackColor = true;
            this.btnBuildDir.Click += new System.EventHandler(this.btnFinalUCELocation_Click);
            // 
            // txtFinalUCELocation
            // 
            this.txtFinalUCELocation.Location = new System.Drawing.Point(38, 266);
            this.txtFinalUCELocation.Name = "txtFinalUCELocation";
            this.txtFinalUCELocation.Size = new System.Drawing.Size(462, 20);
            this.txtFinalUCELocation.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Finale UCE Location (root):";
            // 
            // btnOpenGameROM
            // 
            this.btnOpenGameROM.Location = new System.Drawing.Point(518, 223);
            this.btnOpenGameROM.Name = "btnOpenGameROM";
            this.btnOpenGameROM.Size = new System.Drawing.Size(150, 23);
            this.btnOpenGameROM.TabIndex = 50;
            this.btnOpenGameROM.Text = "Choose ROM...";
            this.btnOpenGameROM.UseVisualStyleBackColor = true;
            this.btnOpenGameROM.Click += new System.EventHandler(this.btnOpenGameROM_Click);
            // 
            // txtGameROM
            // 
            this.txtGameROM.Location = new System.Drawing.Point(38, 227);
            this.txtGameROM.Name = "txtGameROM";
            this.txtGameROM.Size = new System.Drawing.Size(462, 20);
            this.txtGameROM.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Default Game ROM location:";
            // 
            // btnOpenEmulatorCore
            // 
            this.btnOpenEmulatorCore.Location = new System.Drawing.Point(518, 179);
            this.btnOpenEmulatorCore.Name = "btnOpenEmulatorCore";
            this.btnOpenEmulatorCore.Size = new System.Drawing.Size(150, 23);
            this.btnOpenEmulatorCore.TabIndex = 47;
            this.btnOpenEmulatorCore.Text = "Choose Core...";
            this.btnOpenEmulatorCore.UseVisualStyleBackColor = true;
            this.btnOpenEmulatorCore.Click += new System.EventHandler(this.btnOpenEmulatorCore_Click);
            // 
            // txtEmulatorCore
            // 
            this.txtEmulatorCore.Location = new System.Drawing.Point(38, 183);
            this.txtEmulatorCore.Name = "txtEmulatorCore";
            this.txtEmulatorCore.Size = new System.Drawing.Size(462, 20);
            this.txtEmulatorCore.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Default Emulator Core location:";
            // 
            // btnOpenBezelArt
            // 
            this.btnOpenBezelArt.Location = new System.Drawing.Point(518, 136);
            this.btnOpenBezelArt.Name = "btnOpenBezelArt";
            this.btnOpenBezelArt.Size = new System.Drawing.Size(150, 23);
            this.btnOpenBezelArt.TabIndex = 44;
            this.btnOpenBezelArt.Text = "Choose Bezel Art...";
            this.btnOpenBezelArt.UseVisualStyleBackColor = true;
            this.btnOpenBezelArt.Click += new System.EventHandler(this.btnOpenBezelArt_Click);
            // 
            // txtBezelArt
            // 
            this.txtBezelArt.Location = new System.Drawing.Point(38, 140);
            this.txtBezelArt.Name = "txtBezelArt";
            this.txtBezelArt.Size = new System.Drawing.Size(462, 20);
            this.txtBezelArt.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Default Bezel Art location:";
            // 
            // btnOpenBoxArt
            // 
            this.btnOpenBoxArt.Location = new System.Drawing.Point(518, 94);
            this.btnOpenBoxArt.Name = "btnOpenBoxArt";
            this.btnOpenBoxArt.Size = new System.Drawing.Size(150, 23);
            this.btnOpenBoxArt.TabIndex = 41;
            this.btnOpenBoxArt.Text = "Choose Box Art...";
            this.btnOpenBoxArt.UseVisualStyleBackColor = true;
            this.btnOpenBoxArt.Click += new System.EventHandler(this.btnOpenBoxArt_Click);
            // 
            // txtBoxArtFile
            // 
            this.txtBoxArtFile.Location = new System.Drawing.Point(38, 97);
            this.txtBoxArtFile.Name = "txtBoxArtFile";
            this.txtBoxArtFile.Size = new System.Drawing.Size(462, 20);
            this.txtBoxArtFile.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Default Box Art location:";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(510, 569);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(141, 571);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dlgSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 604);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.dlgSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenGameROM;
        private System.Windows.Forms.TextBox txtGameROM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOpenEmulatorCore;
        private System.Windows.Forms.TextBox txtEmulatorCore;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOpenBezelArt;
        private System.Windows.Forms.TextBox txtBezelArt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOpenBoxArt;
        private System.Windows.Forms.TextBox txtBoxArtFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuildDir;
        private System.Windows.Forms.TextBox txtFinalUCELocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBoxArt;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBezelArt;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderCore;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderRom;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBuilds;
        private System.Windows.Forms.Button btnMusicDir;
        private System.Windows.Forms.TextBox txtBackgroundMusicLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAttractDir;
        private System.Windows.Forms.TextBox txtAttractLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBackgroundImage;
        private System.Windows.Forms.TextBox txtBackgroundImageLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBackgroundImage;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderAttract;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderMusic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreateVault;
        private System.Windows.Forms.Button btnVaultLocation;
        private System.Windows.Forms.TextBox txtVaultLocation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbShowBuildWindow;
        private System.Windows.Forms.CheckBox cbUseTabs;
    }
}