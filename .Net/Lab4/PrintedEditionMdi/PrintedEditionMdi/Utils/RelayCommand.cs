using System;
using System.Windows.Input;

namespace PrintedEditionMdi
{
    public class RelayCommand : ICommand
    {
        private readonly Action execute;

        public RelayCommand(Action execute)
        {
            this.execute = execute;
        }

        public virtual bool CanExecute(object parameter) => true;
        public virtual void Execute(object parameter) => execute.Invoke();

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}