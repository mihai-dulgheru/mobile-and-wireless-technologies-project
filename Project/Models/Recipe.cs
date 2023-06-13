using Project.Converters;
using SQLite;

namespace Project.Models
{
    [Table("Recipes")]
    public class Recipe
    {
        private string _instructions;

        [Ignore]
        public IList<Ingredient> ExtendedIngredients { get; set; } = new List<Ingredient>();
        [Ignore]
        public IList<Ingredient> MissedIngredients { get; set; } = new List<Ingredient>();
        [Ignore]
        public IList<Ingredient> UnusedIngredients { get; set; } = new List<Ingredient>();
        [Ignore]
        public IList<Ingredient> UsedIngredients { get; set; } = new List<Ingredient>();
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }
        [Ignore]
        public int Likes { get; set; }
        [Ignore]
        public int MissedIngredientCount { get; set; }
        [Column("ready_in_minutes")]
        public int ReadyInMinutes { get; set; }
        [Ignore]
        public int UsedIngredientCount { get; set; }
        [MaxLength(250)]
        [Column("image")]
        public string Image { get; set; }
        [Ignore]
        public string ImageType { get; set; }
        [Ignore]
        public string Ingredients => UsedIngredientCount + MissedIngredientCount > 0
                    ? string.Join(", ", MissedIngredients.Concat(UsedIngredients).Select(ingredient => ingredient.Name))
                    : string.Empty;
        [Column("instructions")]
        public string Instructions
        {
            get => !string.IsNullOrEmpty(_instructions) ? _instructions : "No instructions provided for this recipe.";
            set
            {
                _instructions = value;
                if (!string.IsNullOrEmpty(_instructions))
                {
                    _instructions = HTMLToStringConverter.Convert(_instructions);
                }
            }
        }
        [MaxLength(250)]
        [Column("title")]
        public string Title { get; set; }
        [MaxLength(250)]
        [Column("ingredients")]
        public string StoredIngredients { get; set; }

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

        public Recipe(int id, string title, string image, IList<Ingredient> extendedIngredients, string instructions, int readyInMinutes)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Image = image ?? throw new ArgumentNullException(nameof(image));
            ExtendedIngredients = extendedIngredients ?? throw new ArgumentNullException(nameof(extendedIngredients));
            Instructions = instructions ?? throw new ArgumentNullException(nameof(title));
            ReadyInMinutes = readyInMinutes;
        }

        public void SetIngredients()
        {
            StoredIngredients = string.Join(", ", ExtendedIngredients.Select(ingredient => ingredient.Name));
        }
    }
}
