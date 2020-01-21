using System;
using System.Windows;
using Microsoft.Win32;
using Notepad.ViewModels;

namespace Notepad.Views
{
    public partial class NotepadControl
    {
        public NotepadControl()
        {
            InitializeComponent();
        }

        private void OpenCommand(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "All files (*.*) | *.*"
            };

            if (dialog.ShowDialog() != true) return;

            if (DataContext is NotepadControlViewModel viewModel &&
                viewModel.OpenCommand.CanExecute(new object()))
            {
                viewModel.OpenCommand.Execute(dialog.FileName);
            }
        }

        private void SaveCommand(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveAsCommand(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}