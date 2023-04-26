namespace Project.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public string Unit { get; set; }
        public string UnitLong { get; set; }
        public string UnitShort { get; set; }
        public string Aisle { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
        public string OriginalName { get; set; }
        public string[] Meta { get; set; }
        public string Image { get; set; }

        public Ingredient() { }

        public Ingredient(int id, float amount, string unit, string unitLong, string unitShort, string aisle, string name, string original, string originalName, string[] meta, string image)
        {
            Id = id;
            Amount = amount;
            Unit = unit;
            UnitLong = unitLong;
            UnitShort = unitShort;
            Aisle = aisle;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Original = original;
            OriginalName = originalName;
            Meta = meta;
            Image = image ?? throw new ArgumentNullException(nameof(image));
        }
    }
}
