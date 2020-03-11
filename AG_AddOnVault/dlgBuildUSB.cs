using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AG_AddOnVault
{
    public partial class dlgBuildUSB : Form
    {
        public string DriveLetter { get; set; }
        public bool WipeDrive { get; set; }
        public dlgBuildUSB()
        {
            InitializeComponent();
        }

        private void dlgBuildUSB_Load(object sender, EventArgs e)
        {
            var driveLetters = from driveInfo in DriveInfo.GetDrives()
                               where driveInfo.DriveType == DriveType.Removable && driveInfo.IsReady
                               select driveInfo.RootDirectory.FullName;

            cboDriveLetters.Items.AddRange(driveLetters.ToArray());

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DriveLetter = cboDriveLetters.SelectedItem.ToString();
            WipeDrive = cbWipeDrive.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
