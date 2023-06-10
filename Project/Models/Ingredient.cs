using SQLite;

namespace Project.Models
{
    [Table("Ingredients")]
    public class Ingredient
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("amount")]
        public double Amount { get; set; }
        [Column("unit")]
        public string Unit { get; set; }
        [Ignore]
        public string UnitLong { get; set; }
        [Ignore]
        public string UnitShort { get; set; }
        [Ignore]
        public string Aisle { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Ignore]
        public string Original { get; set; }
        [Ignore]
        public string OriginalName { get; set; }
        [Ignore]
        public string[] Meta { get; set; }
        [Ignore]
        public string Image { get; set; }
        [Column("recipe_id")]
        public int RecipeId { get; set; }

        public Ingredient() { }

        public Ingredient(int id, double amount, string unit, string unitLong, string unitShort, string aisle, string name, string original, string originalName, string[] meta, string image)
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

        public Ingredient(int id, double amount, string unit)
        {
            Id = id;
            Amount = amount;
            Unit = unit;
        }
    }
}
