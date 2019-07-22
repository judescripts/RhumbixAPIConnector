using System;
using System.Windows.Input;

namespace RhumbixAPIConnector.ViewModels.Commands
{
    public class ShowStatusViewCommand : ICommand
    {
        public ApiConnectorVm Vm { get; set; }

        public ShowStatusViewCommand(ApiConnectorVm vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            Vm.ShowStatusView();

        }

        public event EventHandler CanExecuteChanged;
    }
}
