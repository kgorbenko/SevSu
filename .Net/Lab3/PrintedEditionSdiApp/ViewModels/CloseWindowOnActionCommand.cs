using System;
using System.Windows;

namespace PrintedEditionSdiApp.ViewModels
{
    public class CloseWindowOnActionCommand : RelayCommand
    {
        protected readonly Window window;

        public CloseWindowOnActionCommand(Action<object> execute, Predicate<object> canExecute, Window window)
            : base(execute, canExecute)
        {
            this.window = window;
        }

        public override void Execute(object parameter)
        {
            execute(parameter);
            window.Close();
        }
    }
}