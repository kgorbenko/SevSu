using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Notepad.Annotations;
using Notepad.Utils;

namespace Notepad.ViewModels
{
    public class NotepadControlViewModel : INotifyPropertyChanged
    {
        private ICommand openCommand;
        private ICommand saveAsCommand;
        private ICommand saveCommand;
        private string fileContent;
        private string filePath;

        public string FileContent
        {
            get => fileContent;
            set
            {
                fileContent = value;
                OnPropertyChanged(nameof(FileContent));
            }
        }

        public ICommand OpenCommand => openCommand ??= new RelayCommand(obj =>
        {
            try
            {
                if (!(obj is string path)) return;

                FileContent = File.ReadAllText(path);
                filePath = path;
            }
            catch
            {
                filePath = string.Empty;
                throw;
            }
        });

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