using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SampleDataApp.ViewModels.Commands
{
    public class OpenAddUserWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _execute;

        public OpenAddUserWindowCommand(Action execute)
        {
            _execute = execute;
        }


        public bool CanExecute(object parameter)
        {
            if (AddUserWindowViewModel.CanOpen)
            {
                return true;
            }
            else
                return false;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
