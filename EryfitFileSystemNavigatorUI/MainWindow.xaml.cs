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
        this.NavigateStartUp();
    }

    public void Drives_Click(object sender, RoutedEventArgs e)
    {
        this.NavigateDriveClick(sender);
    }

    public void Directories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        this.NavigateFileSystemClick();
    }

    private void NewFileMenuItem_Click(object sender, RoutedEventArgs e)
    {
        NewFileDialog nfd = new NewFileDialog();
        nfd.ShowDialog();
    }

    private void NewFolderMenuItem_Click(object sender, RoutedEventArgs e)
    {
        NewFolderDialog nfd = new NewFolderDialog();
        nfd.ShowDialog();
    }
}
