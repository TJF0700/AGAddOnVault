namespace AG_AddOnVault
{
    partial class dlgBuildUSB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgBuildUSB));
            this.cboDriveLetters = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbWipeDrive = new System.Windows.Forms.CheckBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboDriveLetters
            // 
            this.cboDriveLetters.FormattingEnabled = true;
            this.cboDriveLetters.Location = new System.Drawing.Point(140, 30);
            this.cboDriveLetters.Name = "cboDriveLetters";
            this.cboDriveLetters.Size = new System.Drawing.Size(59, 21);
            this.cboDriveLetters.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose USB Drive:";
            // 
            // cbWipeDrive
            // 
            this.cbWipeDrive.AutoSize = true;
            this.cbWipeDrive.Location = new System.Drawing.Point(140, 58);
            this.cbWipeDrive.Name = "cbWipeDrive";
            this.cbWipeDrive.Size = new System.Drawing.Size(98, 17);
            this.cbWipeDrive.TabIndex = 2;
            this.cbWipeDrive.Text = "Wipe Drive first";
            this.cbWipeDrive.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(192, 90);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create &USB";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(45, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "&Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dlgBuildUSB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 149);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cbWipeDrive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDriveLetters);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgBuildUSB";
            this.Text = "Build AG USB Drive";
            this.Load += new System.EventHandler(this.dlgBuildUSB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDriveLetters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbWipeDrive;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button button1;
    }
}