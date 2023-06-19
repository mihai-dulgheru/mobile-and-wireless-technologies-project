namespace Project.Models
{
    public class ProductInformation
    {
        public string Aisle { get; set; }
        public string[] Badges { get; set; }
        public string Brand { get; set; }
        public string[] Breadcrumbs { get; set; }
        public string Description { get; set; }
        public string GeneratedText { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }
        public string[] Images { get; set; }
        public string[] ImportantBadges { get; set; }
        public int IngredientCount { get; set; }
        public string IngredientList { get; set; }
        public int Likes { get; set; }
        public Nutrition Nutrition { get; set; }
        public int Price { get; set; }
        public Servings Servings { get; set; }
        public float SpoonacularScore { get; set; }
        public string Title { get; set; }
        public string Upc { get; set; }

        public ProductInformation() { }

        public ProductInformation(string aisle, string[] badges, string brand, string[] breadcrumbs, string description, string generatedText, int id, string image, string imageType, string[] images, string[] importantBadges, int ingredientCount, string ingredientList, Ingredient[] ingredients, int likes, Nutrition nutrition, int price, Servings servings, float spoonacularScore, string title, string upc)
        {
            Aisle = aisle ?? throw new ArgumentNullException(nameof(aisle));
            Badges = badges ?? throw new ArgumentNullException(nameof(badges));
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            Breadcrumbs = breadcrumbs ?? throw new ArgumentNullException(nameof(breadcrumbs));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            GeneratedText = generatedText ?? throw new ArgumentNullException(nameof(generatedText));
            Id = id;
            Image = image ?? throw new ArgumentNullException(nameof(image));
            ImageType = imageType ?? throw new ArgumentNullException(nameof(imageType));
            Images = images ?? throw new ArgumentNullException(nameof(images));
            ImportantBadges = importantBadges ?? throw new ArgumentNullException(nameof(importantBadges));
            IngredientCount = ingredientCount;
            IngredientList = ingredientList ?? throw new ArgumentNullException(nameof(ingredientList));
            Likes = likes;
            Nutrition = nutrition ?? throw new ArgumentNullException(nameof(nutrition));
            Price = price;
            Servings = servings ?? throw new ArgumentNullException(nameof(servings));
            SpoonacularScore = spoonacularScore;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Upc = upc ?? throw new ArgumentNullException(nameof(upc));
        }
    }
}