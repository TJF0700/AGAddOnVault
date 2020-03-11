/*
 * AG_AddOnVault
 * Component Business Logic Layer
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
using DiscUtils.SquashFs;
using Koden.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AG_AddOnTool
{
    public static class BLL
    {

        private static readonly string _TemplateDir = "UCE_Template";
        private static readonly string _CurDir = Directory.GetCurrentDirectory();
        private static readonly char _NewLine = '\n';
        private static readonly string quote = "\"";
        internal static AppSettings _Settings;
        internal static List<VaultRecordCSV_ViewModel> _VaultRecords;


        /// <summary>Loads the application default settings from json file.</summary>
        /// <param name="createIfEmpty">if set to <c>true</c> [create if empty].</param>
        internal static void LoadSettings(bool createIfEmpty)
        {
            _VaultRecords = new List<VaultRecordCSV_ViewModel>();
            _Settings = new AppSettings();
            if (!File.Exists("ASettings.json"))
            {
                _Settings.kSaveToJsonFile("ASettings.json");
            }
            _Settings = _Settings.kLoadFromJsonFile("ASettings.json", createIfEmpty);

        }

        /// <summary>Builds the uce template folder out with all needed files before generating the UCE File.</summary>
        /// <param name="title">The title.</param>
        /// <param name="boxArtPath">The box art path.</param>
        /// <param name="bezelPath">The bezel path.</param>
        /// <param name="corePath">The core path.</param>
        /// <param name="romPath">The rom path.</param>
        /// <exception cref="Exception">Could not clean UCE_Template directory - is it in use somewhere?
        /// or</exception>
        internal static void BuildUCETemplate(VaultRecordCSV_ViewModel vCart)
        {
            var boxArtFileName = Path.GetFileName(vCart.CoverArtFile);
            var bezelFileName = Path.GetFileName(vCart.BezelArtFile);
            var coreFileName = Path.GetFileName(vCart.EmulatorCoreFile);
            var romFileName = Path.GetFileName(vCart.ROMFile);

            try
            {
                if (Directory.Exists($"{_CurDir}\\{_TemplateDir}"))
                {
                    Directory.Delete($"{_CurDir}\\{_TemplateDir}", true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Could not clean UCE_Template directory - is it in use somewhere?");

            }
            try
            {


                Directory.CreateDirectory($"{_CurDir}\\{_TemplateDir}");
                Directory.CreateDirectory($"{_CurDir}\\{_TemplateDir}\\boxart");
                Directory.CreateDirectory($"{_CurDir}\\{_TemplateDir}\\emu");
                Directory.CreateDirectory($"{_CurDir}\\{_TemplateDir}\\roms");
                Directory.CreateDirectory($"{_CurDir}\\{_TemplateDir}\\save");
                Image tmpBoxArtImg = null;
                string boxArtFile = vCart.CoverArtFile;
                if (vCart.UseOverLayFile)
                {
                    var tmpBoxArt = Image.FromFile(vCart.CoverArtFile);

                    var tmpOverlay = Image.FromFile(GetOverLayFileName(vCart.EmulatorCoreFile));
                    tmpBoxArtImg = MergeTwoImages(tmpBoxArt, tmpOverlay);

                    boxArtFile = $"{_Settings.DefaultFolder_Working}\\tmpBoxArtImg.png";
                }
                File.Copy(boxArtFile, $"{_CurDir}\\{_TemplateDir}\\title.png");
                File.Copy(boxArtFile, $"{_CurDir}\\{_TemplateDir}\\boxart\\boxart.png", true);
                File.Copy(vCart.EmulatorCoreFile, $"{_CurDir}\\{_TemplateDir}\\emu\\{coreFileName}", true);
                File.Copy(vCart.ROMFile, $"{_CurDir}\\{_TemplateDir}\\roms\\{romFileName}", true);

                File.Copy(vCart.BezelArtFile, $"{_CurDir}\\{_TemplateDir}\\boxart\\bezelart.png", true);

                File.Create($"{_CurDir}\\{_TemplateDir}\\roms\\hiscore.dat").Dispose();

                StringBuilder sbCartridge = new StringBuilder();
                sbCartridge.AppendFormat("<?xml version=\"1.0\" encoding=\"UTF-8\"?>{0}", _NewLine);
                sbCartridge.AppendFormat("     <byog_cartridge version=\"1.0\">{0}", _NewLine);
                sbCartridge.AppendFormat("     <title>{0}</title>{1}", vCart.Title, _NewLine);
                sbCartridge.AppendFormat("     <desc>Community Add On</desc>{0}", _NewLine);
                sbCartridge.AppendFormat("     <boxart file=\"boxart\\boxart.png\" ext=\"png\">{0}", _NewLine);
                sbCartridge.AppendFormat("</byog_cartridge>{0}", _NewLine);

                File.WriteAllText($"{_CurDir}\\{_TemplateDir}\\cartridge.xml", sbCartridge.ToString());

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("#!/bin/sh{0}{0}", _NewLine);
                sb.AppendFormat("cp ./boxart/bezelart.png /tmp{0}", _NewLine);
                sb.AppendFormat("echo -e \"[Property]\\nBezelPath=/tmp/bezelart.png\" > /tmp/gameinfo.ini{0}{0}", _NewLine);
                sb.AppendFormat("set -x{0}", _NewLine);
                sb.AppendFormat("/emulator/retroplayer \"./emu/{0}\" \"./roms/{1}\"{2}", coreFileName, romFileName, _NewLine);
                sb.AppendFormat("rm -f /tmp/gameinfo.ini{0}{0}", _NewLine);

                File.WriteAllText($"{_CurDir}\\{_TemplateDir}\\exec.sh", sb.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.kGetAllMessages());

            }
        }

        internal static byte[] CreateSpecialByteArray(int length)
        {
            var arr = new byte[length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 0x00;
            }
            return arr;
        }

        internal static byte[] HexToByteArray(string hex)
        {
            hex = hex.Replace(" ", "").Replace("-", "");

            var numberChars = hex.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }



        internal static void WriteToFile(string fileName, string data)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(Encoding.Convert(Encoding.Unicode, Encoding.GetEncoding(437), Encoding.Unicode.GetBytes(data)));
                }
            }

        }

        internal static void WriteToFile(string fileName, byte[] bData)
        {
            using (FileStream fout = new FileStream(fileName, FileMode.Create))
            {
                int i = 0;
                for (i = 0; i < bData.Length; i++)
                {
                    fout.WriteByte(bData[i]);
                }
            }

            var t = 1;
        }

        internal static void appendFile(string oFile, string iFile)
        {
            using (Stream fout = new FileStream(oFile, FileMode.Append))
            {

                var newBytes = File.ReadAllBytes(iFile);
                int i = 0;
                for (i = 0; i < newBytes.Length; i++)
                {
                    fout.WriteByte(newBytes[i]);
                }
            }
        }

        internal static void BuildPseudoFile(VaultRecordCSV_ViewModel vCart)
        {
            var sb = new StringBuilder();
            sb.AppendLine("exec.sh m 755 0 0");
            sb.AppendLine("cartridge.xml m 664 0 0");
            sb.AppendLine("title.png m 664 0 0");
            sb.AppendLine("boxart m 775 0 0");
            sb.AppendLine("emu m 775 0 0");
            sb.AppendLine("roms m 775 0 0");
            sb.AppendLine("save m 775 0 0");
            sb.AppendLine($"boxart/boxart.png m 664 0 0");
            sb.AppendLine($"boxart/bezelart.png m 664 0 0");
            sb.AppendLine($"\"emu/{Path.GetFileName(vCart.EmulatorCoreFile)}\" m 664 0 0");
            sb.AppendLine($"\"roms/{Path.GetFileName(vCart.ROMFile)}\" m 664 0 0");
            sb.AppendLine("roms/hiscore.dat m 664 0 0");


            using (StreamWriter file = new StreamWriter($"{_Settings.DefaultFolder_Working}\\pseudo-file"))
            {
                file.WriteLine(sb.ToString());
            }

        }



        internal static string getMD5HashAsString(string filename)
        {
            StringBuilder sBuilder = new StringBuilder();
            byte[] data;

            using (var md5 = MD5.Create())
            {


                using (var stream = File.OpenRead(filename))
                {
                    data = md5.ComputeHash(stream);

                    // Loop through each byte of the hashed data 
                    // and format each one as a hexadecimal string.
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }

                    // Return the hexadecimal string.
                    return sBuilder.ToString();
                }
            }
        }

        internal static void AppendBinaryData(string filename, byte[] binaryData)
        {
            using (var fout = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.None))
            {

                int i = 0;
                //FileStream fout = new FileStream(fileName, FileMode.Create);
                for (i = 0; i < binaryData.Length; i++)
                {
                    fout.WriteByte(binaryData[i]);
                }
            }

        }

        internal static bool LaunchMKSquashFS(string tmpCartridgeFileName, bool openConsole = false)
        {
            string strStay = openConsole ? "/k " : "/c ";
            var winStyle = openConsole ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden;

            if (!Directory.Exists(_Settings.DefaultFolder_Working))
            {
                Directory.CreateDirectory(_Settings.DefaultFolder_Working);
            }

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                CreateNoWindow = !openConsole,
                UseShellExecute = false,
                FileName = "CMD.EXE",
                WindowStyle = winStyle,
                Arguments = $"{strStay} .\\tools\\mksquashfs.exe .\\{_TemplateDir} {tmpCartridgeFileName} -comp gzip -b 262144 -root-owned -all-root -root-mode 755 -nopad -pf { _Settings.DefaultFolder_Working }\\pseudo-file",
               
            };

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        internal static NodeInfo GetNodeInfo(FileInfo fi)
        {
            var ni = new NodeInfo();
            ni.FullName = fi.FullName;
            using (FileStream isoStream = File.OpenRead(fi.FullName))
            {
                SquashFileSystemReader readCart = new SquashFileSystemReader(isoStream);

                using (Stream entryFs = readCart.OpenFile("title.png", FileMode.Open))
                {
                    ni.BoxArt = Image.FromStream(entryFs);
                }
                using (Stream entryFs = readCart.OpenFile("cartridge.xml", FileMode.Open))
                {
                    byte[] bytes = new byte[entryFs.Length];
                    entryFs.Position = 0;
                    entryFs.Read(bytes, 0, (int)entryFs.Length);
                    string data = Encoding.ASCII.GetString(bytes);

                    Match m = Regex.Match(data, @"<title>\s*(.+?)\s*</title>");
                    ni.Title = m.Success ? m.Groups[1].Value : "No Title Found";
                    m = Regex.Match(data, @"<desc>\s*(.+?)\s*</desc>");
                    ni.Desc = m.Success ? m.Groups[1].Value : "No Desc Found";
                }

                var emuFiles = readCart.GetFiles("emu");
                if (emuFiles.Length > 0) ni.Core = Path.GetFileName(emuFiles[0]);

            }
            return ni;
        }


        public static List<VaultRecordCSV_ViewModel> GetVaultList(string path)
        {
            if (!File.Exists(path))
            {
                _VaultRecords.kSaveToCSVFile(BLL._Settings.TheVault);
            }
            //check the file for appropriate columns
            List<VaultRecordCSV_ViewModel> retVal = File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => VaultRecordCSV_ViewModel.FromCSV(v))
                                           .ToList();
            return retVal;

        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {

            //bezel art = 1280x720   = 306x172
            //Cover ARt = 210x287 = 126x172
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        public static Bitmap MergeTwoImages(Image firstImage, Image secondImage)
        {
            if (firstImage == null)
            {
                throw new ArgumentNullException("firstImage");
            }

            if (secondImage == null)
            {
                throw new ArgumentNullException("secondImage");
            }
            int outputImageWidth = firstImage.Width;// > secondImage.Width ? firstImage.Width : secondImage.Width;
            int outputImageHeight = firstImage.Height; // + secondImage.Height + 1;
            Bitmap outputImage = null;
            if (File.Exists($"{_Settings.DefaultFolder_Working}\\tmpBoxArtImg.png"))
            {
                File.Delete($"{_Settings.DefaultFolder_Working}\\tmpBoxArtImg.png");
            }
            try
            {

                //Image img = Image.FromFile(overLayFName);
                //g.DrawImage(img, 60, 115, 55, 55);

                outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                using (Graphics canvas = Graphics.FromImage(outputImage))
                {
                    canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    canvas.DrawImage(firstImage, new Rectangle(new Point(), firstImage.Size),
                        new Rectangle(new Point(), firstImage.Size), GraphicsUnit.Pixel);
                    canvas.DrawImage(secondImage, firstImage.Width - 56, firstImage.Height - 56, 55, 55);
                    canvas.Save();

                }
                outputImage.Save($"{_Settings.DefaultFolder_Working}\\tmpBoxArtImg.png", ImageFormat.Png);


                return outputImage;

            }
            catch (Exception ex)
            {

                throw new Exception($"Error on merge of bitmaps: {ex.kGetAllMessages()}");
            }
            return outputImage;
        }

        /// <summary>Explodes the UCE file and places individual files in repsective directories (coverart, bezelart, etc.).</summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="overwrite">if set to <c>true</c> [overwrite].</param>
        /// <returns></returns>
        internal static VaultRecordCSV_ViewModel ExplodeUCE(string fileName, string defaultGenre = "Unknown", bool overwrite = false)
        {
            var vCart = new VaultRecordCSV_ViewModel();
            string boxArtFileName = "";
            string bezelArtFileName = "";
            string emulatorFileName = "";
            string romFileName = "";
            vCart.Genre = defaultGenre;

            using (FileStream isoStream = File.OpenRead(fileName))
            {
                SquashFileSystemReader readCart = new SquashFileSystemReader(isoStream);

                if (readCart.FileExists($"cartridge.xml"))
                {
                    using (Stream entryFs = readCart.OpenFile("cartridge.xml", FileMode.Open))
                    {
                        byte[] bytes = new byte[entryFs.Length];
                        entryFs.Position = 0;
                        entryFs.Read(bytes, 0, (int)entryFs.Length);
                        string data = Encoding.ASCII.GetString(bytes);

                        Match m = Regex.Match(data, @"<title>\s*(.+?)\s*</title>");
                        vCart.Title = m.Success ? m.Groups[1].Value : "No Title Found";
                        m = Regex.Match(data, @"<desc>\s*(.+?)\s*</desc>");
                        vCart.Description = m.Success ? m.Groups[1].Value : "No Desc Found";
                    }

                    if (readCart.FileExists($"exec.sh"))
                    {
                        using (Stream entryFs = readCart.OpenFile("exec.sh", FileMode.Open))
                        {
                            byte[] bytes = new byte[entryFs.Length];
                            entryFs.Position = 0;
                            entryFs.Read(bytes, 0, (int)entryFs.Length);
                            string data = Encoding.ASCII.GetString(bytes);
                            //Parse out Bezel FileName
                            var bezelArtData = data.Split(new string[] { " /tmp" }, StringSplitOptions.None)[0];
                            var indexOfBoxArt = bezelArtData.kIndexOf("./boxart/", System.Globalization.CompareOptions.IgnoreCase);
                            bezelArtFileName = bezelArtData.Substring(indexOfBoxArt + 9).TrimEnd(new char[] { ' ', '\"' });

                            // /emulator/retroplayer ./emu/fceumm_libretro.so "./roms/Top gun.nes"

                            var emulatorData = data.Split(new string[] { "./roms" }, StringSplitOptions.None);
                            var indexOfEmulator = emulatorData[0].kIndexOf(" ./emu/", System.Globalization.CompareOptions.IgnoreCase);
                            emulatorFileName = emulatorData[0].Substring(indexOfEmulator + 7).TrimEnd(new char[] { ' ', '\"' });
                            vCart.EmulatorCoreFile = emulatorFileName;

                            var indexOfROM = emulatorData[1].kIndexOf("\n", System.Globalization.CompareOptions.IgnoreCase);
                            romFileName = emulatorData[1].Substring(1, indexOfROM - 1).TrimEnd(new char[] { ' ', '\"' });
                            vCart.ROMFile = romFileName;
                        }


                        //Cover Art (Boxart)
                        if (readCart.FileExists($"title.png"))
                        {
                            vCart.CoverArtFile = $"{_Settings.DefaultFolder_BoxArt}\\{vCart.Title.Replace(" ", "_")}_cover.png";
                            if (!File.Exists(vCart.CoverArtFile) || overwrite)
                            {
                                using (Stream bxArtFile = readCart.OpenFile($"title.png", FileMode.Open))
                                {
                                    Image.FromStream(bxArtFile).Save(vCart.CoverArtFile);
                                }
                            }
                            else
                            {
                                throw new Exception($"File {vCart.CoverArtFile} already exists in Vault");
                            }
                        }
                        //Bezel Art
                        if (readCart.FileExists($"boxart\\{bezelArtFileName}"))
                        {
                            vCart.BezelArtFile = $"{_Settings.DefaultFolder_BezelArt}\\{vCart.Title.Replace(" ", "_")}_bezel.png";
                            if (!File.Exists(vCart.BezelArtFile) || overwrite)
                            {
                                using (Stream bzArtFile = readCart.OpenFile($"boxart\\{bezelArtFileName}", FileMode.Open))
                                {
                                    Image.FromStream(bzArtFile).Save(vCart.BezelArtFile);
                                }
                            }
                            else
                            {

                                throw new Exception($"File {vCart.BezelArtFile} already exists in Vault");
                            }
                        }

                        //Emulator
                        if (readCart.FileExists($"emu\\{emulatorFileName}"))
                        {
                            using (Stream emuFile = readCart.OpenFile($"emu\\{emulatorFileName}", FileMode.Open))
                            {
                                vCart.EmulatorCoreFile = $"{_Settings.DefaultFolder_Cores}\\{emulatorFileName}";
                                if (!File.Exists(vCart.EmulatorCoreFile))
                                {
                                    using (var fileStream = File.Create(vCart.EmulatorCoreFile))
                                    {
                                        emuFile.Seek(0, SeekOrigin.Begin);
                                        emuFile.CopyTo(fileStream);
                                    }
                                }
                            }
                        }

                        //ROM
                        if (readCart.FileExists($"roms\\{romFileName}"))
                        {
                            using (Stream romFile = readCart.OpenFile($"roms\\{romFileName}", FileMode.Open))
                            {
                                vCart.ROMFile = $"{_Settings.DefaultFolder_ROMS}\\{romFileName.Replace(" ", "_")}";
                                if (!File.Exists(vCart.ROMFile) || overwrite)
                                {
                                    using (var fileStream = File.Create(vCart.ROMFile))
                                    {
                                        romFile.Seek(0, SeekOrigin.Begin);
                                        romFile.CopyTo(fileStream);
                                    }
                                }
                                else
                                {
                                    throw new Exception($"File {vCart.BezelArtFile} already exists in Vault");
                                }
                            }
                        }

                    }// end if exec.sh exists
                } // end if cartridge.xml exists
            }

            vCart.Index = -1;
            return vCart;
        }

        internal static string GetOverLayFileName(string coreFileName)
        {
            var fName = Path.GetFileNameWithoutExtension(coreFileName);
            if (!File.Exists($"{Directory.GetCurrentDirectory()}\\images\\overlays\\{fName}_OL.png"))
            {
                fName = "Unknown";
            }

            return $"{Directory.GetCurrentDirectory()}\\images\\overlays\\{fName}_OL.png";
        }
    }
}
