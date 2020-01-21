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
                RichTextBox.Document.PageWidth = 500;
            }
        }

        private void SaveCommand(object sender, RoutedEventArgs e)
        {
            if (DataContext is NotepadControlViewModel viewModel &&
                viewModel.SaveCommand.CanExecute(new object()))
            {
                if (string.IsNullOrWhiteSpace(viewModel.FilePath))
                {
                    SaveAsCommand(sender, e);
                }
                else
                {
                    viewModel.SaveCommand.Execute(null);
                }
            }
        }

        private void SaveAsCommand(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "All files (*.*) | *.*"
            };

            if (dialog.ShowDialog() != true) return;

            if (DataContext is NotepadControlViewModel viewModel &&
                viewModel.SaveCommand.CanExecute(new object()))
            {
                viewModel.SaveCommand.Execute(dialog.FileName);
            }
        }
    }
}