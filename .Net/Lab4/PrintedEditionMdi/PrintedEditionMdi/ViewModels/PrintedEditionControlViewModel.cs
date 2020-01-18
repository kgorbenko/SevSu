using System;
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
        private readonly ICollectionView printedEditionsView;
        private ObservableCollection<PrintedEdition> printedEditions;
        private PrintedEdition selectedItem;
        private string filter;
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
            printedEditionsView = CollectionViewSource.GetDefaultView(printedEditions);
            printedEditionsView.Filter = x =>
            {
                if (string.IsNullOrEmpty(filter)) return true;
                if (!(x is PrintedEdition printedEdition)) return false;

                return printedEdition.ToString().Contains(filter);
            };
        }

        public ObservableCollection<PrintedEdition> PrintedEditions
        {
            get => printedEditions;
            set
            {
                printedEditions = value;
                printedEditionsView.Refresh();
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

        public string Filter
        {
            get => filter;
            set
            {
                if (filter == value) return;

                filter = value;
                printedEditionsView.Refresh();
                OnPropertyChanged(nameof(Filter));
            }
        }

        public ICommand RemoveCommand =>
            removeCommand ??= new RelayCommand(obj => printedEditions.Remove(selectedItem));

        public ICommand SaveCommand =>
            saveCommand ??= new RelayCommand(obj =>
                PrintedEditionSerializeHelper.Serialize(printedEditions, obj as string));

        public ICommand OpenCommand =>
            openCommand ??= new RelayCommand(obj =>
            {
                var currentDateAndTime = DateTime.Now;

                PrintedEditionSerializeHelper.Deserialize(obj as string)
                                             .Select(x => { x.CreatedAt = currentDateAndTime; return x; })
                                             .ForEach(x => PrintedEditions.Add(x));
            });
    }
}