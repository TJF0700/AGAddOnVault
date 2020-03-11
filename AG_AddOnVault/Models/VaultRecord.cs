/*
 * AG_AddOnVault
 * Component VaultRecord
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
using Koden.Utils.Attributes;
using Koden.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG_AddOnTool.Models
{

    public class VaultRecordCSV_ViewModel
    {
        //"index","Last Name","Gender","DOB","Relation to Subscriber","Insurance ID"
        [kColumnOrder(1)]
        public int Index { get; set; }
        [kColumnOrder(2)]
        public bool HasUCE { get; set; }

        [kColumnOrder(3)]
        public string Title { get; set; }
        [kColumnOrder(4)]
        public string Genre { get; set; }
        [kColumnOrder(5)]
        public string CoverArtFile { get; set; }
        [kColumnOrder(6)]
        public string BezelArtFile { get; set; }
        [kColumnOrder(7)]
        public bool UseInternalCore { get; set; }
        [kColumnOrder(8)]
        public string EmulatorCoreFile { get; set; }
        [kColumnOrder(9)]
        public bool UseOverLayFile { get; set; }
        [kColumnOrder(10)]
        public string ROMFile { get; set; }
        [kColumnOrder(11)]
        public string Description { get; set; }
        
        [kColumnOrder(12)]
        public bool ResizeImages { get; set; }




        public static VaultRecordCSV_ViewModel FromCSV(string csvLine)
        {
            string[] Fields = csvLine.kSplitQuotedCSV();

            VaultRecordCSV_ViewModel vaultRecord = new VaultRecordCSV_ViewModel
            {
                Index = Convert.ToInt32(Fields[0]),
                HasUCE = Convert.ToBoolean(Fields[1]),
                Title = Fields[2],
                Genre = Fields[3],
                CoverArtFile = Fields[4],
                BezelArtFile = Fields[5],
                UseInternalCore = Convert.ToBoolean(Fields[6]),
                EmulatorCoreFile = Fields[7],
                UseOverLayFile = Convert.ToBoolean(Fields[8]),
                ROMFile = Fields[9],
                Description = Fields[10],
                ResizeImages = Convert.ToBoolean(Fields[11])

            };
            return vaultRecord;
        }
    }

}
