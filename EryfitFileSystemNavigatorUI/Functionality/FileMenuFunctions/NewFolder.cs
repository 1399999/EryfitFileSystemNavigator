namespace EryfitFileSystemNavigatorUI.Functionality.FileMenuFunctions;

public static class NewFolder
{
    public static void LoadNewFolderFunctionalitySetup()
    {
        try 
        {
            NewFolderDialog dlg = new NewFolderDialog();
            dlg.ShowDialog(); 
        }
        catch 
        { 
            
        }
    }

    public static void LoadNewFolderFunctionality(this NewFolderDialog dlg)
    {
        var txt = dlg.NameTextBox.Text;

        if (!PathModel.Path.EndsWith(@":\"))
        {
            DirectoryInfo dirinfo = new DirectoryInfo(PathModel.Path + @"\" + txt);
            if (!dirinfo.Exists)
            {
                dirinfo.Create();
            }
            else
            {
                MessageBox.Show("The Directory " + txt + " already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        else
        {
            Directory.CreateDirectory(PathModel.Path + txt);
        }
    }
}

