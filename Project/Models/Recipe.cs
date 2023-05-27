namespace Project.Models
{
    public class Recipe
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
        public IList<Ingredient> ExtendedIngredients { get; set; } = new List<Ingredient>();
        public int Likes { get; set; }
        public string Ingredients => UsedIngredientCount + MissedIngredientCount > 0
                    ? string.Join(", ", MissedIngredients.Concat(UsedIngredients).Select(ingredient => ingredient.Name))
                    : string.Empty;
        public string Instructions { get; set; }
        public int ReadyInMinutes { get; set; }


        public Recipe() { }

        public Recipe(int id, string title, string image, string imageType, int usedIngredientCount, int missedIngredientCount, IList<Ingredient> missedIngredients, IList<Ingredient> usedIngredients, IList<Ingredient> unusedIngredients, IList<Ingredient> extendedIngredients, int likes, string instructions, int readyInMinutes)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Image = image ?? throw new ArgumentNullException(nameof(image));
            ImageType = imageType ?? throw new ArgumentNullException(nameof(imageType));
            UsedIngredientCount = usedIngredientCount;
            MissedIngredientCount = missedIngredientCount;
            MissedIngredients = missedIngredients ?? throw new ArgumentNullException(nameof(missedIngredients));
            UsedIngredients = usedIngredients ?? throw new ArgumentNullException(nameof(usedIngredients));
            UnusedIngredients = unusedIngredients ?? throw new ArgumentNullException(nameof(unusedIngredients));
            ExtendedIngredients = extendedIngredients ?? throw new ArgumentNullException(nameof(extendedIngredients));
            Likes = likes;
            Instructions = instructions ?? throw new ArgumentNullException(nameof(title));
            ReadyInMinutes = readyInMinutes;
        }

        public Recipe(int id, string title, string image, /*IList<Ingredient> usedIngredients,*/ IList<Ingredient> extendedIngredients, string instructions)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Image = image ?? throw new ArgumentNullException(nameof(image));
            //UsedIngredients = usedIngredients ?? throw new ArgumentNullException(nameof(usedIngredients));
            ExtendedIngredients = extendedIngredients ?? throw new ArgumentNullException(nameof(extendedIngredients));
            Instructions = instructions ?? throw new ArgumentNullException(nameof(title));
        }
    }
}
