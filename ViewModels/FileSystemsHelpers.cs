using Microsoft.Win32;

namespace RhumbixAPIConnector.ViewModels
{
    public class FileSystemsHelpers
    {
        public static string GetFilePath()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : null;
        }
    }
}
