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

        // TODO: Implement window open according to MVVM pattern
        private void AddPrintedEditionButtonClick(object sender, RoutedEventArgs e)
        {
            new PrintedEditionAddFormWindow().Show();
        }

        private void EditPrintedEditionButtonClick(object sender, RoutedEventArgs e)
        {
            var viewModel = PrintedEditionViewModel.GetInstance();
            new PrintedEditionEditFormWindow().Show();
        }
    }
}