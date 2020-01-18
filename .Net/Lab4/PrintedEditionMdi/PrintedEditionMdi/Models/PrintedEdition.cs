using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace PrintedEditionMdi.Models
{
    public class PrintedEdition : INotifyPropertyChanged
    {
        private string name;
        private string author;
        private double price;
        private DateTime createdAt;

        public PrintedEdition()
        {
            createdAt = DateTime.Now;
        }

        public PrintedEdition(string name, string author, double price, DateTime createdAt)
        {
            this.name = name;
            this.author = author;
            this.price = price;
            this.createdAt = createdAt;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

        [JsonIgnore]
        public DateTime CreatedAt
        {
            get => createdAt;
            set {
                createdAt = value;
                OnPropertyChanged(nameof(CreatedAt));
            }
        }

        public override string ToString() =>
            FormattableString.Invariant($"{Name}, {Author}, {Price}, {CreatedAt:dd/MM/yyyy}");
    }
}