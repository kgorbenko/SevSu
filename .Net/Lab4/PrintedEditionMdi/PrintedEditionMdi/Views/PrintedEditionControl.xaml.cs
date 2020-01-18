using System.Windows;
using Microsoft.Win32;
using PrintedEditionMdi.ViewModels;

namespace PrintedEditionMdi.Views
{
    public partial class PrintedEditionControl
    {
        public PrintedEditionControl()
        {
            InitializeComponent();
        }

        private void SaveAsButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                FileName = "PrintedEditions",
                DefaultExt = "json",
                Filter = "Printed edition json (.json)|*.json"
            };

            if (dialog.ShowDialog() != true) return;

            if (DataContext is PrintedEditionControlViewModel viewModel &&
                viewModel.SaveCommand.CanExecute(new object()))
            {
                viewModel.SaveCommand.Execute(dialog.FileName);
            }
        }

        private void OpenButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Printed edition json (.json)|*.json"
            };

            if (dialog.ShowDialog() != true) return;

            if (DataContext is PrintedEditionControlViewModel viewModel &&
                viewModel.SaveCommand.CanExecute(new object()))
            {
                viewModel.OpenCommand.Execute(dialog.FileName);
            }
        }
    }
}