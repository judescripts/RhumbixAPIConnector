using RhumbixAPIConnector.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace RhumbixAPIConnector.ViewModels.Commands
{
    public class RefreshDataCommand : ICommand
    {
        public ImportedVm Vm { get; set; }

        public RefreshDataCommand(ImportedVm vm)
        {
            Vm = vm;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is ImportedWindow)
                {
                    window.Close();
                    var importedWin = new ImportedWindow();
                    importedWin.Show();
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
