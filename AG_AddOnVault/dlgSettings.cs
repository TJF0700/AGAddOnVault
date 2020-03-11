using AG_AddOnTool.Models;
using Koden.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AG_AddOnTool
{
    public partial class dlgSettings : Form
    {
        public dlgSettings()
        {
            InitializeComponent();
        }
        private void dlgSettings_Load(object sender, EventArgs e)
        {
            PopulateSettingsTextBoxes();
        }

        private void PopulateSettingsTextBoxes()
        {
            txtVaultLocation.Text = BLL._Settings.DefaultFolder_UCE_Vault;
            txtBezelArt.Text = BLL._Settings.DefaultFolder_BezelArt;
            txtBoxArtFile.Text = BLL._Settings.DefaultFolder_BoxArt;
            txtEmulatorCore.Text = BLL._Settings.DefaultFolder_Cores;
            txtGameROM.Text = BLL._Settings.DefaultFolder_ROMS;
            txtFinalUCELocation.Text = BLL._Settings.DefaultFolder_USBRoot;
            txtBackgroundMusicLocation.Text = BLL._Settings.DefaultFolder_BackgroundMusic;
            txtBackgroundImageLocation.Text = BLL._Settings.DefaultFolder_BackgroundImage;
            txtAttractLocation.Text = BLL._Settings.DefaultFolder_AttractVideo;
            cbShowBuildWindow.Checked = BLL._Settings.ShowBuildWindow;
            cbUseTabs.Checked = BLL._Settings.UseTabs;
        }

        internal string GetFolderFromDialog()
        {
            using (FolderBrowserDialog openFolderDialog = new FolderBrowserDialog())
            {
                if (openFolderDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        return openFolderDialog.SelectedPath;
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
                }
            }
            return "";
        }
        private void btnOpenBoxArt_Click(object sender, EventArgs e)
        {
            var retVal = GetFolderFromDialog();
            txtBoxArtFile.Text = retVal == "" ? txtBoxArtFile.Text : retVal;
           
        }

        private void btnOpenBezelArt_Click(object sender, EventArgs e)
        {
            var retVal = GetFolderFromDialog();
            txtBezelArt.Text = retVal == "" ? txtBezelArt.Text : retVal;
            
        }

        private void btnOpenEmulatorCore_Click(object sender, EventArgs e)
        {
            var retVal = GetFolderFromDialog();
            txtEmulatorCore.Text = retVal == "" ? txtEmulatorCore.Text : retVal;
            
        }

        private void btnOpenGameROM_Click(object sender, EventArgs e)
        {
            var retVal = GetFolderFromDialog();
            txtGameROM.Text = retVal == "" ? txtGameROM.Text : retVal;
            
        }


        private void btnBackgroundImage_Click(object sender, EventArgs e)
        {
            var retVal = GetFolderFromDialog();
            txtBackgroundImageLocation.Text = retVal == "" ? txtBackgroundImageLocation.Text : retVal;
            
        }

        private void btnAttractDir_Click(object sender, EventArgs e)
        {
            var retVal = GetFolderFromDialog();
            txtAttractLocation.Text = retVal == "" ? txtAttractLocation.Text : retVal;

        }

        private void btnMusicDir_Click(object sender, EventArgs e)
        {
            var retVal = GetFolderFromDialog();
            txtBackgroundMusicLocation.Text = retVal == "" ? txtBackgroundMusicLocation.Text : retVal;
        }

        private void btnVaultLocation_Click(object sender, EventArgs e)
        {
            var retVal = GetFolderFromDialog();
            txtVaultLocation.Text = retVal == "" ? txtVaultLocation.Text : retVal;
        }

        private void btnCreateVault_Click(object sender, EventArgs e)
        {
            BLL._Settings = new AppSettings(txtVaultLocation.Text, true);
            PopulateSettingsTextBoxes();
            try
            {
                BLL._Settings.kSaveToJsonFile("ASettings.json");
            }
            catch (Exception ex)
            {
                var t = ex.kGetAllMessages();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BLL._Settings.DefaultFolder_UCE_Vault = txtVaultLocation.Text;
            BLL._Settings.DefaultFolder_Cores = txtEmulatorCore.Text;
            BLL._Settings.DefaultFolder_BoxArt = txtBoxArtFile.Text;
            BLL._Settings.DefaultFolder_BezelArt = txtBezelArt.Text;
            BLL._Settings.DefaultFolder_ROMS = txtGameROM.Text;
            BLL._Settings.DefaultFolder_AttractVideo = txtAttractLocation.Text;
            BLL._Settings.DefaultFolder_BackgroundImage = txtBackgroundImageLocation.Text;
            BLL._Settings.DefaultFolder_USBRoot = txtFinalUCELocation.Text;
            BLL._Settings.DefaultFolder_Working = txtVaultLocation.Text + "\\Working";
            BLL._Settings.ShowBuildWindow = cbShowBuildWindow.Checked;
            BLL._Settings.UseTabs = cbUseTabs.Checked;
            BLL._Settings.UserOverlay = false;
            BLL._Settings.kSaveToJsonFile("ASettings.json");

        }

        private void btnFinalUCELocation_Click(object sender, EventArgs e)
        {
            var retVal = GetFolderFromDialog();
            txtFinalUCELocation.Text = retVal == "" ? txtFinalUCELocation.Text : retVal;
        }
    }
}
