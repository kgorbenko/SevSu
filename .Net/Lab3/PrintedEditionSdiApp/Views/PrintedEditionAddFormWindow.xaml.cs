using System.Windows;
using PrintedEditionSdiApp.ViewModels;

namespace PrintedEditionSdiApp.Views
{
    public partial class PrintedEditionAddFormWindow : Window
    {
        public PrintedEditionAddFormWindow()
        {
            InitializeComponent();
            DataContext = PrintedEditionViewModel.GetInstance();
        }
    }
}