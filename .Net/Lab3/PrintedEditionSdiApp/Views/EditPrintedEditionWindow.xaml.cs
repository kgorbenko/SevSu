using System.Windows;

namespace PrintedEditionSdiApp.Views
{
    public partial class EditPrintedEditionWindow : Window
    {
        public EditPrintedEditionWindow()
        {
            InitializeComponent();
        }
        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}