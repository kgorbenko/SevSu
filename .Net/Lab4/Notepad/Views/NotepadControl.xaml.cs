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

        private void Open(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "All files (*.*) | *.*"
            };

            if (dialog.ShowDialog() != true) return;

            if (DataContext is NotepadControlViewModel viewModel)
            {
                viewModel.OpenCommand.Execute(dialog.FileName);
                RichTextBox.Document.PageWidth = 500;
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (DataContext is NotepadControlViewModel viewModel)
            {
                if (string.IsNullOrWhiteSpace(viewModel.FilePath))
                {
                    SaveAs(sender, e);
                }
                else
                {
                    viewModel.SaveCommand.Execute(null);
                }
            }
        }

        private void SaveAs(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "All files (*.*) | *.*"
            };

            if (dialog.ShowDialog() != true) return;

            if (DataContext is NotepadControlViewModel viewModel)
            {
                viewModel.SaveAsCommand.Execute(dialog.FileName);
            }
        }
    }
}