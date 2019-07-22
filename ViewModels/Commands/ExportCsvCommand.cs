using System;
using System.Windows.Input;

namespace RhumbixAPIConnector.ViewModels.Commands
{
    public class ExportCsvCommand : ICommand
    {
        public ImportedVm Vm { get; set; }

        public ExportCsvCommand(ImportedVm vm)
        {
            Vm = vm;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Vm.ExportToCsv();
        }

        public event EventHandler CanExecuteChanged;
    }
}
