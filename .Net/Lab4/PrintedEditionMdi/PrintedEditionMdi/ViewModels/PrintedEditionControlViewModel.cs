using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PrintedEditionMdi.Annotations;
using PrintedEditionMdi.Models;
using PrintedEditionMdi.Utils;

namespace PrintedEditionMdi.ViewModels
{
    public class PrintedEditionControlViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PrintedEdition> printedEditions;
        private PrintedEdition selectedItem;
        private ICommand removeCommand;
        private ICommand saveCommand;
        private ICommand openCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public PrintedEditionControlViewModel()
        {
            printedEditions = new ObservableCollection<PrintedEdition>();
        }

        public ObservableCollection<PrintedEdition> PrintedEditions
        {
            get => printedEditions;
            set
            {
                printedEditions = value;
                OnPropertyChanged(nameof(PrintedEditions));
            }
        }

        public PrintedEdition SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ICommand RemoveCommand =>
            removeCommand ??= new RelayCommand(obj => PrintedEditions.Remove(selectedItem));

        public ICommand SaveCommand =>
            saveCommand ??= new RelayCommand(obj => PrintedEditionSerializeHelper.Serialize(printedEditions,
                                                                                            obj as string));

        public ICommand OpenCommand =>
            openCommand ??= new RelayCommand(obj => PrintedEditions = new ObservableCollection<PrintedEdition>(
                                                 PrintedEditionSerializeHelper.Deserialize(obj as string)));
    }
}