using System;

namespace Lab4
{
    public class Truck : Car, IVehicle
    {
        //Properties are not inherited from interface,
        //should be implemented manually

        public int NumberOFWheels { get; private set; }

        public string Type { get; private set; }

        public double Weight { get; private set; }

        public Truck() : base()
        {
            NumberOFWheels = 4;
            Type = "tipper";
            Weight = 1000;
        }

        public Truck(int numberOfWheels, string type, double weight, string model, int power, int maxSpeed) 
            : base(model, power, maxSpeed)
        {
            if (string.IsNullOrWhiteSpace(type)) throw new ArgumentNullException(nameof(type));
            if (numberOfWheels % 2 != 0) throw new ArgumentException("Number of wheels could not be even");
            if (weight <= 0) throw new ArgumentException("Weight could not be zero or less");

            NumberOFWheels = numberOfWheels;
            Type = type;
            Weight = weight;
        }

        public new string Status()
        {
            return $"Number of wheels: {NumberOFWheels}; " +
                   $"Type: {Type}; " +
                   $"Weight: {Weight}; " +
                   $"Model: {Model}; " +
                   $"Power: {Power}; " +
                   $"Max speed: {MaxSpeed}";
        }
    }
}
