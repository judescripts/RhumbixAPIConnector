using RhumbixAPIConnector.Models;
using System;
using System.Windows.Input;

namespace RhumbixAPIConnector.ViewModels.Commands
{
    public class QueryCommand : ICommand
    {
        public ApiConnectorVm Vm { get; set; }

        public QueryCommand(ApiConnectorVm vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is Queries selectedQueries) Vm.RhumbixApiTaskQueues(selectedQueries);
        }

        public event EventHandler CanExecuteChanged;
    }
}
