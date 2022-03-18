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
        catch
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

