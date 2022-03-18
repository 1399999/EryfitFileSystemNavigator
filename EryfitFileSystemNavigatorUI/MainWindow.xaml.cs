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
            var dirList = Directory.GetDirectories("C:\\").ToList();
            var fileList = Directory.GetFiles("C:\\").ToList();

            foreach (string dir in dirList)
            {
                Directories.Items.Add(dir);
            }

            foreach (string file in fileList)
            {
                Directories.Items.Add(file);
            }

            Directories.MouseDoubleClick += Directories_MouseDoubleClick;
        }
        catch
        {

        }
    }

    private void Directories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        try
        {
            int index = this.Directories.SelectedIndex;

            var newDir = Directories.Items.GetItemAt(index);

            CurrentDirectory.Text = newDir.ToString();

            var dirList = Directory.GetDirectories(CurrentDirectory.Text);
            var fileList = Directory.GetFiles(CurrentDirectory.Text);

            Directories.Items.Clear();

            foreach (string dir in dirList)
            {
                Directories.Items.Add(dir);
            }

            foreach (var file in fileList)
            {
                Directories.Items.Add(file);
            }
        }
        catch 
        {
            MessageBox.Show("Cannot open a file.", "Error");
        }
    }
}
