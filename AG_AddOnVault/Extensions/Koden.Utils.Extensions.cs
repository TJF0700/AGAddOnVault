/*
 * AG_AddOnVault
 * Component Koden Extensions
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
using AG_AddOnTool;
using AG_AddOnTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koden.Utils.Extensions
{
    public static partial class ExtensionMethods
    {
        /// <summary>Splits a quoted CSV line.</summary>
        /// <param name="line">The line of quoted/unquoted csv fields.</param>
        /// <returns></returns>
        public static string[] kSplitQuotedCSV(this string line)
        {
            List<string> result = new List<string>();
            StringBuilder currentStr = new StringBuilder("");
            bool inQuotes = false;
            for (int i = 0; i < line.Length; i++) // For each character
            {
                if (line[i] == '\"') // Quotes are closing or opening
                    inQuotes = !inQuotes;
                else if (line[i] == ',') // Comma
                {
                    if (!inQuotes) // If not in quotes, end of current string, add it to result
                    {
                        result.Add(currentStr.ToString());
                        currentStr.Clear();
                    }
                    else
                        currentStr.Append(line[i]); // If in quotes, just add it 
                }
                else // Add any other character to current string
                    currentStr.Append(line[i]);
            }
            result.Add(currentStr.ToString());
            return result.ToArray(); // Return array of all strings
        }

        public static List<VaultRecordCSV_ViewModel> RemoveItemWithIndexOf(this List<VaultRecordCSV_ViewModel> list, int Index, bool persist = false)
        {
            if (Index > -1)
            {
                var foundObj = list.FirstOrDefault(en => en.Index == Index);
                if (foundObj != null)
                {
                    list.Remove(foundObj);
                }
            }

            if (persist)
                BLL._VaultRecords.kSaveToCSVFile(BLL._Settings.TheVault);

            return list;
        }
        public static List<VaultRecordCSV_ViewModel> UpdateRecord(this List<VaultRecordCSV_ViewModel> list, VaultRecordCSV_ViewModel vCart, bool persist=false)
        {
            if (vCart.Index > -1)
            {

                int foundObj = list.FindIndex(en => en.Index == vCart.Index);
                if (foundObj != null)
                {
                    list[foundObj] = vCart;
                }
            }

            if (persist)
                BLL._VaultRecords.kSaveToCSVFile(BLL._Settings.TheVault);

            return list;
        }

        public static List<VaultRecordCSV_ViewModel> AddRecord(this List<VaultRecordCSV_ViewModel> list, VaultRecordCSV_ViewModel vCart, bool persist = false)
        {
            try
            {
                if (vCart.Index == -1)
                {

                    var fRec = list.FirstOrDefault(r => r.Index == vCart.Index);
                    if (fRec == null)
                    {
                        if (list.Any())
                        {
                            vCart.Index = list.Max(m => m.Index) + 1;
                        }
                        else
                        {
                            vCart.Index = 1;
                        }
                        list.Add(vCart);
                    }
                    else
                    {
                        list = list.UpdateRecord(vCart);
                    }
                }

            }
            catch (Exception ex)
            {

                return null;
            }
            if(persist)
                BLL._VaultRecords.kSaveToCSVFile(BLL._Settings.TheVault);

            return list;
        }

    }
}