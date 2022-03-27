namespace EryfitFileSystemNavigatorUI.Functionality.FileMenuFunctions;

public static class NewFile
{
    public static void LoadNewFileFunctionality(this NewFileDialog nfd)
    {
        //SaveFileDialog sv = new SaveFileDialog();

        //sv.CheckFileExists = false;
        //sv.CreatePrompt = true;
        //sv.Title = "Create File - Eryfit";
        //sv.CheckPathExists = false;

        //var dialogResult = sv.ShowDialog();

        //if (dialogResult.Value == true)
        //{
        //    var pth = Path.GetFullPath(sv.FileName);

        //    if (!File.Exists(pth))
        //    {
        //        File.Create(pth);
        //    }
        //}
        //else
        //{

        //}

        var txt = nfd.NameTextBox.Text;

        if (!PathModel.Path.EndsWith(@":\"))
        {
            FileInfo fileinfo = new FileInfo(PathModel.Path + @"\" + txt);

            if (!fileinfo.Exists)
            {
                fileinfo.Create();
            }
            else
            {
                MessageBox.Show("The Directory " + txt + " already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        else
        {
            FileInfo fileinfo = new FileInfo(PathModel.Path + txt);

            if (!fileinfo.Exists)
            {
                fileinfo.Create();
            }
            else
            {
                MessageBox.Show("The Directory " + txt + " already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

