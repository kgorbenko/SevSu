using System.Windows;
using System.Windows.Controls;
using PrintedEditionSdiApp.Models;
using PrintedEditionSdiApp.ViewModels;

namespace PrintedEditionSdiApp.Views
{
    public partial class PrintedEditionControl : Page
    {
        public PrintedEditionControl()
        {
            InitializeComponent();
        }
        private void AddPrintedEditionButtonClick(object sender, RoutedEventArgs e)
        {
            new AddPrintedEditionWindow().Show();
        }

        private void EditPrintedEditionButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var parent = button.Parent;
            var printedEdition = button.DataContext as PrintedEdition;
            var editPrintedEditionWindow = new EditPrintedEditionWindow
            {
                DataContext = new EditPrintedEditionViewModel(printedEdition)
            };
            
            editPrintedEditionWindow.Show();
        }
    }
}