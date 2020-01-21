using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Notepad.Annotations;

namespace Notepad.ViewModels
{
    public class NotepadControlViewModel : INotifyPropertyChanged
    {
        private ICommand openCommand;
        private ICommand saveAsCommand;
        private ICommand saveCommand;
        private string filePath;
        private string fileContent;

        public string FileContent
        {
            get => fileContent;
            set
            {
                fileContent = value;
                OnPropertyChanged(nameof(FileContent));
            }
        }

        public ICommand OpenCommand => throw new NotImplementedException();
        public ICommand SaveCommand => throw new NotImplementedException();
        public ICommand SaveAsCommand => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}