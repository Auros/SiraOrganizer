using System.Windows;
using MahApps.Metro.Controls;
using SiraOrganizer.Windows;

namespace SiraOrganizer
{
    public partial class MainWindow : MetroWindow
    {
        private FindBeatSaberDirectory _findBeatSaberDirectory;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FindBeatSaberDir_Click(object sender, RoutedEventArgs e)
        {
            if (_findBeatSaberDirectory == null || _findBeatSaberDirectory.IsDisposed)
            {
                _findBeatSaberDirectory = new FindBeatSaberDirectory();
                _findBeatSaberDirectory.Show();
            }
            if (!_findBeatSaberDirectory.IsFocused)
            {
                _findBeatSaberDirectory.Focus();
            }
        }
    }
}