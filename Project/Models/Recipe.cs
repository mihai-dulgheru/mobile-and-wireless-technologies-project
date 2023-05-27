using Project.Converters;

namespace Project.Models
{
    public class Recipe
    {
        private string _instructions;

        public IList<Ingredient> ExtendedIngredients { get; set; } = new List<Ingredient>();
        public IList<Ingredient> MissedIngredients { get; set; } = new List<Ingredient>();
        public IList<Ingredient> UnusedIngredients { get; set; } = new List<Ingredient>();
        public IList<Ingredient> UsedIngredients { get; set; } = new List<Ingredient>();
        public int Id { get; set; }
        public int Likes { get; set; }
        public int MissedIngredientCount { get; set; }
        public int ReadyInMinutes { get; set; }
        public int UsedIngredientCount { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }
        public string Ingredients => UsedIngredientCount + MissedIngredientCount > 0
                    ? string.Join(", ", MissedIngredients.Concat(UsedIngredients).Select(ingredient => ingredient.Name))
                    : string.Empty;
        public string Instructions
        {
            get => _instructions;
            set
            {
                _instructions = value;
                if (!string.IsNullOrEmpty(_instructions))
                {
                    _instructions = HTMLToStringConverter.Convert(_instructions);
                }
            }
        }
        public string Title { get; set; }

        public Recipe() { }

        public Recipe(int id, string title, string image, string imageType, int usedIngredientCount, int missedIngredientCount, IList<Ingredient> missedIngredients, IList<Ingredient> usedIngredients, IList<Ingredient> unusedIngredients, IList<Ingredient> extendedIngredients, int likes, string instructions, int readyInMinutes)
        {
            ExtendedIngredients = extendedIngredients ?? throw new ArgumentNullException(nameof(extendedIngredients));
            Id = id;
            Image = image ?? throw new ArgumentNullException(nameof(image));
            ImageType = imageType ?? throw new ArgumentNullException(nameof(imageType));
            Instructions = instructions ?? throw new ArgumentNullException(nameof(title));
            Likes = likes;
            MissedIngredientCount = missedIngredientCount;
            MissedIngredients = missedIngredients ?? throw new ArgumentNullException(nameof(missedIngredients));
            ReadyInMinutes = readyInMinutes;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            UnusedIngredients = unusedIngredients ?? throw new ArgumentNullException(nameof(unusedIngredients));
            UsedIngredientCount = usedIngredientCount;
            UsedIngredients = usedIngredients ?? throw new ArgumentNullException(nameof(usedIngredients));
        }

        public Recipe(int id, string title, string image, /*IList<Ingredient> usedIngredients,*/ IList<Ingredient> extendedIngredients, string instructions)
        {
            ExtendedIngredients = extendedIngredients ?? throw new ArgumentNullException(nameof(extendedIngredients));
            Id = id;
            Image = image ?? throw new ArgumentNullException(nameof(image));
            Instructions = instructions ?? throw new ArgumentNullException(nameof(title));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            //UsedIngredients = usedIngredients ?? throw new ArgumentNullException(nameof(usedIngredients));
        }
    }
}
