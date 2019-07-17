using System;
using System.Windows.Input;

namespace RhumbixAPIConnector.ViewModels.Commands
{
    public class ShowImportedViewCommand : ICommand
    {
        public ApiConnectorVm Vm { get; set; }

        public ShowImportedViewCommand(ApiConnectorVm vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Vm.ShowImportedView();
        }

        public event EventHandler CanExecuteChanged;
    }
}
