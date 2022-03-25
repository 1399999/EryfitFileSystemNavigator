namespace EryfitFileSystemNavigatorUI.Functions;

public static class MainListBox
{
    public static void ClearLsBx(this MainWindow mw)
    {
        mw.Directories.Items.Clear();
    }
}
