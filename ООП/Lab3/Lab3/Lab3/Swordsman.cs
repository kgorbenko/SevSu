using System.Collections.Generic;

namespace Lab3
{
    public class Swordsman : Unit
    {
        public int Armor { get; private set; }
        
        public Swordsman(string name) : base(name)
        {
            Armor = 0;
        }

        public Swordsman(string name, int health, int damage, int armor) : base(name, health, damage)
        {
            Armor = armor;
        }

        public override string Status()
        {
            return base.Status() + $"armor:{Armor};";
        }
    }
}
