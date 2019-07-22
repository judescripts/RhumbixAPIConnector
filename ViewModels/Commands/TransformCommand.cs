using System;
using System.Windows.Input;

namespace RhumbixAPIConnector.ViewModels.Commands
{
    public class TransformCommand : ICommand
    {
        public ImportedVm Vm { get; set; }

        public TransformCommand(ImportedVm vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Vm.TransformTurnerData();
        }

        public event EventHandler CanExecuteChanged;
    }


}
