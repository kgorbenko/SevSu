using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;
using PrintedEditionMdi.Annotations;
using PrintedEditionMdi.Models;
using PrintedEditionMdi.Utils;

namespace PrintedEditionMdi.ViewModels
{
    public class PrintedEditionControlViewModel : INotifyPropertyChanged
    {
        private CollectionView printedEditions;
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
            printedEditions = new CollectionView(Enumerable.Empty<PrintedEdition>());
        }

        public CollectionView PrintedEditions
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
            removeCommand ??= new RelayCommand(obj => PrintedEditions = new CollectionView(PrintedEditions.Cast<IEnumerable<PrintedEdition>>()).Where<IEnumerable<PrintedEdition>>(x => x != selectedItem));

        public ICommand SaveCommand =>
            saveCommand ??= new RelayCommand(obj => PrintedEditionSerializeHelper.Serialize(printedEditions,
                                                                                            obj as string));

        public ICommand OpenCommand =>
            openCommand ??= new RelayCommand(obj => PrintedEditions = new CollectionView(
                                                 PrintedEditionSerializeHelper.Deserialize(obj as string)));
    }
}