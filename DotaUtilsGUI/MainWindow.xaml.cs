using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DotaUtils.ServerLogHandling;
using DotaUtils.RequestHandling;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.Win32;
using System.ComponentModel;

namespace DotaUtilsGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly FileSystemWatcher Watcher = new()
        {
            Filter = "server_log.txt",
            NotifyFilter = NotifyFilters.LastWrite
        };

        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Player> _radiant;
        private ObservableCollection<Player> _dire;

        public ObservableCollection<Player> Radiant
        {
            get { return _radiant; }
            set
            {
                _radiant = value;
                NotifyPropertyChanged("Radiant");
            }
        }
        public ObservableCollection<Player> Dire
        {
            get { return _dire; }
            set
            {
                _dire = value;
                NotifyPropertyChanged("Dire");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Watcher.Changed += OnLogChange;
            if (!string.IsNullOrEmpty(UserSettings.Default.ServerLogLocationSetting))
            {
                ServerLogLocationBox.Text = UserSettings.Default.ServerLogLocationSetting;
            }
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private void ServerLogTextChanged(object sender, EventArgs e)
        {
            Watcher.Path = ServerLogLocationBox.Text.Replace("server_log.txt", "");
            Watcher.EnableRaisingEvents = true;
            UserSettings.Default.ServerLogLocationSetting = ServerLogLocationBox.Text;
            UserSettings.Default.Save();
        }

        private void ButtonLocationClick(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                DefaultExt = ".txt",
                Filter = "Server Log File|server_log.txt"
            };

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                ServerLogLocationBox.Text = filename;
            }
        }

        private async void OnLogChange(object sender, FileSystemEventArgs e)
		{
			var playerIds = Parser.ParseLog(e.FullPath);
			if (playerIds.Count == 0)
			{
				return;
			}

			var tasks = playerIds.Select(playerId => new Requests(playerId).GetPlayer());
			var players = await Task.WhenAll(tasks);
            Radiant = new ObservableCollection<Player>(players.Take(5));
            Dire = new ObservableCollection<Player>(players.TakeLast(5));
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
    }
}
