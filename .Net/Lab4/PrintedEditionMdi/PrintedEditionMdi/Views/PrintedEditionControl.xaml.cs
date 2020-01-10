using PrintedEditionMdi.ViewModels;

namespace PrintedEditionMdi.Views
{
    public partial class PrintedEditionControl
    {
        public PrintedEditionControl()
        {
            DataContext = PrintedEditionControlViewModel.GetInstance();
            InitializeComponent();
        }
    }
}