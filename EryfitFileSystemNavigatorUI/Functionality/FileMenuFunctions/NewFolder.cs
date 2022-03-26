namespace EryfitFileSystemNavigatorUI.Functionality.FileMenuFunctions;

public static class NewFolder
{
    public static void LoadNewFolderFunctionalitySetup()
    {
        NewFolderDialog dlg = new NewFolderDialog();
        dlg.ShowDialog(); 
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
            DirectoryInfo dirinfo = new DirectoryInfo(PathModel.Path + txt);

            if (!dirinfo.Exists)
            {
                dirinfo.Create();
            }
            else
            {
                MessageBox.Show("The Directory " + txt + " already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

