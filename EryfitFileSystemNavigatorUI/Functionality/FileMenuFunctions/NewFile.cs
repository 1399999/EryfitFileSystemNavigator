namespace EryfitFileSystemNavigatorUI.Functionality.FileMenuFunctions;

public static class NewFile
{
    public static void LoadNewFileFunctionality()
    {
        SaveFileDialog sv = new SaveFileDialog();

        sv.CheckFileExists = false;
        sv.CreatePrompt = true;
        sv.Title = "Create File - Eryfit";
        sv.CheckPathExists = false;

        var dialogResult = sv.ShowDialog();

        if (dialogResult.Value == true)
        {
            var pth = Path.GetFullPath(sv.FileName);

            if (!File.Exists(pth))
            {
                File.Create(pth);
            }
        }
        else
        {

        }
    }
}

