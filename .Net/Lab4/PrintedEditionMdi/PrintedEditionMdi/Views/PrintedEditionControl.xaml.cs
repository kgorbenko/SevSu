using System.Windows;
using System.Windows.Data;
using Microsoft.Win32;
using PrintedEditionMdi.Models;
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

        private void FilterButtonClick(object sender, RoutedEventArgs e)
        {
            if (!(DataContext is PrintedEditionControlViewModel viewModel)) return;

            var filter = Filter.Text;
            CollectionViewSource.GetDefaultView(viewModel.PrintedEditions).Filter = x =>
            {
                var printedEdition = x as PrintedEdition;

                return printedEdition.Name.Contains(filter)
                    || printedEdition.Author.Contains(filter)
                    || printedEdition.Price.ToString().Contains(filter)
                    || printedEdition.CreatedAt.ToString("d").Contains(filter);
            };
        }
    }
}