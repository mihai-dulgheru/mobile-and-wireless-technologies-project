namespace Project.Models
{
    public class Nutrition
    {
        public Nutrient[] Nutrients { get; set; }
        public CaloricBreakdown CaloricBreakdown { get; set; }

        public Nutrition() { }

        public Nutrition(Nutrient[] nutrients, CaloricBreakdown caloricBreakdown)
        {
            Nutrients = nutrients ?? throw new ArgumentNullException(nameof(nutrients));
            CaloricBreakdown = caloricBreakdown ?? throw new ArgumentNullException(nameof(caloricBreakdown));
        }
    }
}
