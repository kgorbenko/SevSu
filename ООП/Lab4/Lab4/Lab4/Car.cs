using System;

namespace Lab4
{
    public class Car
    {
        public string Model { get; private set; }

        public int Power { get; private set; }

        public int MaxSpeed { get; private set; }

        public Car()
        {
            Model = "Mercedes";
            Power = 500;
            MaxSpeed = 300;
        }

        public Car(string model, int power, int maxSpeed)
        {
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentNullException(nameof(model));
            if (power <= 0) throw new ArgumentException("Power can not be zero or less");
            if (maxSpeed <= 0) throw new ArgumentException("Speed can not be zero or less");

            Model = model;
            Power = power;
            MaxSpeed = maxSpeed;
        }

        public string Status()
        {
            return $"Model: {Model}; " +
                   $"Power: {Power}; " +
                   $"Max speed {MaxSpeed};";
        }
    }
}