namespace EryfitFileSystemNavigatorUI.Functionality;

public static class DriveClick
{
    public static void LoadDriveClickFunctionality(this MainWindow mw, object sender)
    {
        var btn = (Button)sender;
        var nm = btn.Content;

        if (nm != null)
        {
            try
            {
                mw.Directories.Items.Clear();

                PathModel.Path = nm.ToString();

                mw.CurrentDirectory.Text = PathModel.Path.ToString();

                var dirList = Directory.GetDirectories(PathModel.Path).ToList();
                var fileList = Directory.GetFiles(PathModel.Path).ToList();

                List<DirectoryInfo> dirs = new List<DirectoryInfo>();
                List<FileInfo> files = new List<FileInfo>();

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
                    mw.Directories.Items.Add(dr.Name);
                }

                foreach (var fl in files)
                {
                    mw.Directories.Items.Add(fl.Name);
                }
            }
            catch (Exception exptn)
            {
                MessageBox.Show(exptn.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

