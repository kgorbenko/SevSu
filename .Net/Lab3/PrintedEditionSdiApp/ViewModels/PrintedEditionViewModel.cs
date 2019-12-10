using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PrintedEditionSdiApp.Annotations;
using PrintedEditionSdiApp.Models;

namespace PrintedEditionSdiApp.ViewModels
{
    public class PrintedEditionViewModel : INotifyPropertyChanged
    {
        private PrintedEdition selectedPrintedEdition;

        public ObservableCollection<PrintedEdition> PrintedEditions { get; set; }

        public PrintedEdition SelectedPrintedEdition
        {
            get => selectedPrintedEdition;
            set {
                selectedPrintedEdition = value;
                OnPropertyChanged(nameof(SelectedPrintedEdition));
            }
        }

        public PrintedEditionViewModel()
        {
            PrintedEditions = new ObservableCollection<PrintedEdition>
            {
                new PrintedEdition {Name = "First", Author = "Some Random Dude", Price = 200},
                new PrintedEdition {Name = "Second", Author = "Another Random Dude", Price = 150},
                new PrintedEdition {Name = "Third", Author = "Other Random Dude", Price = 500},
                new PrintedEdition {Name = "Fourth", Author = "Dude", Price = 700}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}