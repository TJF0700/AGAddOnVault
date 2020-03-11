using AG_AddOnTool.Extensions;
using AG_AddOnTool.KryptonGrid;
using AG_AddOnTool.Models;
using AG_AddOnVault;
using ComponentFactory.Krypton.Toolkit;
using Koden.Utils.Extensions;
using KryptonOutlookGrid.Classes;
using KryptonOutlookGrid.CustomColumns;
using KryptonOutlookGrid.Formatting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FillMode = KryptonOutlookGrid.Classes.FillMode;

namespace AG_AddOnTool
{
    public partial class frmMainTabs : Form
    {
        CustomToolTip myToolTip = new CustomToolTip();
        int _currentMouseOverRow = -1;

        public frmMainTabs()
        {
            InitializeComponent();
            
            cbResizeImages.Visible = false;
            cbVUseInternalCore.Visible = false;

            BLL.LoadSettings(true);
            
            if (string.IsNullOrEmpty(BLL._Settings.DefaultFolder_UCE_Vault))
            {
                var retVal = new dlgSettings().ShowDialog();
            }
            PopulateGenres();
            SetupKryptonGrid();
            LoadVault();
        }

        private void SetupKryptonGrid()
        {
            kryptonGrid.GroupBox = kryptonGroupBox;
            kryptonGrid.RegisterGroupBoxEvents();

            var setup = new KryptonGridSetup();
            setup.SetupDataGridView(this.kryptonGrid, true);

            kryptonGrid.ShowLines = true;
        }

        /// <summary>Gets the genres for the combobox/menu items.</summary>
        private void PopulateGenres()
        {

            var Dir = BLL._Settings.DefaultFolder_USBRoot;
            string[] subdirectoryEntries = Directory.GetDirectories(Dir);
            foreach (var subdirectory in subdirectoryEntries)
            {
                DirectoryInfo di = new DirectoryInfo(subdirectory);

                if (!di.Name.StartsWith("ha8800_")) cboVGenre.Items.Add(di.Name);
            }

        }




