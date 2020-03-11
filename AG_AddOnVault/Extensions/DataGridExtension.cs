/*
 * AG_AddOnVault
 * Component Datagrid Extensions
 * (C) 2020 Koden, LLC (Tim Fischer)
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AG_AddOnTool.Extensions
{
    public class GroupByGrid : DataGridView
    {

        protected override void OnCellFormatting(
           DataGridViewCellFormattingEventArgs args)
        {
            // Call home to base
            base.OnCellFormatting(args);

            // First row always displays
            if (args.RowIndex == 0)
                return;


            if (IsRepeatedCellValue(args.RowIndex, args.ColumnIndex))
            {
                args.Value = string.Empty;
                args.FormattingApplied = true;
            }
        }

        private bool IsRepeatedCellValue(int rowIndex, int colIndex)
        {
            DataGridViewCell currCell =
               Rows[rowIndex].Cells[colIndex];
            DataGridViewCell prevCell =
               Rows[rowIndex - 1].Cells[colIndex];

            if ((currCell.Value == prevCell.Value) ||
               (currCell.Value != null && prevCell.Value != null &&
               currCell.Value.ToString() == prevCell.Value.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void OnCellPainting(
           DataGridViewCellPaintingEventArgs args)
        {
            base.OnCellPainting(args);

            args.AdvancedBorderStyle.Bottom =
               DataGridViewAdvancedCellBorderStyle.None;

            // Ignore column and row headers and first row
            if (args.RowIndex < 1 || args.ColumnIndex < 0)
                return;

            if (IsRepeatedCellValue(args.RowIndex, args.ColumnIndex))
            {
                args.AdvancedBorderStyle.Top =
                   DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                args.AdvancedBorderStyle.Top = AdvancedCellBorderStyle.Top;
            }
        }
    }
}
