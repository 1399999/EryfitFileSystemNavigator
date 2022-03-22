namespace EryfitFileSystemNavigatorUI.Functionality;

public static class Startup
{
    public static void LoadStartUpFunctionality(this MainWindow mw)
    {
        try
        {
            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {

                Button btn = new Button()
                {
                    Content = drive.Name,
                    Height = 30,
                    Width = 50,
                };

                btn.Click += new RoutedEventHandler(mw.Drives_Click);

                mw.ButtonStackPanel.Children.Add(btn);
            }

            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            List<FileInfo> files = new List<FileInfo>();

            var dirList = Directory.GetDirectories(PathModel.Path).ToList();
            var fileList = Directory.GetFiles(PathModel.Path).ToList();

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

            mw.Directories.MouseDoubleClick += mw.Directories_MouseDoubleClick;
        }
        catch
        {

        }
    }
}

