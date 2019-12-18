using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PrintedEditionSdiApp.Annotations;
using PrintedEditionSdiApp.Models;

namespace PrintedEditionSdiApp.ViewModels
{
    public class EditPrintedEditionViewModel : INotifyPropertyChanged
    {
        private PrintedEdition printedEditionToEdit;
        private readonly PrintedEditionViewModel printedEditionViewModel;
        private ICommand editPrintedEdition;

        public event PropertyChangedEventHandler PropertyChanged;

        public PrintedEdition PrintedEditionToEdit
        {
            get => printedEditionToEdit;
            set
            {
                printedEditionToEdit = value;
                OnPropertyChanged(nameof(PrintedEditionToEdit));
            }
        }

        public ICommand EditPrintedEdition =>
            editPrintedEdition ??= new RelayCommand(
                obj => ReplacePrintedEdition(printedEditionToEdit), 
                obj => true);

        public EditPrintedEditionViewModel(PrintedEdition printedEdition)
        {
            printedEditionToEdit = printedEdition ?? throw new ArgumentNullException(nameof(printedEdition));
            printedEditionViewModel = PrintedEditionViewModel.GetInstance();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ReplacePrintedEdition(PrintedEdition printedEdition)
        {
            if (printedEdition == null)
            {
                throw new ArgumentNullException(nameof(printedEdition));
            }
            
            printedEditionViewModel.ReplacePrintedEdition(printedEdition);
        }
    }
}