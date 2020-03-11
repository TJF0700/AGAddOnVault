/*
 * AG_AddOnVault
 * Component Custom Tooltip
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
using AG_AddOnTool.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AG_AddOnTool.Extensions
{
    class CustomToolTip : ToolTip
    {
        private NodeInfo _nInfo;

        public NodeInfo NInfo { get => _nInfo; set => _nInfo = value; }

        public CustomToolTip()
        {
            this.ShowAlways = true;
            this.OwnerDraw = true;
            this.Popup += new PopupEventHandler(this.OnPopup);
            this.Draw += new DrawToolTipEventHandler(this.OnDraw);
        }

        public CustomToolTip(NodeInfo tag)
        {
            NInfo = tag;
            this.OwnerDraw = true;
            this.Popup += new PopupEventHandler(this.OnPopup);
            this.Draw += new DrawToolTipEventHandler(this.OnDraw);
        }

        private void OnPopup(object sender, PopupEventArgs e) // use this event to set the size of the tool tip
        {
            var tSize = TextRenderer.MeasureText(NInfo.Desc, new Font("Calibri", 11));
            tSize.Width = (tSize.Width * 2) + 16;
            tSize.Height = (tSize.Height * 5) + 10;
            e.ToolTipSize = tSize; // new Size(150, 100);
        }

        private void OnDraw(object sender, DrawToolTipEventArgs e) // use this to customzie the tool tip
        {
            Graphics g = e.Graphics;
            Control parent = e.AssociatedControl;

            if (NInfo != null)
            {
                // Draw the standard background.
                e.DrawBackground();

                // Draw the custom border to appear 3-dimensional.
                e.Graphics.DrawLines(SystemPens.ControlLightLight, new Point[] {
                    new Point (0, e.Bounds.Height - 1),
                    new Point (0, 0),
                    new Point (e.Bounds.Width - 1, 0)
                });
                e.Graphics.DrawLines(SystemPens.ControlDarkDark, new Point[] {
                    new Point (0, e.Bounds.Height - 1),
                    new Point (e.Bounds.Width - 1, e.Bounds.Height - 1),
                    new Point (e.Bounds.Width - 1, 0)
                });

                // Draw the custom text.
                // The using block will dispose the StringFormat automatically.
                using (StringFormat sf = new StringFormat())
                {

                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
                    sf.FormatFlags = StringFormatFlags.NoWrap;

                    using (Font font = new Font("Calibri", 11))
                    {
                        using (var boldFont = new Font(font, FontStyle.Bold))
                        {
                            var headerTextSize = TextRenderer.MeasureText("Title: ", font);
                            var headerTextPosition = new Point(e.Bounds.X, e.Bounds.Y + 5);

                            TextRenderer.DrawText(e.Graphics, "Title: ", font, headerTextPosition, Color.Black);
                            var valueTextPosition = new Point(e.Bounds.X + headerTextSize.Width, e.Bounds.Y + 5);
                            TextRenderer.DrawText(e.Graphics, NInfo.Title, boldFont, valueTextPosition, Color.Black);

                            headerTextSize = TextRenderer.MeasureText("Core: ", font);
                            headerTextPosition = new Point(e.Bounds.X, e.Bounds.Y + 25);
                            TextRenderer.DrawText(e.Graphics, "Core: ", font, headerTextPosition, Color.Black);
                            valueTextPosition = new Point(e.Bounds.X + headerTextSize.Width, e.Bounds.Y + 25);
                            TextRenderer.DrawText(e.Graphics, NInfo.Core, boldFont, valueTextPosition, Color.Black);

                            headerTextSize = TextRenderer.MeasureText("Desc: ", font);
                            headerTextPosition = new Point(e.Bounds.X, e.Bounds.Y + 45);
                            TextRenderer.DrawText(e.Graphics, "Desc: ", font, headerTextPosition, Color.Black);
                            valueTextPosition = new Point(e.Bounds.X + headerTextSize.Width, e.Bounds.Y + 45);
                            TextRenderer.DrawText(e.Graphics, NInfo.Desc, boldFont, valueTextPosition, Color.Black);
                        }
                    }

                    //using (Font f = new Font("Calibri", 11))
                    //{
                    //    StringBuilder sb = new StringBuilder();
                    //    sb.Append($"\n\r  Title: {NInfo.Title}");
                    //    sb.Append($"\n\r  Core: {NInfo.Core}");
                    //    sb.Append($"\n\r  Desc: {NInfo.Desc}");
                    //    e.Graphics.DrawString(sb.ToString(), f,
                    //        SystemBrushes.ActiveCaptionText, e.Bounds, sf);
                    //}
                }
            }

        }
    }
}
