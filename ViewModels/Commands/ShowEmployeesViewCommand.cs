using System;
using System.Windows.Input;

namespace RhumbixAPIConnector.ViewModels.Commands
{
    public class ShowEmployeesViewCommand : ICommand
    {
        public ApiConnectorVm Vm { get; set; }

        public ShowEmployeesViewCommand(ApiConnectorVm vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            Vm.ShowEmployeesView();

        }

        public event EventHandler CanExecuteChanged;
    }
}
