using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using PrintedEditionSdiApp.Annotations;
using PrintedEditionSdiApp.Models;

namespace PrintedEditionSdiApp.ViewModels
{
    public class PrintedEditionViewModel : INotifyPropertyChanged
    {
        private static PrintedEditionViewModel instance;
        private PrintedEdition selectedPrintedEdition;
        private PrintedEdition newPrintedEditionInfo;

        private RelayCommand addCommand;
        private RelayCommand removeCommand;

        public static PrintedEditionViewModel GetInstance()
        {
            return instance ??= new PrintedEditionViewModel();
        }

        public ObservableCollection<PrintedEdition> PrintedEditions { get; set; }
        public PrintedEdition NewPrintedEditionInfo
        {
            get => newPrintedEditionInfo;
            set
            {
                newPrintedEditionInfo = value;
                OnPropertyChanged(nameof(NewPrintedEditionInfo));
            }
    }

        public PrintedEdition SelectedPrintedEdition
        {
            get => selectedPrintedEdition;
            set
            {
                selectedPrintedEdition = value;
                OnPropertyChanged(nameof(SelectedPrintedEdition));
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??= new RelayCommand(obj =>
                {
                    if (obj is PrintedEdition edition)
                    {
                        AddPrintedEdition(edition);
                    }
                }, obj => true);
            }
            set => AddCommand = value;
        }

        /*public RelayCommand RemoveCommand
        {
            
        }*/

        public void AddPrintedEdition(PrintedEdition edition)
        {
            PrintedEditions.Add(edition);
        }

        private PrintedEditionViewModel()
        {
            PrintedEditions = new ObservableCollection<PrintedEdition>
            {
                new PrintedEdition {Name = "First", Author = "Some Random Dude", Price = 200},
                new PrintedEdition {Name = "Second", Author = "Another Random Dude", Price = 150},
                new PrintedEdition {Name = "Third", Author = "Other Random Dude", Price = 500},
                new PrintedEdition {Name = "Fourth", Author = "Dude", Price = 700}
            };
            AddCommand = new RelayCommand((obj) =>
            {
                PrintedEditions.Add(NewPrintedEditionInfo);
                
            }, (obj)=>true);
            newPrintedEditionInfo = new PrintedEdition();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}