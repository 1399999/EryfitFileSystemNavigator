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

namespace EryfitFileSystemNavigatorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var drives = DriveInfo.GetDrives();

            try
            {
                var dirList = Directory.GetDirectories("C:\\");

                foreach (string dir in dirList)
                {
                    Directories.Items.Add(dir);
                }

                Directories.MouseDoubleClick += Directories_MouseDoubleClick;
            }
            catch (Exception)
            {

            }
        }

        private void Directories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = this.Directories.SelectedIndex;

            var newDir = Directories.Items.GetItemAt(index);

            CurrentDirectory.Text = newDir.ToString();

            var dirList = Directory.GetDirectories(CurrentDirectory.Text);

            Directories.Items.Clear();

            foreach (string dir in dirList)
            {
                Directories.Items.Add(dir);
            }
        }
    }
}
