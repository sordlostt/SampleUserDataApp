using SampleDataApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SampleDataApp.ViewModels.Commands
{
    public class RemoveUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<IUser> _execute;

        public RemoveUserCommand(Action<IUser> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter as IUser);
        }
    }
}
