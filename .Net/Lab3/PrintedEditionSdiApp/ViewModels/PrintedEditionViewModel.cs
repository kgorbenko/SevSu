using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using PrintedEditionSdiApp.Annotations;
using PrintedEditionSdiApp.Models;

namespace PrintedEditionSdiApp.ViewModels
{
    public class PrintedEditionViewModel : INotifyPropertyChanged
    {
        private static PrintedEditionViewModel instance;
        private PrintedEdition selectedPrintedEdition;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<PrintedEdition> PrintedEditions { get; set; }

        public PrintedEdition SelectedPrintedEdition
        {
            get => selectedPrintedEdition;
            set
            {
                selectedPrintedEdition = value;
                OnPropertyChanged(nameof(SelectedPrintedEdition));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static PrintedEditionViewModel GetInstance()
        {
            return instance ??= new PrintedEditionViewModel();
        }

        private PrintedEditionViewModel()
        {
            PrintedEditions = new ObservableCollection<PrintedEdition>
            {
                new PrintedEdition { Id = 1, Name = "First", Author = "Some Random Dude", Price = 200},
                new PrintedEdition { Id = 2, Name = "Second", Author = "Another Random Dude", Price = 150},
                new PrintedEdition { Id = 3, Name = "Third", Author = "Other Random Dude", Price = 500},
                new PrintedEdition { Id = 4, Name = "Fourth", Author = "Dude", Price = 700}
            };
        }

        public void AddPrintedEdition(PrintedEdition printedEdition)
        {
            if (printedEdition == null)
            {
                throw new ArgumentNullException(nameof(printedEdition));
            }

            if (printedEdition.Id == 0)
            {
                printedEdition.Id = GetUniqueId();
            }
            PrintedEditions.Add(printedEdition);
        }

        public void RemovePrintedEdition(PrintedEdition printedEdition)
        {
            if (printedEdition == null)
            {
                throw new ArgumentNullException(nameof(printedEdition));
            }

            if (PrintedEditions.Contains(printedEdition))
            {
                PrintedEditions.Remove(printedEdition);
            }
        }

        public void ReplacePrintedEdition(PrintedEdition printedEdition)
        {
            if (printedEdition == null)
            {
                throw new ArgumentNullException(nameof(printedEdition));
            }

            var oldPrintedEdition = PrintedEditions.FirstOrDefault(x => x.Id == printedEdition.Id);
            if (oldPrintedEdition != null);
            {
                oldPrintedEdition.Name = printedEdition.Name;
                oldPrintedEdition.Author = printedEdition.Author;
                oldPrintedEdition.Price = printedEdition.Price;
            }
        }

        private int GetUniqueId()
        {
            var generator = new Random();
            var uniqueId = 0;

            while (PrintedEditions.FirstOrDefault(x => x.Id == uniqueId) != null)
            {
                uniqueId = generator.Next();
            }

            return uniqueId;
        }
    }
}