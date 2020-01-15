using System.Windows;
using System.Windows.Threading;

namespace PrintedEditionMdi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs eventArgs)
        {
            eventArgs.Handled = true;
            MessageBox.Show(eventArgs.Exception.Message);
        }
    }
}