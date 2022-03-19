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

    private void Directories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        int index = this.Directories.SelectedIndex;

        var newDir = Directories.Items.GetItemAt(index);

        if (Directory.Exists(PathModel.Path + "\\" + newDir))
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
        else
        {
            MessageBox.Show("Cannot open a file.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
