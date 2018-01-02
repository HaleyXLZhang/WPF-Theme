/*
* ==============================================================================
*
* File name: MyCommand.cs
* Description: 
* 
*
* Version: 1.0
* Created: 1/3/2018 1:16:30 AM
*
* Author: Haley X L Zhang
* Company: Chinasoft International
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CreationTemplate.Common
{
    public class MyCommand : ICommand
    {
        private Func<object, bool> _canExecute;
        private Action<object> _execute;

        public MyCommand(Action<object> execute) : this(execute, null) { }

        public MyCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

      
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null) return true;
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (_execute != null && CanExecute(parameter))
            {
                _execute(parameter);
            }
        }
    }
}
