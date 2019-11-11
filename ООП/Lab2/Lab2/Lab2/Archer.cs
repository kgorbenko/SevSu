namespace Lab2
{
    public class Archer : Unit
    {
        public int Range { get; private set; }

        public Archer(string name) : base(name)
        {
            Range = 10;
        }

        public Archer(string name, int health, int damage, int range) : base(name, health, damage) 
        {
            Range = range;
        }

        public override string Status()
        {
            return base.Status() + $"range:{Range};";
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}