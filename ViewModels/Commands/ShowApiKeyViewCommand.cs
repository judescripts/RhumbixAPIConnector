using System;
using System.Windows.Input;

namespace RhumbixAPIConnector.ViewModels.Commands
{
    public class ShowApiKeyViewCommand : ICommand
    {
        public ApiConnectorVm Vm { get; set; }

        public ShowApiKeyViewCommand(ApiConnectorVm vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            Vm.ShowApiKeyView();

        }

        public event EventHandler CanExecuteChanged;
    }
}
