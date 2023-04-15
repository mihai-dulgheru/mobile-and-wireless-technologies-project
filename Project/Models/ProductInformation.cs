namespace Project.Models
{
    public class ProductInformation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string[] Breadcrumbs { get; set; }
        public string ImageType { get; set; }
        public string[] Badges { get; set; }
        public string[] ImportantBadges { get; set; }
        public int IngredientCount { get; set; }
        public string GeneratedText { get; set; }
        public string IngredientList { get; set; }
        public Ingredient[] Ingredients { get; set; }
        public int Likes { get; set; }
        public string Aisle { get; set; }
        public Nutrition Nutrition { get; set; }
        public int Price { get; set; }
        public Servings Servings { get; set; }

        public ProductInformation() { }

        public ProductInformation(int id, string title, string[] breadcrumbs, string imageType, string[] badges, string[] importantBadges, int ingredientCount, string generatedText, string ingredientList, Ingredient[] ingredients, int likes, string aisle, Nutrition nutrition, int price, Servings servings)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Breadcrumbs = breadcrumbs ?? throw new ArgumentNullException(nameof(breadcrumbs));
            ImageType = imageType ?? throw new ArgumentNullException(nameof(imageType));
            Badges = badges ?? throw new ArgumentNullException(nameof(badges));
            ImportantBadges = importantBadges ?? throw new ArgumentNullException(nameof(importantBadges));
            IngredientCount = ingredientCount;
            GeneratedText = generatedText ?? throw new ArgumentNullException(nameof(generatedText));
            IngredientList = ingredientList ?? throw new ArgumentNullException(nameof(ingredientList));
            Ingredients = ingredients ?? throw new ArgumentNullException(nameof(ingredients));
            Likes = likes;
            Aisle = aisle ?? throw new ArgumentNullException(nameof(aisle));
            Nutrition = nutrition ?? throw new ArgumentNullException(nameof(nutrition));
            Price = price;
            Servings = servings ?? throw new ArgumentNullException(nameof(servings));
        }
    }
}
