using System.IO;
using System.Windows;
using Microsoft.Win32;
using MahApps.Metro.Controls;
using SiraOrganizer.Utilities;
using MahApps.Metro.Controls.Dialogs;

namespace SiraOrganizer
{
    public partial class MainWindow : MetroWindow
    {
        public string Greeting { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Greeting = SiraUtils.GetRandomGreeting();
            DataContext = this;
        }

        private async void FindBeatSaberDir_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                DefaultExt = ".exe",
                Filter = "Beat Saber (.exe)|Beat Saber.exe"
            };
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                string directory = new FileInfo(dialog.FileName).Directory.FullName;
                try
                {
                    string version = BeatSaberUtils.GetVersion(directory);
                    App.Settings.BeatSaberDirectory = directory;
                    await this.ShowMessageAsync("Found Beat Saber Folder", $"Game Version: v{version}.");
                }
                catch
                {
                    await this.ShowMessageAsync("Could not find Beat Saber", "Beat Saber installation not detected.");
                    return;
                }
            }
            else
            {
                await this.ShowMessageAsync("Could not find path.", "No path specified.");
            }
        }
    }
}