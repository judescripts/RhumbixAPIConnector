using RhumbixAPIConnector.Models;
using System;
using System.Windows.Input;

namespace RhumbixAPIConnector.ViewModels.Commands
{
    public class SaveTokenCommand : ICommand
    {
        public ApiKeysVm Vm { get; set; }

        public SaveTokenCommand(ApiKeysVm vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            if (parameter is Tokens savedTokens) Vm.EncryptAndSaveTokenAsync(savedTokens);

        }

        public event EventHandler CanExecuteChanged;
    }
}
