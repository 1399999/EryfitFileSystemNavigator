namespace EryfitFileSystemNavigatorUI;

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
        try
        {
            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                //ButtonStackPanel.Children.Add(new Button()
                //{
                //    Content = drive.Name,
                //    Height = 30,
                //    Width = 50,
                //    Click += new EventHandler(Drives_Click)
                //});

                Button btn = new Button()
                {
                    Content = drive.Name,
                    Height = 30,
                    Width = 50,
                };

                btn.Click += new RoutedEventHandler(Drives_Click);

                ButtonStackPanel.Children.Add(btn);
            }

            //ButtonStackPanel.MouseRightButtonDown += Drives_Click;

            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            List<FileInfo> files = new List<FileInfo>();

            var dirList = Directory.GetDirectories(PathModel.Path).ToList();
            var fileList = Directory.GetFiles(PathModel.Path).ToList();

            foreach (string dir in dirList)
            {
                DirectoryInfo dirinfo = new DirectoryInfo(dir);

                dirs.Add(dirinfo);
            }

            foreach (string file in fileList)
            {
                FileInfo filinfo = new FileInfo(file);

                files.Add(filinfo);
            }

            foreach (var dr in dirs)
            {
                Directories.Items.Add(dr.Name);
            }

            foreach (var fl in files)
            {
                Directories.Items.Add(fl.Name);
            }

            Directories.MouseDoubleClick += Directories_MouseDoubleClick;
        }
        catch
        {

        }
    }

    private void Drives_Click(object sender, RoutedEventArgs e)
    {
        var btn = (Button)sender;
        var nm = btn.Content;

        if (nm != null)
        {
            try
            {
                Directories.Items.Clear();

                PathModel.Path = nm.ToString();

                CurrentDirectory.Text = PathModel.Path.ToString();

                var dirList = Directory.GetDirectories(PathModel.Path).ToList();
                var fileList = Directory.GetFiles(PathModel.Path).ToList();

                List<DirectoryInfo> dirs = new List<DirectoryInfo>();
                List<FileInfo> files = new List<FileInfo>();

                foreach (string dir in dirList)
                {
                    DirectoryInfo dirinfo = new DirectoryInfo(dir);

                    dirs.Add(dirinfo);
                }

                foreach (string file in fileList)
                {
                    FileInfo filinfo = new FileInfo(file);

                    files.Add(filinfo);
                }

                foreach (var dr in dirs)
                {
                    Directories.Items.Add(dr.Name);
                }

                foreach (var fl in files)
                {
                    Directories.Items.Add(fl.Name);
                }
            }
            catch (Exception exptn)
            {
                MessageBox.Show(exptn.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    private void Directories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        int index = Directories.SelectedIndex;

        var newDir = Directories.Items.GetItemAt(index);

        var newPath = PathModel.Path + "\\" + newDir;

        if (Directory.Exists(newPath))
        {
            try
            {
                if (newDir != "..")
                {
                    PathModel.Path += "\\";
                    PathModel.Path += newDir;
                }
                else
                {
                    string nwpth = "";
                    List<string> corpaths = new List<string>();

                    var spltpath = PathModel.Path.Split("\\").ToList();

                    foreach (var item in spltpath)
                    {
                        if (item != "")
                        {
                            corpaths.Add(item);
                        }
                    }

                    if (corpaths.Count > 1)
                    {
                        var spltpthlngth = corpaths.Count;

                        var newspl = spltpthlngth - 1;

                        for (int i = 0; i < newspl; i++)
                        {
                            nwpth += spltpath[i];
                            nwpth += "\\";
                        }

                        PathModel.Path = nwpth;
                    }
                    else
                    {
                        MessageBox.Show("Cannot go farther back than a drive.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                CurrentDirectory.Text = PathModel.Path.ToString();

                List<DirectoryInfo> dirs = new List<DirectoryInfo>();
                List<FileInfo> files = new List<FileInfo>();

                var dirList = Directory.GetDirectories(PathModel.Path);
                var fileList = Directory.GetFiles(PathModel.Path);

                Directories.Items.Clear();

                Directories.Items.Add("..");

                foreach (string dir in dirList)
                {
                    DirectoryInfo dirinfo = new DirectoryInfo(dir);

                    dirs.Add(dirinfo);
                }

                foreach (string file in fileList)
                {
                    FileInfo filinfo = new FileInfo(file);

                    files.Add(filinfo);
                }

                foreach (var dr in dirs)
                {
                    Directories.Items.Add(dr.Name);
                }

                foreach (var fl in files)
                {
                    Directories.Items.Add(fl.Name);
                }
            }
            catch
            {
                MessageBox.Show("Cannot go farther back than a drive.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        else if (File.Exists(newPath))
        {
            try
            {
                FileContents fc = new FileContents();

                FileInfo fl = new FileInfo(newPath);

                var lns = File.ReadLines(newPath).ToList();

                foreach (var ln in lns)
                {
                    fc.txt.Text += ln;
                    fc.txt.Text += "\n";
                }

                fc.Show();
            }
            catch
            {
                MessageBox.Show("An unexpected error occured.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        else
        {
            MessageBox.Show("Invalid Directory " + newPath, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
