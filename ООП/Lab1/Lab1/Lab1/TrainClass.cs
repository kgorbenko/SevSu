using System;
using System.Collections.Generic;

namespace Lab1
{
    //Train class. Normally should be named just Train.
    //Called like this to enable to add another 
    //implementation of same object within one solution
    public class TrainClass : ITrain
    {
        public string Destination { get; set; }
        public int Number { get; set; }
        public DateTime Departure { get; set; }

        public TrainClass() { }

        //constructor
        public TrainClass(string destination, int number, DateTime departure)
        {
            //null checks to prevent using of invalid 
            //parameters
            if (String.IsNullOrWhiteSpace(destination)) throw new ArgumentNullException(nameof(destination));

            Destination = destination;
            Number = number;
            Departure = departure;
        }

        //method to compare two ITrain objects
        public override bool Equals(object obj)
        {
            var anotherTrain = obj as ITrain;
            //same null check
            if (anotherTrain == null) throw new InvalidCastException(nameof(obj));

            return Departure.Equals(anotherTrain.Departure);
        }

        //method to get a full object status
        public override string ToString()
        {
            //string interpolation used
            return $"Train number {Number,5}; " +
                $"destination {Destination,20}; " +
                $"departure {Departure.ToString()}; " +
                $"type {GetType()}";
        }
    }
}
