using System.Windows;
using PrintedEditionSdiApp.ViewModels;

namespace PrintedEditionSdiApp.Views
{
    public partial class PrintedEditionEditFormWindow : Window
    {
        public PrintedEditionEditFormWindow()
        {
            InitializeComponent();
            DataContext = PrintedEditionViewModel.GetInstance();
        }
    }
}