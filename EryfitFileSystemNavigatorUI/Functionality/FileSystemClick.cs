namespace EryfitFileSystemNavigatorUI.Functionality;

public static class FileSystemClick
{
    public static void LoadFileSystemClickFunctionality(this MainWindow mw)
    {
        int index = mw.Directories.SelectedIndex;

        var newDir = mw.Directories.Items.GetItemAt(index);

        var newPath = PathModel.Path + "\\" + newDir;

        if (Directory.Exists(newPath))
        {
            try
            {
                if (newDir != "..")
                {
                    PathModel.Path += "\\";
                    PathModel.Path += newDir;
                }
                else
                {
                    string nwpth = "";
                    List<string> corpaths = new List<string>();

                    var spltpath = PathModel.Path.Split("\\").ToList();

                    foreach (var item in spltpath)
                    {
                        if (item != "")
                        {
                            corpaths.Add(item);
                        }
                    }

                    if (corpaths.Count > 1)
                    {
                        var spltpthlngth = corpaths.Count;

                        var newspl = spltpthlngth - 1;

                        for (int i = 0; i < newspl; i++)
                        {
                            nwpth += spltpath[i];
                            nwpth += "\\";
                        }

                        PathModel.Path = nwpth;
                    }
                    else
                    {
                        MessageBox.Show("Cannot go farther back than a drive.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                mw.CurrentDirectory.Text = PathModel.Path.ToString();

                List<DirectoryInfo> dirs = new List<DirectoryInfo>();
                List<FileInfo> files = new List<FileInfo>();

                var dirList = Directory.GetDirectories(PathModel.Path);
                var fileList = Directory.GetFiles(PathModel.Path);

                mw.Directories.Items.Clear();

                mw.Directories.Items.Add("..");

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
            catch
            {
                MessageBox.Show("Cannot go farther back than a drive.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        else if (File.Exists(newPath))
        {
            try
            {
                FileContents fc = new FileContents();

                FileInfo fl = new FileInfo(newPath);

                var lns = File.ReadLines(newPath).ToList();

                foreach (var ln in lns)
                {
                    fc.txt.Text += ln;
                    fc.txt.Text += "\n";
                }

                fc.Show();
            }
            catch
            {
                MessageBox.Show("An unexpected error occured.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        else
        {
            MessageBox.Show("Invalid Directory " + newPath, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

