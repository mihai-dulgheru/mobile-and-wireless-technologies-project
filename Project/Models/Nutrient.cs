namespace Project.Models
{
    public class Nutrient
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public float PercentOfDailyNeeds { get; set; }

        public Nutrient() { }

        public Nutrient(string name, int amount, string unit, float percentOfDailyNeeds)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Amount = amount;
            Unit = unit ?? throw new ArgumentNullException(nameof(unit));
            PercentOfDailyNeeds = percentOfDailyNeeds;
        }
    }
}
