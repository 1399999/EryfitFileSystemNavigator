namespace EryfitFileSystemNavigatorUI.Functionality.Navigator;

public static class Navigator
{
    public static void NavigateStartUp(this MainWindow mw)
    {
        mw.LoadStartUpFunctionality();
    }

    public static void NavigateDriveClick(this MainWindow mw, object sender)
    {
        mw.LoadDriveClickFunctionality(sender);
    }

    public static void NavigateFileSystemClick(this MainWindow mw)
    {
        mw.LoadFileSystemClickFunctionality();
    }

    public static void NavigateNewFile()
    {
        NewFile.LoadNewFileFunctionality();
    }

    public static void NavigateNewFolder()
    {
        NewFolder.LoadNewFolderFunctionality();
    }
}
