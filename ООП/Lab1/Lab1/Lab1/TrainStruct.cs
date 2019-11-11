using System;

namespace Lab1
{
    //Train struct. Normally should be named just Train.
    //Called like this to enable to add another 
    //implementation of same object within one solution
    public struct TrainStruct : ITrain
    {
        public string Destination { get; set; }
        public int Number { get; set; }
        public DateTime Departure { get; set; }

        //Struct should normally have a constructor.
        //No constructor here because of the attempt to 
        //stick to condition of task

        //Constructor gets created automatically

        //Method to compare two ITrain objects
        public override bool Equals(object obj)
        {
            var train = (ITrain)obj;

            return Departure.Equals(train.Departure);
        }

        //Method to get full object status
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
