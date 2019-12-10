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
    }
}