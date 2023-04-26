namespace Project.Models
{
    internal class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }
        public int UsedIngredientCount { get; set; }
        public int MissedIngredientCount { get; set; }
        public IList<Ingredient> MissedIngredients { get; set; } = new List<Ingredient>();
        public IList<Ingredient> UsedIngredients { get; set; } = new List<Ingredient>();
        public IList<Ingredient> UnusedIngredients { get; set; } = new List<Ingredient>();
        public int Likes { get; set; }

        public Recipe() {}
    }
}
