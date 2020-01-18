using System;
using System.Collections.Generic;
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
        private ICollectionView printedEditions;
        private PrintedEdition selectedItem;
        private ICommand removeCommand;
        private ICommand saveCommand;
        private ICommand openCommand;
        private ICommand filterCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public PrintedEditionControlViewModel()
        {
            printedEditions = new CollectionView(Enumerable.Empty<PrintedEdition>());
        }

        public ICollectionView PrintedEditions
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
            removeCommand ??= new RelayCommand(obj => PrintedEditions =
                                                   new CollectionView(PrintedEditions.Cast<object?>()
                                                                          .Where(item => !item.Equals(SelectedItem))));

        public ICommand SaveCommand =>
            saveCommand ??= new RelayCommand(obj => PrintedEditionSerializeHelper.Serialize(printedEditions as IEnumerable<PrintedEdition>,
                                                                                            obj as string));

        public ICommand OpenCommand =>
            openCommand ??= new RelayCommand(obj => PrintedEditions = new CollectionView(PrintedEditionSerializeHelper.Deserialize(obj as string)));

        public ICommand FilterCommand =>
            filterCommand ??= new RelayCommand(obj => PrintedEditions.Filter = obj as Predicate<object>);
    }
}