using System.Windows;
using PrintedEditionSdiApp.ViewModels;

namespace PrintedEditionSdiApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = PrintedEditionViewModel.GetInstance();
        }
    }
}