using Microsoft.Win32;
using System;
using System.IO;

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

        public static void WriteToFile(string texts)
        {
            var systemPath = System.Environment.
                GetFolderPath(
                    Environment.SpecialFolder.CommonApplicationData
                );
            Directory.CreateDirectory(systemPath + @"\Rhumbix");
            var completePath = systemPath + @"\Rhumbix\status.txt";

            using (var sw = File.AppendText(completePath))
            {
                sw.WriteLine($"\n{texts}");
            }
        }

        public static void ClearAllTexts()
        {
            var systemPath = System.Environment.
                GetFolderPath(
                    Environment.SpecialFolder.CommonApplicationData
                );
            Directory.CreateDirectory(systemPath + @"\Rhumbix");
            var completePath = systemPath + @"\Rhumbix\status.txt";

            using (var sw = File.CreateText(completePath))
            {
                sw.Write(string.Empty);
            }
        }
    }
}