        /// <summary>Removes the file.</summary>
        /// <param name="checkFile">The check file.</param>
        /// <returns></returns>
        private bool RemoveFile(string checkFile)
        {
            try
            {
                if (File.Exists(checkFile))
                {
                    File.Delete(checkFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on Remove File: {ex.kGetAllMessages()}");
                return false;

            }
            return true;
        }



        private MenuItem PopulateGenreForRowMenu(MenuItem rootElemMove, string currentGenre)
        {


            var Dir = BLL._Settings.DefaultFolder_USBRoot;
            string[] subdirectoryEntries = Directory.GetDirectories(Dir);
            foreach (var subdirectory in subdirectoryEntries)
            {
                DirectoryInfo di = new DirectoryInfo(subdirectory);

                if (!di.Name.StartsWith("ha8800_") &&
                    !di.Name.StartsWith("USB") &&
                    !di.Name.Equals(currentGenre))
                {
                    var krootElemTitle = new MenuItem()
                    {
                        Tag = di.FullName,
                        Text = di.Name
                    };

                    krootElemTitle.Click += kRootElemTitle_Click;
                    rootElemMove.MenuItems.Add(krootElemTitle);
                }
            }
            return rootElemMove;
        }



        private void ModTabNum(TabPage selTab, int count)
        {
            // var selTab = tabCon.TabPages[mnuItem];
            int totNum = 0;
            if (selTab.Text.Contains("("))
            {
                totNum = Convert.ToInt32(selTab.Text.Split('(', ')')[1]);
                selTab.Text = selTab.Text.Split('(')[0];
                totNum = totNum + count;
            }
            else { totNum = 1; }

            selTab.Text = $"{selTab.Text}({totNum})";
        }


        private void LoadSubDirectories(string dir)
        {
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            foreach (string subdirectory in subdirectoryEntries)
            {
                DirectoryInfo di = new DirectoryInfo(subdirectory);
                var flow = AddNewTab(di);
                UpdateProgress();
            }
        }

        private void LoadFiles(string subdirectory, TabPage tabPage, FlowLayoutPanel flowCon)
        {
            string[] Files = Directory.GetFiles(subdirectory, "*.*");
            try
            {
                // Loop through them to see files  
                foreach (string file in Files)
                {
                    PictureBox picBox = GetCartImageForLayout(file);

                    flowCon.Controls.Add(picBox);
                    UpdateProgress();
                }
                if (Files.Any())
                {
                    tabPage.Font = new Font("Calibri Bold", 18, FontStyle.Bold);
                    tabPage.Text = $"{tabPage.Text}({Files.Count()})";
                    Rectangle tabBounds = tabCon.GetTabRect(tabCon.TabPages.IndexOf(tabPage));
                    tabPage.SetBounds(tabBounds.X, 20, (12 * tabPage.Text.Length), tabBounds.Height * 4);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Occured on genre load: {ex.kGetAllMessages()}");
            }

        }


        private PictureBox GetCartImageForLayout(string file)
        {
            FileInfo fi = new FileInfo(file);
            NodeInfo ni = BLL.GetNodeInfo(fi);
            var picBox = new PictureBox
            {
                Size = new Size(133, 183),
                Name = fi.Name,
                BorderStyle = BorderStyle.Fixed3D,
                Image = ni.BoxArt,
                SizeMode = PictureBoxSizeMode.Zoom,
                Tag = ni
            };

            picBox.ContextMenuStrip = this.mnuMoveToGenre;
            picBox.MouseHover += new System.EventHandler(this.picBox_MouseHoverHandler);
            picBox.Paint += this.picBox_Paint;
            return picBox;
        }


        private void UpdateProgress()
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
                int percent = (int)((progressBar1.Value / (double)progressBar1.Maximum) * 100);
                progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));

                Application.DoEvents();
            }
        }
        private FlowLayoutPanel AddFlowPanel(DirectoryInfo di, TabPage selTab, string tabName)
        {

            selTab.AllowDrop = true;

            FlowLayoutPanel fPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Name = tabName + "_Container",
                Font = new Font("Calibri", 18),
                FlowDirection = FlowDirection.LeftToRight,
                BorderStyle = BorderStyle.Fixed3D,
                ForeColor = Color.BlueViolet,
                BackColor = Color.LightGray,
                Visible = true,
                AllowDrop = true,
                AutoScroll = true,
                Tag = di
            };
            // Adding this control to the form 
            fPanel.DragEnter += flow_DragEnter;
            fPanel.DragDrop += flow_DragDrop;
            selTab.Controls.Add(fPanel);
            return fPanel;
        }

        private void AddNewCartToLayout(string UCEFilename, VaultRecordCSV_ViewModel vCart)
        {
            var newPic = GetCartImageForLayout(UCEFilename);

            if (tabCon.Controls.Find(vCart.Genre + "_Container", true).FirstOrDefault() is FlowLayoutPanel fPanel)
            {

            }
        }

        private FlowLayoutPanel AddNewTab(DirectoryInfo di)
        {

            var tabName = di.Name;
            FlowLayoutPanel fPanel = null;

            if (!tabName.StartsWith("ha8800_"))
            {
                tabCon.TabPages.Add(tabName, di.Name);
                var selTab = tabCon.TabPages[tabName];
                fPanel = AddFlowPanel(di, selTab, tabName);

                LoadFiles(di.FullName, selTab, fPanel);
            }


            return fPanel;
        }


        public static Control FindControlAtPoint(Control container, Point pos)
        {
            Control child;
            foreach (Control c in container.Controls)
            {
                if (c.Visible && c.Bounds.Contains(pos))
                {
                    child = FindControlAtPoint(c, new Point(pos.X - c.Left, pos.Y - c.Top));
                    if (child == null) return c;
                    else return child;
                }
            }
            return null;
        }
        public static Control FindControlAtCursor(Form form)
        {
            Point pos = Cursor.Position;
            if (form.Bounds.Contains(pos))
                return FindControlAtPoint(form, form.PointToClient(pos));
            return null;
        }


        private void LoadBezelArt(string fName)
        {
            picVBezelArt.Image = null;
            if (!string.IsNullOrEmpty(fName))
            {
                if (File.Exists(fName))
                {
                    Image img = Image.FromFile(fName);
                    picVBezelArt.Image = img;
                    picVBezelArt.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }

        }

        private void LoadBoxArt(string fName)
        {
            picVBoxArt.Image = null;
            if (!string.IsNullOrEmpty(fName))
            {
                if (File.Exists(fName))
                {
                    Image img = Image.FromFile(fName);
                    picVBoxArt.Image = img;
                    picVBoxArt.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private VaultRecordCSV_ViewModel ImportUCEs(string[] fileNames)
        {
            VaultRecordCSV_ViewModel explodedCart = new VaultRecordCSV_ViewModel();
            foreach (var UCEFile in fileNames)
            {
                try
                {
                    explodedCart = BLL.ExplodeUCE(UCEFile, "Unknown", true);
                    var vaultFile = $"{BLL._Settings.DefaultFolder_USBRoot}\\{explodedCart.Genre}\\AddOn_{explodedCart.Title}.UCE";
                    bool doCopy = true;
                    if (File.Exists(vaultFile))
                    {
                        var dlgResult = MessageBox.Show("File exists, do you wish to overwrite?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        doCopy = dlgResult == DialogResult.Yes;
                    }

                    if (doCopy)
                    {
                        File.Copy(UCEFile, vaultFile, true);
                        BLL._VaultRecords = BLL._VaultRecords.AddRecord(explodedCart, false);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{UCEFile}: {ex.kGetAllMessages()}", "Error on Explode UCE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            LoadVault(true);
            return explodedCart;
        }



        #region Events


        private void importUCEFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = $"{BLL._Settings.DefaultFolder_USBRoot}";
                openFileDialog.Filter = "UCE files (*.UCE)|*.UCE";
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Select File(s) to import";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        var explodedCart = ImportUCEs(openFileDialog.FileNames);
                        if (openFileDialog.FileNames.Length == 1)
                        {
                            ClearCartridgeProfile();
                            PopulateCartridgeProfile(explodedCart);
                        }
                        LoadVault(true);
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
                }
            }
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new dlgSettings();
            var retVal = dlg.ShowDialog();
        }


        private void buildUSBToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (var dlg = new dlgBuildUSB())
            {
                var result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    progressBar1.Value = 0;
                    var source_dir = BLL._Settings.DefaultFolder_USBRoot;
                    var destination_dir = dlg.DriveLetter;
                    var wipeDrive = dlg.WipeDrive;
                    progressBar1.Maximum = Directory.GetFiles(source_dir, "*.UCE", SearchOption.AllDirectories).Length + Directory.GetDirectories(source_dir, "**", SearchOption.AllDirectories).Length;

                    try
                    {
                        foreach (string dir in Directory.GetDirectories(source_dir, "*", SearchOption.AllDirectories))
                        {
                            if (!Directory.Exists(Path.Combine(destination_dir, dir.Substring(source_dir.Length + 1))))
                            {
                                Directory.CreateDirectory(Path.Combine(destination_dir, dir.Substring(source_dir.Length + 1)));
                            }
                            UpdateProgress();
                        }

                        foreach (string file_name in Directory.GetFiles(source_dir, "*.UCE", SearchOption.AllDirectories))
                        {
                            if (!File.Exists(Path.Combine(destination_dir, file_name.Substring(source_dir.Length + 1))) || wipeDrive)
                            {
                                File.Copy(file_name, Path.Combine(destination_dir, file_name.Substring(source_dir.Length + 1)), true);
                            }
                            UpdateProgress();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error Occured: {ex.kGetAllMessages()}");
                    }
                    UpdateProgress();
                    MessageBox.Show("Completed Build - have fun!");
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new dlgAbout();
            dlg.ShowDialog();
        }

        private void kryptonGrid_DoubleClick(object sender, EventArgs e)
        {
            if (((KryptonOutlookGrid.Classes.KryptonOutlookGrid)sender).CurrentRow is OutlookGridRow row)
            {
                if (!row.IsGroupRow)
                {
                    PopulateCartridgeProfile(row);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            ClearCartridgeProfile();
        }

        private void ClearBezelArt()
        {
            this.picVBezelArt.Image = null;
        }

        private void ClearCoverArt()
        {
            this.picVBoxArt.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            var isUpdate = false;
            int wIndex = -1;
            var vCart = PopulateCartridgeModel();
            if (txtVIndex.Text.Any() && Convert.ToInt32(txtVIndex.Text) > 0)
            {
                isUpdate = true;
                vCart.Index = Convert.ToInt32(txtVIndex.Text);
                BLL._VaultRecords.UpdateRecord(vCart, true);
            }
            else
            {
                int? lstIndex = BLL._VaultRecords.LastOrDefault()?.Index;
                //Last index in file + 1 for added record
                if (lstIndex != null) vCart.Index = (int)lstIndex + 1;
                BLL._VaultRecords.AddRecord(vCart, true);
            }

        }
        private void splitContainer2_Panel1_DragDrop(object sender, DragEventArgs e)
        {
            // Explode the UCE file!
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                VaultRecordCSV_ViewModel explodedCart;
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                explodedCart = ImportUCEs(filePaths);
                if (filePaths.Length == 1)
                {
                    ClearCartridgeProfile();
                    PopulateCartridgeProfile(explodedCart);
                }
                LoadVault(true);

            }
        }


        private void splitContainer2_Panel1_DragEnter(object sender, DragEventArgs e)
        {
            bool allowDrop = true;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string fileLoc in filePaths)
                {
                    if (Path.GetExtension(fileLoc).ToLower() != ".uce")
                    {
                        allowDrop = false;
                        break;
                    }
                }

                e.Effect = (allowDrop ? DragDropEffects.Copy : DragDropEffects.None);

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void kRootElemTitle_Click(object sender, EventArgs e)
        {
            var mnuItem = sender as MenuItem;

            if (kryptonGrid.SelectedRows.Count > 1)
            {
                foreach (DataGridViewRow row in kryptonGrid.SelectedRows)
                {
                    var vIndex = Convert.ToInt32(row.Cells["ColumnIndex"].Value);
                    var vCart = PopulateCartridgeModel(row);
                    MoveCartToNewGenre(vCart, mnuItem.Text, false);
                }

                BLL._VaultRecords.kSaveToCSVFile(BLL._Settings.TheVault);

            }
            else //Single row selection by right-mouse click
                 if (kryptonGrid.Rows[_currentMouseOverRow] is DataGridViewRow row)
            {
                var vCart = PopulateCartridgeModel(row);
                MoveCartToNewGenre(vCart, mnuItem.Text, true);
            }
            //Refresh the grid
            LoadVault(true);

        }

        private void MoveCartToNewGenre(VaultRecordCSV_ViewModel vCart, string newGenre, bool persist = true)
        {
            var UCEFile = $"{BLL._Settings.DefaultFolder_USBRoot}\\{vCart.Genre}\\AddOn_{vCart.Title}.UCE";
            bool doCopy = true;
            if (File.Exists(UCEFile))
            {
                var NewGenreFile = $"{BLL._Settings.DefaultFolder_USBRoot}\\{newGenre}\\AddOn_{vCart.Title}.UCE";
                if (File.Exists(NewGenreFile))
                {
                    var dlgResult = MessageBox.Show("UCE Already exists in Genre, do you wish to overwrite?", "UCE Already Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    doCopy = dlgResult == DialogResult.Yes;
                }
                if (doCopy)
                {

                    File.Copy(UCEFile, NewGenreFile, true);
                    File.Delete(UCEFile);
                    vCart.Genre = newGenre;

                    BLL._VaultRecords = BLL._VaultRecords.UpdateRecord(vCart, persist);
                }
            }
        }

        private void RootElemTitle1_Click(object sender, EventArgs e)
        {
            var mnuItem = (ToolStripMenuItem)sender;
            try
            {
                if ((((ContextMenuStrip)(((ToolStripMenuItem)sender).Owner)).SourceControl) is PictureBox picBox)
                {
                    if (picBox.Tag is NodeInfo nInfo)
                    {
                        var fName = Path.GetFileName(nInfo.FullName);
                        File.Copy(nInfo.FullName, $"{(string)mnuItem.Tag}\\{fName}", true);
                        if (File.Exists($"{(string)mnuItem.Tag}\\{fName}"))
                        {
                            File.Delete(nInfo.FullName);
                            picBox.Parent.Controls.Remove(picBox);

                            if (tabCon.Controls.Find(mnuItem.Text + "_Container", true).FirstOrDefault() is FlowLayoutPanel fPanel)
                            {
                                nInfo.FullName = $"{(string)mnuItem.Tag}\\{fName}";
                                picBox.Tag = nInfo;
                                fPanel.Controls.Add(picBox);
                                ModTabNum(tabCon.TabPages[mnuItem.Text], 1);
                                ModTabNum(tabCon.SelectedTab, -1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Occured: {ex.kGetAllMessages()}");
            }
        }
        private void frmMainTabs_Load(object sender, EventArgs e)
        {
            if (BLL._Settings.UseTabs)
            {
                progressBar1.Value = 0;

                tabCon.TabPages.Add("ha8800_background", "Backgrounds");
                DirectoryInfo di = new DirectoryInfo($"{BLL._Settings.DefaultFolder_USBRoot}\\ha8800_background");
                var selTab = tabCon.TabPages["ha8800_background"];
                AddFlowPanel(di, selTab, "ha8800_background");

                tabCon.TabPages.Add("ha8800_screensaver", "Attract Mode Videos");
                di = new DirectoryInfo($"{BLL._Settings.DefaultFolder_USBRoot}\\ha8800_screensaver");
                selTab = tabCon.TabPages["ha8800_screensaver"];
                AddFlowPanel(di, selTab, "ha8800_screensaver");
                try
                {
                    var Dir = $"{BLL._Settings.DefaultFolder_USBRoot}";
                    if ((!string.IsNullOrEmpty(Dir) && Directory.Exists(Dir)))
                    {
                        progressBar1.Maximum = Directory.GetFiles(Dir, "*.*", SearchOption.AllDirectories).Length + Directory.GetDirectories(Dir, "**", SearchOption.AllDirectories).Length;
                        LoadSubDirectories(Dir);
                    }
                    else
                        MessageBox.Show("No Default ALU Builds directory!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Occured on genre load: {ex.kGetAllMessages()}");
                }
            }
        }
        void picBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var overLayFName = BLL.GetOverLayFileName(txtVCore.Text);
            if (File.Exists(overLayFName))
            {
                Image img = Image.FromFile(overLayFName);
                g.DrawImage(img, 50, 105, 50, 50);
            }
        }

        private void picBox_MouseHoverHandler(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;
            myToolTip.NInfo = (NodeInfo)pb.Tag;
            myToolTip.SetToolTip(pb, "ROM");
        }
        private void flow_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string fileLoc in filePaths)
                {
                    if (FindControlAtCursor(this) is FlowLayoutPanel fPanel)
                    {
                        var destFile =
                            $"{((DirectoryInfo)fPanel.Tag).FullName}\\{Path.GetFileName(fileLoc)}";
                        File.Copy(fileLoc, destFile, true);

                        if (File.Exists(destFile))
                        {
                            PictureBox picBox = GetCartImageForLayout(destFile);
                            fPanel.Controls.Add(picBox);
                            //ModTabNum(tabCon.TabPages[mnuItem.Text], 1);
                            //ModTabNum(tabCon.SelectedTab, -1);
                        }
                    }

                }
            }
        }

        private void flow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void vBuildAllUCE_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in kryptonGrid.SelectedRows)
            {
                var vCart = PopulateCartridgeModel(row);

                var UCEFilename = BuildUCE(vCart);
                if (!string.IsNullOrEmpty(UCEFilename))
                {
                    AddNewCartToLayout(UCEFilename, vCart);
                }
            }

            MessageBox.Show("Completed build of UCE(s)!");
        }

        private void vBuildUCE_Click(object sender, EventArgs e)
        {

            if (kryptonGrid.Rows[_currentMouseOverRow] is DataGridViewRow row)
            {
                var vCart = PopulateCartridgeModel(row);

                var UCEFilename = BuildUCE(vCart);
                if (!string.IsNullOrEmpty(UCEFilename))
                {
                    AddNewCartToLayout(UCEFilename, vCart);
                }
                MessageBox.Show($"Completed build of UCE at: {UCEFilename}!");
            }
            else
            {
                MessageBox.Show("Something went wrong on Build UCE! - No record found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void vRemItem_Click(object sender, EventArgs e)
        {
            if (kryptonGrid.Rows[_currentMouseOverRow] is DataGridViewRow row)
            {
                if ((MessageBox.Show($"Remove the Cartridge Configuration for {row.Cells["ColumnTitle"].Value} from the Vault?", "Remove Config",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {

                    var vIndex = Convert.ToInt32(row.Cells["ColumnIndex"].Value);
                    BLL._VaultRecords = BLL._VaultRecords.RemoveItemWithIndexOf(vIndex, true);
                    //BusinessLogic._VaultRecords.kSaveToCSVFile(BusinessLogic._Settings.TheVault);

                    LoadVault(true);
                }
            }
        }

        private void vRemAllSelected_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in kryptonGrid.SelectedRows)
            {
                var vIndex = Convert.ToInt32(row.Cells["ColumnIndex"].Value);
                BLL._VaultRecords = BLL._VaultRecords.RemoveItemWithIndexOf(vIndex);
            }
            BLL._VaultRecords.kSaveToCSVFile(BLL._Settings.TheVault);
            LoadVault(true);
        }
        /// <summary>Handles the MouseClick event of the kryptonGrid control.
        /// Builds the Context Menu on the fly based on row clicked</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void kryptonGrid_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                MenuItem rootElemMove = new MenuItem("Move to Genre");
                MenuItem rootRemove = new MenuItem("Remove");
                MenuItem rootBuild = new MenuItem("Build");

                _currentMouseOverRow = kryptonGrid.HitTest(e.X, e.Y).RowIndex;
                if (_currentMouseOverRow >= 0)
                {
                    //((KryptonOutlookGrid.Classes.OutlookGridRow)row).IsGroupRow
                    if (((KryptonOutlookGrid.Classes.KryptonOutlookGrid)sender).Rows[_currentMouseOverRow] is OutlookGridRow row)
                    {
                        if (!row.IsGroupRow)
                        {


                            rootElemMove = PopulateGenreForRowMenu(rootElemMove, row.Cells["ColumnGenre"].Value.ToString());
                            m.MenuItems.Add(rootElemMove);


                            var remItem = new MenuItem($"Build UCE for: {row.Cells["ColumnTitle"].Value.ToString()}...");
                            remItem.Click += vBuildUCE_Click;
                            rootBuild.MenuItems.Add(remItem);
                            remItem = new MenuItem($"Build UCE for All selected Cartridge Definitions");
                            remItem.Click += vBuildAllUCE_Click;
                            rootBuild.MenuItems.Add(remItem);
                            m.MenuItems.Add(rootBuild);

                            remItem = new MenuItem($"Remove Cartridge Definition for: {row.Cells["ColumnTitle"].Value.ToString()}");
                            remItem.Click += vRemItem_Click;
                            rootRemove.MenuItems.Add(remItem);
                            remItem = new MenuItem($"Remove All selected Cartridge Definitions");
                            remItem.Click += vRemAllSelected_Click;
                            rootRemove.MenuItems.Add(remItem);
                            m.MenuItems.Add(rootRemove);

                            remItem = new MenuItem($"&Refresh Grid Data");
                            remItem.Click += vRefreshGrid_Click;
                            m.MenuItems.Add(remItem);

                            m.Show(kryptonGrid, new Point(e.X, e.Y));
                        }
                    }
                }
            }
        }


        private void vRefreshGrid_Click(object sender, EventArgs e)
        {
            LoadVault(true);
        }

        /// <summary>Builds the uce.</summary>
        /// <param name="vCart">The v cart.</param>
        /// <returns>The folder where the final UCE FIle exists</returns>
        internal string BuildUCE(VaultRecordCSV_ViewModel vCart)
        {
            string Working_Path = BLL._Settings.DefaultFolder_Working;
            var tmpCartridge = $"{Working_Path}\\byog_cartridge_shfs_twin.img";
            //Populates the UCE_Template directory with the correct files for this cart.
            BLL.BuildUCETemplate(vCart);

            //Pseudo-file is used to give proper permissions to files in Squashfs
            BLL.BuildPseudoFile(vCart);

            RemoveFile(tmpCartridge);

            //Build the SquashFS File
            var madeFile = BLL.LaunchMKSquashFS(tmpCartridge, BLL._Settings.ShowBuildWindow);

            string finalUCEImg = "";
            string cartSaveImg = $"{Directory.GetCurrentDirectory()}\\img\\byog_cart_saving_ext4.img";
            string md5binImg = $"{Working_Path}\\my_md5string_hex.bin";

            if (madeFile)
            {
                // Pad file to 4k Boundary
                var fSize = new FileInfo(tmpCartridge).Length;
                Debug.Write($"Size of img: {fSize} Bytes (before applying 4k alignment){Environment.NewLine}");
                var realBytesUsedDividedBy4k = fSize / 4096;
                if (fSize % 4096 != 0)
                {
                    Debug.Write($"DIFF: {fSize % 4096}{Environment.NewLine}");
                    realBytesUsedDividedBy4k += 1;
                }

                var realBytesUsed = realBytesUsedDividedBy4k * 4096;
                var padding = (int)(realBytesUsed - fSize);
                var nulPad = BLL.CreateSpecialByteArray(padding);
                BLL.AppendBinaryData(tmpCartridge, nulPad);

                fSize = new FileInfo(tmpCartridge).Length;
                Debug.Write($"Size of img: {fSize} Bytes after applying 4k alignment ({padding}){Environment.NewLine}");
                Debug.Write($"*** Offset of Ext4 partition for file saving would be: {fSize + 64}{ Environment.NewLine}");


                var strMD5Hexidecimal = BLL.getMD5HashAsString(tmpCartridge);
                BLL.WriteToFile($"{Working_Path}\\md5sum.wintst", strMD5Hexidecimal);
                var tstMD5 = BLL.HexToByteArray(strMD5Hexidecimal);
                BLL.WriteToFile($"{md5binImg}", tstMD5);

                // Add MD5 Hash
                BLL.AppendBinaryData(tmpCartridge, tstMD5);
                Debug.Write($"{Environment.NewLine}*** SQFS Partition MD5 Hash: {strMD5Hexidecimal} -- {BLL.HexToByteArray(strMD5Hexidecimal)} {Environment.NewLine}");

                fSize = new FileInfo(tmpCartridge).Length;
                Debug.Write($"After md5: {fSize}{Environment.NewLine}");

                nulPad = BLL.CreateSpecialByteArray(32);
                // Add 32 Bytes of reserved space
                BLL.AppendBinaryData(tmpCartridge, nulPad);
                BLL.WriteToFile($"{Working_Path}\\reservedspace.wintst", nulPad);

                fSize = new FileInfo(tmpCartridge).Length;
                Debug.Write($"After Reserved: {fSize}{Environment.NewLine}");

                BLL.appendFile(tmpCartridge, md5binImg);

                fSize = new FileInfo(tmpCartridge).Length;
                Debug.Write($"After md5 of cart: {fSize}{Environment.NewLine}");

                finalUCEImg = $"{BLL._Settings.DefaultFolder_USBRoot}\\{vCart.Genre}\\AddOn_{vCart.Title}.UCE";
                File.Copy(tmpCartridge, finalUCEImg, true);

                //append the cart save img file
                BLL.appendFile(finalUCEImg, cartSaveImg);

                fSize = new FileInfo(finalUCEImg).Length;
                Debug.Write($"Final imgSave: {fSize}\n");
            }

            return finalUCEImg;
        }
        private void kryptonGrid_Resize(object sender, EventArgs e)
        {
            int PreferredTotalWidth = 0;
            //Calculate the total preferred width
            foreach (DataGridViewColumn c in kryptonGrid.Columns)
            {
                PreferredTotalWidth += Math.Min(c.GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, true), 250);
            }

            if (kryptonGrid.Width > PreferredTotalWidth)
            {
                kryptonGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                kryptonGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            else
            {
                kryptonGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                foreach (DataGridViewColumn c in kryptonGrid.Columns)
                {
                    c.Width = Math.Min(c.GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, true), 250);
                }
            }
        }
        private void txtCtrl_TextChanged(object sender, EventArgs e)
        {
            if (txtVTitle.Text.Any() && txtVBezelArt.Text.Any() && txtVBoxArt.Text.Any()
                && txtVROM.Text.Any() && (txtVCore.Text.Any() || cbVUseInternalCore.Checked))

            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void btnVBoxArt_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = $"{BLL._Settings.DefaultFolder_BoxArt}";
                openFileDialog.Filter = "Cover Art files (*.png)|*.png|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        txtVBoxArt.Text = openFileDialog.FileName;
                        LoadBoxArt(openFileDialog.FileName);
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
                }
            }
        }

        private void btnVBezelArt_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = $"{BLL._Settings.DefaultFolder_BezelArt}";
                openFileDialog.Filter = "Bezel Art files (*.png)|*.png|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        txtVBezelArt.Text = openFileDialog.FileName;
                        LoadBezelArt(openFileDialog.FileName);
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
                }
            }
        }

        private void btnVCore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = $"{BLL._Settings.DefaultFolder_Cores}";
                openFileDialog.Filter = "Emulator Core files (*.so)|*.so|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        txtVCore.Text = openFileDialog.FileName;

                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
                }
            }
        }

        private void btnVROM_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = $"{BLL._Settings.DefaultFolder_Cores}";
                openFileDialog.Filter = "ROM files (*.zip)|*.zip|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        txtVROM.Text = openFileDialog.FileName;
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
                }
            }
        }

        private void cbOverlay_CheckedChanged(object sender, EventArgs e)
        {
            picVBoxArt.Refresh();

        }

        private void picVBoxArt_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var fName = Path.GetFileNameWithoutExtension(txtVCore.Text);
            if (!File.Exists($"{Directory.GetCurrentDirectory()}\\images\\overlays\\{fName}_OL.png"))
            {
                fName = "Unknown";
            }
            var overLayFName = $"{Directory.GetCurrentDirectory()}\\images\\overlays\\{fName}_OL.png";
            if (cbOverlay.Checked && File.Exists(overLayFName))
            {
                //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Image img = Image.FromFile(overLayFName);
                //firstImage.Width - 56, firstImage.Height - 56, 55, 55);
                if (picVBoxArt.Image != null)
                    g.DrawImage(img, picVBoxArt.Width - 34, picVBoxArt.Height - 34, 32,32);
                g.Save();
            }
        }
        #endregion

        #region Vault Work

        private VaultRecordCSV_ViewModel PopulateCartridgeModel()
        {
            return new VaultRecordCSV_ViewModel
            {
                Title = txtVTitle.Text,
                Genre = cboVGenre.Text,
                BezelArtFile = txtVBezelArt.Text,
                CoverArtFile = txtVBoxArt.Text,
                ROMFile = txtVROM.Text,
                UseInternalCore = cbVUseInternalCore.Checked,
                EmulatorCoreFile = txtVCore.Text,
                UseOverLayFile = cbOverlay.Checked,
                Description = "",
                ResizeImages = cbResizeImages.Checked
            };

        }
        private VaultRecordCSV_ViewModel PopulateCartridgeModel(DataGridViewRow row)
        {
            return new VaultRecordCSV_ViewModel
            {
                Title = row.Cells["ColumnTitle"].Value.ToString(),
                CoverArtFile = row.Cells["ColumnCoverArtFile"].Value.ToString(),
                BezelArtFile = row.Cells["ColumnBezelArtFile"].Value.ToString(),
                EmulatorCoreFile = row.Cells["ColumnEmulatorCoreFile"].Value.ToString(),
                Genre = row.Cells["ColumnGenre"].Value.ToString(),
                ROMFile = row.Cells["ColumnROMFile"].Value.ToString(),
                Index = Convert.ToInt32(row.Cells["ColumnIndex"].Value),
                UseOverLayFile = Convert.ToBoolean(row.Cells["ColumnOverLayFile"].Value),
                ResizeImages = Convert.ToBoolean(row.Cells["ColumnResizeImages"].Value),
                Description = "",
                UseInternalCore = Convert.ToBoolean(row.Cells["ColumnUseInternalCore"].Value)
                //  UseInternalCore = row.Cells["ColumnTitle"].Value
            };


        }
        private void PopulateCartridgeProfile(DataGridViewRow row)
        {
            txtVIndex.Text = row.Cells["ColumnIndex"].Value.ToString();
            txtVTitle.Text = row.Cells["ColumnTitle"].Value.ToString();
            cboVGenre.SelectedIndex = cboVGenre.FindString(row.Cells["ColumnGenre"].Value.ToString());
            txtVBoxArt.Text = row.Cells["ColumnCoverArtFile"].Value.ToString();
            txtVBezelArt.Text = row.Cells["ColumnBezelArtFile"].Value.ToString();
            txtVCore.Text = row.Cells["ColumnEmulatorCoreFile"].Value.ToString();
            txtVROM.Text = row.Cells["ColumnROMFile"].Value.ToString();
            cbVUseInternalCore.Checked = Convert.ToBoolean(row.Cells["ColumnUseInternalCore"].Value);
            cbOverlay.Checked = Convert.ToBoolean(row.Cells["ColumnOverLayFile"].Value);
            cbResizeImages.Checked = Convert.ToBoolean(row.Cells["ColumnResizeImages"].Value);

            LoadBoxArt(txtVBoxArt.Text);
            LoadBezelArt(txtVBezelArt.Text);

        }

        private void PopulateCartridgeProfile(VaultRecordCSV_ViewModel vCart)
        {
            if (vCart == null) return;
            txtVIndex.Text = "-1";
            txtVTitle.Text = vCart.Title;
            cboVGenre.SelectedIndex = cboVGenre.FindString(vCart.Genre);
            txtVBoxArt.Text = vCart.CoverArtFile;
            txtVBezelArt.Text = vCart.BezelArtFile;
            txtVCore.Text = vCart.EmulatorCoreFile;
            txtVROM.Text = vCart.ROMFile;
            cbVUseInternalCore.Checked = vCart.UseInternalCore;
            cbOverlay.Checked = vCart.UseOverLayFile;
            cbResizeImages.Checked = vCart.ResizeImages;

            LoadBoxArt(txtVBoxArt.Text);
            LoadBezelArt(txtVBezelArt.Text);
        }


        private void ClearCartridgeProfile()
        {
            txtVIndex.Text = "-1";
            txtVTitle.Text = "";
            txtVBoxArt.Text = "";
            txtVBezelArt.Text = "";
            txtVCore.Text = "";
            txtVIndex.Text = "";
            txtVROM.Text = "";
            cbVUseInternalCore.Checked = false;
            cbResizeImages.Checked = false;
            cbOverlay.Checked = false;
            ClearCoverArt();
            ClearBezelArt();
        }

        /// <summary>Reloads the vault.
        /// Slow, rebuilds entire grid, but can't seem to bind to bindingsource presently</summary>
        private void LoadVault(bool refreshOnly = false)
        {

            kryptonHeaderGroup1.ValuesPrimary.Heading = $"Vault Configs - {BLL._Settings.TheVault}";

            if (!refreshOnly)
            {
                BLL._VaultRecords = BLL.GetVaultList(BLL._Settings.TheVault);
            }

            OutlookGridRow row = new OutlookGridRow();
            List<OutlookGridRow> gridList = new List<OutlookGridRow>();
            kryptonGrid.SuspendLayout();
            kryptonGrid.ClearInternalRows();
            kryptonGrid.FillMode = FillMode.GROUPSANDNODES;

            foreach (var vCart in BLL._VaultRecords)
            {
                try
                {
                    row = new OutlookGridRow();
                    vCart.HasUCE = File.Exists($"{BLL._Settings.DefaultFolder_USBRoot}\\{vCart.Genre}\\AddOn_{vCart.Title}.UCE");
                    row.CreateCells(kryptonGrid, new object[] {
                        vCart.Index.ToString(),
                        vCart.HasUCE,
                        vCart.Title,
                        vCart.Genre,
                        vCart.CoverArtFile,
                        vCart.BezelArtFile,
                        vCart.UseInternalCore,
                        vCart.EmulatorCoreFile,
                        vCart.UseOverLayFile,
                        vCart.ROMFile,
                        vCart.Description,
                        vCart.ResizeImages
                    });
                    gridList.Add(row);
                    ((KryptonDataGridViewTreeTextCell)row.Cells[3]).UpdateStyle(); //Important : after added to the rows list
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gasp...Something went wrong ! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            kryptonGrid.ResumeLayout();
            kryptonGrid.AssignRows(gridList);
            if (!refreshOnly)
            {
                kryptonGrid.GroupColumn("ColumnGenre", SortOrder.Ascending, null);
                kryptonGrid.ForceRefreshGroupBox();
            }
            kryptonGrid.Fill();

        }

        #endregion

        private void cbVUseInternalCore_CheckedChanged(object sender, EventArgs e)
        {
            txtVCore.Enabled = !cbVUseInternalCore.Checked;
            btnVCore.Enabled = !cbVUseInternalCore.Checked;
        }
    }
}


