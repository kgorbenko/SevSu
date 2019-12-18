using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PrintedEditionSdiApp.Annotations;
using PrintedEditionSdiApp.Models;

namespace PrintedEditionSdiApp.ViewModels
{
    public class AddPrintedEditionViewModel : INotifyPropertyChanged
    {
        private PrintedEdition printedEditionToAdd;
        private readonly PrintedEditionViewModel printedEditionViewModel;
        private ICommand addPrintedEditionCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        public PrintedEdition PrintedEditionToAdd
        {
            get => printedEditionToAdd;
            set
            {
                printedEditionToAdd = value;
                OnPropertyChanged(nameof(PrintedEditionToAdd));
            }
        }

        public ICommand AddPrintedEditionCommand =>
            addPrintedEditionCommand ??= 
                new RelayCommand(
                    obj => AddPrintedEdition(printedEditionToAdd),
                    obj => true);

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AddPrintedEditionViewModel()
        {
            printedEditionToAdd = new PrintedEdition();
            printedEditionViewModel = PrintedEditionViewModel.GetInstance();
        }

        private void AddPrintedEdition(PrintedEdition printedEdition)
        {
            if (printedEdition == null)
            {
                throw new ArgumentNullException(nameof(printedEdition));
            }

            printedEditionViewModel.AddPrintedEdition(printedEdition);
        }
    }
}