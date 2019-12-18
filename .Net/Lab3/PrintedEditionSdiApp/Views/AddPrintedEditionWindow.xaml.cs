using System.Windows;
using PrintedEditionSdiApp.ViewModels;

namespace PrintedEditionSdiApp.Views
{
    public partial class AddPrintedEditionWindow : Window
    {
        public AddPrintedEditionWindow()
        {
            InitializeComponent();
            DataContext = new AddPrintedEditionViewModel();
        }
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}