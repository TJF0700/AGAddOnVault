using ComponentFactory.Krypton.Toolkit;
using KryptonOutlookGrid.Classes;
using KryptonOutlookGrid.CustomColumns;
using KryptonOutlookGrid.Formatting;
using KryptonOutlookGrid.Formatting.Params;
using KryptonOutlookGrid.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace AG_AddOnTool.KryptonGrid
{
    public class KryptonGridSetup
    {
        private VaultGridColumn[] activeColumns;

        public enum VaultGridColumn
        {
            ColumnIndex = 0,
            ColumnHasUCE = 1,
            ColumnTitle = 2,
            ColumnGenre = 3,
            ColumnCoverArtFile = 4,
            ColumnBezelArtFile = 5,
            ColumnUseInternalCore = 6,
            ColumnEmulatorCoreFile = 7,
            ColumnOverLayFile = 8,
            ColumnROMFile = 9,
            ColumnDescription = 10,
            ColumnResizeImages = 11
        }

        public enum LoadState
        {
            Before,
            After
        }

        /// <summary>
        /// Setups the data grid view.
        /// </summary>
        /// <param name="Grid">The grid.</param>
        /// <param name="RestoreIfPossible">if set to <c>true</c> [restore if possible].</param>
        public void SetupDataGridView(KryptonOutlookGrid.Classes.KryptonOutlookGrid Grid, bool RestoreIfPossible)
        {
            if (File.Exists(Application.StartupPath + "/grid.xml") & RestoreIfPossible)
            {
                try
                {
                    LoadConfigFromFile(Application.StartupPath + "/grid.xml", Grid);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when retrieving configuration : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Grid.ClearEverything();
                    LoadDefaultConfiguration(Grid);
                }
            }
            else
            {
                LoadDefaultConfiguration(Grid);
            }
        }

        /// <summary>
        /// Loads the default configuration.
        /// </summary>
        /// <param name="Grid">The grid.</param>
        private void LoadDefaultConfiguration(KryptonOutlookGrid.Classes.KryptonOutlookGrid Grid)
        {
            Grid.ClearEverything();
            Grid.GroupBox.Visible = true;
            Grid.AllowDrop = true;
            //Grid.HideColumnOnGrouping = false;

            Grid.FillMode = FillMode.GROUPSANDNODES; //treemode enabled;
            Grid.ShowLines = true;

            activeColumns = new VaultGridColumn[] {
                VaultGridColumn.ColumnIndex,
                VaultGridColumn.ColumnHasUCE,
                VaultGridColumn.ColumnTitle,
                VaultGridColumn.ColumnGenre,
                VaultGridColumn.ColumnCoverArtFile,
                VaultGridColumn.ColumnBezelArtFile,
                VaultGridColumn.ColumnUseInternalCore,
                VaultGridColumn.ColumnEmulatorCoreFile,
                VaultGridColumn.ColumnOverLayFile,
                VaultGridColumn.ColumnROMFile,
                VaultGridColumn.ColumnDescription,
                VaultGridColumn.ColumnResizeImages
            };

            DataGridViewColumn[] columnsToAdd = new DataGridViewColumn[12]
            {
            SetupColumn(VaultGridColumn.ColumnIndex),
            SetupColumn(VaultGridColumn.ColumnHasUCE),
            SetupColumn(VaultGridColumn.ColumnTitle),
            SetupColumn(VaultGridColumn.ColumnGenre),
            SetupColumn(VaultGridColumn.ColumnCoverArtFile),
            SetupColumn(VaultGridColumn.ColumnBezelArtFile),
            SetupColumn(VaultGridColumn.ColumnUseInternalCore),
            SetupColumn(VaultGridColumn.ColumnEmulatorCoreFile),
            SetupColumn(VaultGridColumn.ColumnOverLayFile),
            SetupColumn(VaultGridColumn.ColumnROMFile),
            SetupColumn(VaultGridColumn.ColumnDescription),
            SetupColumn(VaultGridColumn.ColumnResizeImages)
        };
            Grid.Columns.AddRange(columnsToAdd);

            //Define the columns for a possible grouping
            Grid.AddInternalColumn(columnsToAdd[0], new OutlookGridDefaultGroup(null), SortOrder.None, -1, -1);
            Grid.AddInternalColumn(columnsToAdd[1], new OutlookGridDefaultGroup(null), SortOrder.None, -1, -1);
            Grid.AddInternalColumn(columnsToAdd[2], new OutlookGridDefaultGroup(null), SortOrder.None, -1, -1);
            Grid.AddInternalColumn(columnsToAdd[3], new OutlookGridDefaultGroup(null), SortOrder.None, -1, -1);
            Grid.AddInternalColumn(columnsToAdd[4], new OutlookGridDefaultGroup(null), SortOrder.None, -1, -1);
            Grid.AddInternalColumn(columnsToAdd[5], new OutlookGridDefaultGroup(null), SortOrder.None, -1, -1);
            Grid.AddInternalColumn(columnsToAdd[6], new OutlookGridDateTimeGroup(null), SortOrder.None, -1, -1);
            Grid.AddInternalColumn(columnsToAdd[7], new OutlookGridDateTimeGroup(null), SortOrder.None, -1, -1);
            Grid.AddInternalColumn(columnsToAdd[8], new OutlookGridDefaultGroup(null), SortOrder.None, -1, -1);
            Grid.AddInternalColumn(columnsToAdd[9], new OutlookGridAlphabeticGroup(null), SortOrder.None, -1, -1);
            Grid.AddInternalColumn(columnsToAdd[10], new OutlookGridDefaultGroup(null), SortOrder.None, -1, -1);
            Grid.AddInternalColumn(columnsToAdd[11], new OutlookGridDefaultGroup(null), SortOrder.None, -1, -1);

        }


        /// <summary>
        /// Loads the configuration from file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="Grid">The grid.</param>
        private void LoadConfigFromFile(string file, KryptonOutlookGrid.Classes.KryptonOutlookGrid Grid)
        {
            if (string.IsNullOrEmpty(file))
                throw new Exception("Grid config file is missing !");

            XDocument doc = XDocument.Load(file);
            int versionGrid = -1;
            int.TryParse(doc.Element("OutlookGrid").Attribute("V").Value, out versionGrid);

            //Upgrade if necessary the config file
            CheckAndUpgradeConfigFile(versionGrid, doc, Grid, LoadState.Before);
            Grid.ClearEverything();
            Grid.GroupBox.Visible = CommonHelper.StringToBool(doc.XPathSelectElement("OutlookGrid/GroupBox").Value);
            Grid.HideColumnOnGrouping = CommonHelper.StringToBool(doc.XPathSelectElement("OutlookGrid/HideColumnOnGrouping").Value);

            //Initialize
            int NbColsInFile = doc.XPathSelectElements("//Column").Count();
            DataGridViewColumn[] columnsToAdd = new DataGridViewColumn[NbColsInFile];
            VaultGridColumn[] enumCols = new VaultGridColumn[NbColsInFile];
            OutlookGridColumn[] OutlookColumnsToAdd = new OutlookGridColumn[columnsToAdd.Length];
            SortedList<int, int> hash = new SortedList<int, int>();// (DisplayIndex , Index)


            int i = 0;
            IOutlookGridGroup group;
            XElement node2;

            foreach (XElement node in doc.XPathSelectElement("OutlookGrid/Columns").Nodes())
            {
                //Create the columns and restore the saved properties
                //As the OutlookGrid receives constructed DataGridViewColumns, only the parent application can recreate them (dgvcolumn not serializable)
                enumCols[i] = (VaultGridColumn)Enum.Parse(typeof(VaultGridColumn), node.Element("Name").Value);
                columnsToAdd[i] = SetupColumn(enumCols[i]);
                columnsToAdd[i].Width = int.Parse(node.Element("Width").Value);
                columnsToAdd[i].Visible = CommonHelper.StringToBool(node.Element("Visible").Value);
                hash.Add(int.Parse(node.Element("DisplayIndex").Value), i);
                //Reinit the group if it has been set previously
                group = null;
                if (!node.Element("GroupingType").IsEmpty && node.Element("GroupingType").HasElements)
                {
                    node2 = node.Element("GroupingType");
                    group = (IOutlookGridGroup)Activator.CreateInstance(Type.GetType(TypeConverter.ProcessType(node2.Element("Name").Value), true));
                    group.OneItemText = node2.Element("OneItemText").Value;
                    group.XXXItemsText = node2.Element("XXXItemsText").Value;
                    group.SortBySummaryCount = CommonHelper.StringToBool(node2.Element("SortBySummaryCount").Value);
                    if (!string.IsNullOrEmpty((node2.Element("ItemsComparer").Value)))
                    {
                        Object comparer = Activator.CreateInstance(Type.GetType(TypeConverter.ProcessType(node2.Element("ItemsComparer").Value), true));
                        group.ItemsComparer = (IComparer)comparer;
                    }
                    if (node2.Element("Name").Value.Contains("OutlookGridDateTimeGroup"))
                    {
                        ((OutlookGridDateTimeGroup)group).Interval = (OutlookGridDateTimeGroup.DateInterval)Enum.Parse(typeof(OutlookGridDateTimeGroup.DateInterval), node2.Element("GroupDateInterval").Value);
                    }
                }
                OutlookColumnsToAdd[i] = new OutlookGridColumn(columnsToAdd[i], group, (SortOrder)Enum.Parse(typeof(SortOrder), node.Element("SortDirection").Value), int.Parse(node.Element("GroupIndex").Value), int.Parse(node.Element("SortIndex").Value));

                i += 1;
            }
            //First add the underlying DataGridViewColumns to the grid
            Grid.Columns.AddRange(columnsToAdd);
            //And then the outlookgrid columns
            Grid.AddRangeInternalColumns(OutlookColumnsToAdd);

            //Add conditionnal formatting to the grid
            EnumConditionalFormatType conditionFormatType = default(EnumConditionalFormatType);
            IFormatParams conditionFormatParams = default(IFormatParams);
            foreach (XElement node in doc.XPathSelectElement("OutlookGrid/ConditionalFormatting").Nodes())
            {
                conditionFormatType = (EnumConditionalFormatType)Enum.Parse(typeof(EnumConditionalFormatType), node.Element("FormatType").Value);
                XElement nodeParams = node.Element("FormatParams");
                switch (conditionFormatType)
                {
                    case EnumConditionalFormatType.BAR:
                        conditionFormatParams = new BarParams(Color.FromArgb(int.Parse(nodeParams.Element("BarColor").Value)), CommonHelper.StringToBool(nodeParams.Element("GradientFill").Value));
                        break;
                    case EnumConditionalFormatType.THREECOLOURSRANGE:
                        conditionFormatParams = new ThreeColoursParams(Color.FromArgb(int.Parse(nodeParams.Element("MinimumColor").Value)), Color.FromArgb(int.Parse(nodeParams.Element("MediumColor").Value)), Color.FromArgb(int.Parse(nodeParams.Element("MaximumColor").Value)));
                        break;
                    case EnumConditionalFormatType.TWOCOLOURSRANGE:
                        conditionFormatParams = new TwoColoursParams(Color.FromArgb(int.Parse(nodeParams.Element("MinimumColor").Value)), Color.FromArgb(int.Parse(nodeParams.Element("MaximumColor").Value)));
                        break;
                    default:
                        conditionFormatParams = null;
                        //will never happened but who knows ? throw exception ?
                        break;
                }
                Grid.ConditionalFormatting.Add(new ConditionalFormatting(node.Element("ColumnName").Value, conditionFormatType, conditionFormatParams));
            }



            //We need to loop through the columns in the order of the display order, starting at zero; otherwise the columns will fall out of order as the loop progresses.
            foreach (KeyValuePair<int, int> kvp in hash)
            {
                columnsToAdd[kvp.Value].DisplayIndex = kvp.Key;
            }

            activeColumns = enumCols;
        }

        /// <summary>
        /// Checks the and upgrade configuration file.
        /// </summary>
        /// <param name="versionGrid">The version grid.</param>
        /// <param name="doc">The document.</param>
        /// <param name="grid">The grid.</param>
        /// <param name="state">The state.</param>
        private void CheckAndUpgradeConfigFile(int versionGrid, XDocument doc, KryptonOutlookGrid.Classes.KryptonOutlookGrid grid, LoadState state)
        {
            while (versionGrid < StaticInfos._GRIDCONFIG_VERSION)
            {
                UpgradeGridConfigToVX(doc, versionGrid + 1, grid, state);
                versionGrid += 1;
            }
        }

        /// <summary>
        /// Upgrades the grid configuration to vx.
        /// </summary>
        /// <param name="doc">The document.</param>
        /// <param name="version">The version.</param>
        /// <param name="Grid">The grid.</param>
        /// <param name="state">The state.</param>
        private void UpgradeGridConfigToVX(XDocument doc, int version, KryptonOutlookGrid.Classes.KryptonOutlookGrid Grid, LoadState state)
        {
            //Do changes according to version
            //For example you can add automatically new columns. This can be useful when you update your application to add columns and would like to display them to the user for the first time.
            //switch (version)
            //{
            //case 2:
            //    // Do changes to match the V2
            //    if (state == DataGridViewSetup.LoadState.Before)
            //    {
            //        doc.Element("OutlookGrid").Attribute("V").Value = version.ToString();
            //        Array.Resize(ref activeColumns, activeColumns.Length + 1);
            //        DataGridViewColumn columnToAdd = SetupColumn(VaultGridColumn.ColumnPrice2);
            //        Grid.Columns.Add(columnToAdd);
            //        Grid.AddInternalColumn(columnToAdd, new OutlookGridDefaultGroup(null)
            //        {
            //            OneItemText = "Example",
            //            XXXItemsText = "Examples"
            //        }, SortOrder.None, -1, -1);
            //        activeColumns[activeColumns.Length - 1] = VaultGridColumn.ColumnPrice2;

            //        Grid.PersistConfiguration(PublicFcts.GetGridConfigFile, version);
            //    }
            //    break;
            //}
        }


        /// <summary>
        /// Use this function if you do not add your columns at design time.
        /// </summary>
        /// <param name="colType"></param>
        /// <returns></returns>
        private DataGridViewColumn SetupColumn(VaultGridColumn colType)
        {
            DataGridViewColumn column = null;
            switch (colType)
            {
                case VaultGridColumn.ColumnIndex:
                    column = new KryptonDataGridViewTextBoxColumn();
                    column.HeaderText = "Index";
                    column.Name = "ColumnIndex";
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                    column.Width = 79;
                    return column;
                case VaultGridColumn.ColumnHasUCE:
                    column = new KryptonDataGridViewCheckBoxColumn();
                    column.HeaderText = "Has UCE?";
                    column.Name = "ColumnHasUCE";
                    column.Resizable = DataGridViewTriState.True;
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                    column.Width = 78;
                    return column;
                case VaultGridColumn.ColumnTitle:
                    column = new KryptonDataGridViewTextBoxColumn();// KryptonDataGridViewTextBoxColumn();
                    column.HeaderText = "Title";
                    column.Name = "ColumnTitle";
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                    column.Width = 79;
                    return column;
                case VaultGridColumn.ColumnGenre:
                    column = new KryptonDataGridViewTreeTextColumn();
                    column.HeaderText = "Genre";
                    column.Name = "ColumnGenre";
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                    column.Width = 79;
                    return column;
                case VaultGridColumn.ColumnCoverArtFile:
                    column = new KryptonDataGridViewTextBoxColumn();
                    column.HeaderText = "Cover Art";
                    column.Name = "ColumnCoverArtFile";
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                    column.Width = 79;
                    return column;
                case VaultGridColumn.ColumnBezelArtFile:
                    column = new KryptonDataGridViewTextBoxColumn();
                    column.HeaderText = "Bezel Art";
                    column.Name = "ColumnBezelArtFile";
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                    column.Width = 79;
                    return column;
                case VaultGridColumn.ColumnUseInternalCore:
                    column = new KryptonDataGridViewCheckBoxColumn();
                    column.HeaderText = "Use Internal Core";
                    column.Name = "ColumnUseInternalCore";
                    //((KryptonDataGridViewCheckBoxColumn)column).
                    column.Resizable = DataGridViewTriState.True;
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                    column.Width = 78;
                    return column;
                case VaultGridColumn.ColumnEmulatorCoreFile:
                    column = new KryptonDataGridViewTextBoxColumn();
                    column.HeaderText = "Emulator Core";
                    column.Name = "ColumnEmulatorCoreFile";
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                    column.Width = 79;
                    return column;
                case VaultGridColumn.ColumnOverLayFile:
                    column = new KryptonDataGridViewTextBoxColumn();
                    column.HeaderText = "Overlay?";
                    column.Name = "ColumnOverLayFile";
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                    column.Width = 79;
                    return column;
                case VaultGridColumn.ColumnROMFile:
                    column = new KryptonDataGridViewTextBoxColumn();
                    column.HeaderText = "ROM";
                    column.Name = "ColumnROMFile";
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                    column.Width = 79;
                    return column;

                case VaultGridColumn.ColumnDescription:
                    column = new KryptonDataGridViewTextBoxColumn();
                    column.HeaderText = "Description";
                    column.Name = "ColumnDescription";
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                    column.Width = 79;
                    return column;
                case VaultGridColumn.ColumnResizeImages:
                    column = new KryptonDataGridViewCheckBoxColumn();
                    column.HeaderText = "Resize Images?";
                    column.Name = "ColumnResizeImages";
                    column.Resizable = DataGridViewTriState.True;
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                    column.Width = 78;
                    return column;
                default:
                    throw new Exception("Unknown Column Type !! TODO improve that !");
            }
        }

    }
}

public class TypeConverter
{
    public static string ProcessType(string FullQualifiedName)
    {
        //Translate types here to accomodate code changes, namespaces and version
        //Select Case FullQualifiedName
        //    Case "JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridAlphabeticGroup, JDHSoftware.Krypton.Toolkit, Version=1.2.0.0, Culture=neutral, PublicKeyToken=e12f297423986ef5",
        //        "JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridAlphabeticGroup, JDHSoftware.Krypton.Toolkit, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null"
        //        'Change with new version or namespace or both !
        //        FullQualifiedName = "TestMe, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null"
        //        Exit Select
        //End Select
        return FullQualifiedName;
    }
}

