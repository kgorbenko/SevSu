using System;

namespace Lab2
{
    public abstract class Unit
    {
        public string Name { get; }

        public int Health { get; private set; }

        public int Damage { get; private set; }

        public Unit(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
            Health = 100;
            Damage = 10;
        }

        public Unit(string name, int health, int damage)
        {
            if (String.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
            Health = health;
            Damage = damage;
        }

        public virtual string Status()
        {
            return $"Unit name:{Name};health:{Health};damage:{Damage};";
        }

        public abstract void mas();
    }
}