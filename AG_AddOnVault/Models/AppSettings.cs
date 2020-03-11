/*
 * AG_AddOnVault
 * Component AppSettings
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
using System.IO;

namespace AG_AddOnTool.Models
{
    public class AppSettings
    {
        private string defaultFolder_AttractVideo;
        private string defaultFolder_BackgroundImage;
        private string defaultFolder_BackgroundMusic;
        private string defaultFolder_BezelArt;
        private string defaultFolder_BoxArt;
        private string defaultFolder_Cores;
        private string defaultFolder_ROMS;
        private string defaultFolder_UCE_Vault;
        private string defaultFolder_ALU_USBRoot;
        private string defaultFolder_Staging;
        private string defaultFolder_Working;
        private string theVault;
        private bool resizeImages;
        private bool useOverlay;
        private bool showBuildWindow;
        private bool useTabs;

        private readonly string[] defaultGenres = new[] { "Unknown","Action", "Adventure", "Fighting", "ha8800_background", "ha8800_background", "ha8800_screensaver", "Platform", "Pinball", "Puzzle", "Retro", "Shooter", "Sports", "Survival" };
        public AppSettings()
        {

            defaultFolder_UCE_Vault = "";
            theVault = $"{defaultFolder_UCE_Vault}\\TheVault.csv";
            defaultFolder_ALU_USBRoot = $"{defaultFolder_UCE_Vault}\\USB";
            defaultFolder_AttractVideo = $"{defaultFolder_UCE_Vault}\\Staging\\AttractVideo";
            defaultFolder_BackgroundImage = $"{defaultFolder_UCE_Vault}\\Staging\\BackgroundImage";
            defaultFolder_BackgroundMusic = $"{defaultFolder_UCE_Vault}\\Staging\\BackgroundMusic";
            defaultFolder_BezelArt = $"{defaultFolder_UCE_Vault}\\Staging\\BezelArt";
            defaultFolder_BoxArt = $"{defaultFolder_UCE_Vault}\\Staging\\BoxArt";
            defaultFolder_Cores = $"{defaultFolder_UCE_Vault}\\Staging\\Cores";
            defaultFolder_ROMS = $"{defaultFolder_UCE_Vault}\\Staging\\ROMS";
            defaultFolder_Staging = $"{defaultFolder_UCE_Vault}\\Staging";
            defaultFolder_Working = $"{defaultFolder_UCE_Vault}\\Working";
            resizeImages = false;
            useOverlay = false;
            showBuildWindow = false;
            useTabs = false;
        }

        public AppSettings(string rootDir, bool createNew)
        {
            if (createNew)
            {
                if (!Directory.Exists(rootDir))
                {
                    Directory.CreateDirectory(rootDir);
                }
                defaultFolder_UCE_Vault = rootDir;
                theVault = $"{rootDir}\\TheVault.csv";
                defaultFolder_ALU_USBRoot = $"{defaultFolder_UCE_Vault}\\USB";
                defaultFolder_AttractVideo = $"{defaultFolder_UCE_Vault}\\Staging\\AttractVideo";
                defaultFolder_BackgroundImage = $"{defaultFolder_UCE_Vault}\\Staging\\BackgroundImage";
                defaultFolder_BackgroundMusic = $"{defaultFolder_UCE_Vault}\\Staging\\BackgroundMusic";
                defaultFolder_BezelArt = $"{defaultFolder_UCE_Vault}\\Staging\\BezelArt";
                defaultFolder_BoxArt = $"{defaultFolder_UCE_Vault}\\Staging\\BoxArt";
                defaultFolder_Cores = $"{defaultFolder_UCE_Vault}\\Staging\\Cores";
                defaultFolder_ROMS = $"{defaultFolder_UCE_Vault}\\Staging\\ROMS";
                defaultFolder_Staging = $"{defaultFolder_UCE_Vault}\\Staging";
                defaultFolder_Working = $"{defaultFolder_UCE_Vault}\\Working";
                resizeImages = false;
                useOverlay = false;
                showBuildWindow = false;
                useTabs = false;

            }
        }

        public bool ResizeImages { get => resizeImages; set => resizeImages = value; }
        public bool ShowBuildWindow { get => showBuildWindow; set => showBuildWindow = value; }
        public bool UseTabs { get => useTabs; set => useTabs = value; }
        public bool UserOverlay { get => useOverlay; set => useOverlay = value; }

        public string DefaultFolder_USBRoot { get => CheckDir(defaultFolder_ALU_USBRoot); set => defaultFolder_ALU_USBRoot = value; }

        public string DefaultFolder_Staging { get => CheckDir(defaultFolder_Staging); set => defaultFolder_Staging = value; }

        public string DefaultFolder_Working { get => CheckDir(defaultFolder_Working); set => defaultFolder_Working = value; }

        public string DefaultFolder_AttractVideo { get => CheckDir(defaultFolder_AttractVideo); set => defaultFolder_AttractVideo = value; }

        public string DefaultFolder_BackgroundImage { get => CheckDir(defaultFolder_BackgroundImage); set => defaultFolder_BackgroundImage = value; }

        public string DefaultFolder_BackgroundMusic { get => CheckDir(defaultFolder_BackgroundMusic); set => defaultFolder_BackgroundMusic = value; }

        public string DefaultFolder_BezelArt { get => CheckDir(defaultFolder_BezelArt); set => defaultFolder_BezelArt = value; }

        public string DefaultFolder_BoxArt { get => CheckDir(defaultFolder_BoxArt); set => defaultFolder_BoxArt = value; }

        public string DefaultFolder_Cores { get => CheckDir(defaultFolder_Cores); set => defaultFolder_Cores = value; }

        public string DefaultFolder_ROMS { get => CheckDir(defaultFolder_ROMS); set => defaultFolder_ROMS = value; }

        public string TheVault { get => theVault; set => theVault = value; }
        public string DefaultFolder_UCE_Vault
        {
            get
            {
                CheckDir(defaultFolder_UCE_Vault);
                CheckDir(defaultFolder_UCE_Vault + "\\USB");
                foreach (string folder in defaultGenres)
                {
                    CheckDir(defaultFolder_UCE_Vault + "\\USB\\" + folder);
                }
                return defaultFolder_UCE_Vault;
            }

            set => defaultFolder_UCE_Vault = value;
        }

        private string CheckDir(string dirName)
        {
            if (!Directory.Exists(dirName))
            {
                try
                {
                    Directory.CreateDirectory(dirName);
                }
                catch (Exception ex)
                {
                    return $"Error on create: {ex.Message}";
                }
            }

            return dirName;
        }
    }
}
