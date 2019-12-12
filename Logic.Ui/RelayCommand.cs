using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace De.HsFlensburg.LernkartenApp001.Logic.Ui
{
    public class RelayCommand : ICommand
    {

        private readonly Action WhatToExecute;
        private readonly Func<bool> WhenToExecute;
        public RelayCommand(Action What, Func<bool> When)
        {
            this.WhatToExecute = What;
            this.WhenToExecute = When;
        }
        public bool CanExecute(object parameter)
        {
            return WhenToExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            WhatToExecute();
        }
    }
}
