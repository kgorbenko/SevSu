using System;

namespace Lab3
{
    public abstract class Unit
    {
        public string Name { get; private set; }

        public int Health { get; private set; }

        public int Damage { get; private set; }

        public Unit(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
            Health = 100;
            Damage = 10;
        }

        public Unit(string name, int health, int damage)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
            Health = health;
            Damage = damage;
        }

        public bool IsAlive()
        {
            return Health > 0; 
        }

        public virtual string Status()
        {
            return $"name:{Name};health:{Health};damage:{Damage};alive:{IsAlive()};";
        }
    }
}