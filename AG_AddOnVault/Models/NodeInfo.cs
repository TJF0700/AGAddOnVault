/*
 * AG_AddOnVault
 * Component NodeInfo
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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG_AddOnTool.Models
{
    public class NodeInfo
    {
        public int NodeType { get; set; }
        public int ImageIndex { get; set; }
        public Image BoxArt { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Core { get; set; }
        public string Desc { get; set; }

    }
}
