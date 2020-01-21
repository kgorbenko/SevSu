using Notepad.ViewModels;

namespace Notepad.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new NotepadControlViewModel();
        }
    }
}