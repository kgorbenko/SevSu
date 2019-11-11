namespace Lab3
{
    class ShieldBearer : Swordsman
    {
        public int Defence { get; set; }

        public ShieldBearer(string name) : base(name)
        {
            Defence = 5;
        }

        public ShieldBearer(string name, int health, int damage, int armor, int defence) : base(name, health, damage, armor)
        {
            Defence = defence;
        }

        public string Status()
        {
            return base.Status() + $"defence:{Defence};";
        }
    }
}
