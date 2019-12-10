using System.Windows;
using System.Windows.Controls;
using PrintedEditionSdiApp.ViewModels;

namespace PrintedEditionSdiApp.Views
{
    public partial class PrintedEditionControl : Page
    {
        public PrintedEditionControl()
        {
            InitializeComponent();

            DataContext = new PrintedEditionViewModel();
        }

        // TODO: Implement window open according to MVVM pattern
        private void AddPrintedEditionButtonClick(object sender, RoutedEventArgs e)
        {
            new PrintedEditionFormWindow().Show();
        }
    }
}