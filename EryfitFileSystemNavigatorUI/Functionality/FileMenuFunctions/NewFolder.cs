namespace EryfitFileSystemNavigatorUI.Functionality.FileMenuFunctions;

public static class NewFolder
{
    public static void LoadNewFolderFunctionality()
    {
        NewFolderDialog dlg = new NewFolderDialog();
        dlg.ShowDialog();
    }
}

