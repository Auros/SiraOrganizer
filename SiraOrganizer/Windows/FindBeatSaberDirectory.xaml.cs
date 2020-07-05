using System.Windows;
using MahApps.Metro.Controls;
using System.ComponentModel;

namespace SiraOrganizer.Windows
{
    public partial class FindBeatSaberDirectory : MetroWindow
    {
        public bool IsDisposed { get; private set; }

        public FindBeatSaberDirectory()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            IsDisposed = true;
        }
    }
}