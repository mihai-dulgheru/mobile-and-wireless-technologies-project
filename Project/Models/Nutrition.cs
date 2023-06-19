namespace Project.Models
{
    public class Nutrition
    {
        public Nutrient[] Nutrients { get; set; }
        public CaloricBreakdown CaloricBreakdown { get; set; }
        public float Calories { get; set; }
        public string Fat { get; set; }
        public string Protein { get; set; }
        public string Carbs { get; set; }

        public Nutrition() { }

        public Nutrition(Nutrient[] nutrients, CaloricBreakdown caloricBreakdown, float calories, string fat, string protein, string carbs)
        {
            Nutrients = nutrients ?? throw new ArgumentNullException(nameof(nutrients));
            CaloricBreakdown = caloricBreakdown ?? throw new ArgumentNullException(nameof(caloricBreakdown));
            Calories = calories;
            Fat = fat ?? throw new ArgumentNullException(nameof(fat));
            Protein = protein ?? throw new ArgumentNullException(nameof(protein));
            Carbs = carbs ?? throw new ArgumentNullException(nameof(carbs));
        }
    }
}