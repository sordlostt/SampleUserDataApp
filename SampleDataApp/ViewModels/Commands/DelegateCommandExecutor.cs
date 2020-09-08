using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SampleDataApp.ViewModels.Commands
{
    /// <summary>
    /// Used for generic delegate functions without parameters.
    /// </summary>
    public class DelegateCommandExecutor : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action _execute;
        public DelegateCommandExecutor(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
