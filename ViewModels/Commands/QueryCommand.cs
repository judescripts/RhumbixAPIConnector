using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RhumbixAPIConnector.Models;

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
            if (parameter is Queries selectedQueries) Vm.RunQueryAsync(selectedQueries);
        }

        public event EventHandler CanExecuteChanged;
    }
}
