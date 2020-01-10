using System.ComponentModel;
using System.Runtime.CompilerServices;
using PrintedEditionMdi.Annotations;

namespace PrintedEditionMdi.Models
{
    public class PrintedEdition : INotifyPropertyChanged
    {
        private string name;
        private string author;
        private double price;

        public int Id { get; set; }

        public string Name
        {
            get => name;
            set {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Author
        {
            get => author;
            set {
                author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        public double Price
        {
            get => price;
            set {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}