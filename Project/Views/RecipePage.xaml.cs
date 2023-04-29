using Project.Models;

namespace Project.Views;

public partial class RecipePage : ContentPage
{
    public RecipePage()
    {
        InitializeComponent();

        Recipe recipe = new Recipe()
        {
            Title = "Recipe 1",
            Image = "https://aka.ms/campus.jpg",
            ImageType = "",
            UsedIngredientCount = 2,
            MissedIngredientCount = 2,
            MissedIngredients = new List<Ingredient> { new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" } },
            UsedIngredients = new List<Ingredient> { new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" } },
            UnusedIngredients = new List<Ingredient> { new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" }, new Ingredient { Name = "asdasd", Amount = 1, Unit = "ml" } },
            Likes = 20,
            Instructions = "Calul intra in padure, tagadam, tagadam,tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam ,tagadam, tagadam, tagadam, tagadam, tagadam ,tagadam, tagadam, tagadam tagadam,tagadam, tagadam, tagadam, tagadam, tagadam, tagadam,tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam ,tagadam, tagadam, tagadam, tagadam, tagadam ,tagadam, tagadam, tagadam tagadam,tagadam, tagadam, tagadam, tagadam, tagadam, tagadam,tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam ,tagadam, tagadam, tagadam, tagadam, tagadam ,tagadam, tagadam, tagadam tagadam,tagadam, tagadam, tagadam, tagadam, tagadam, tagadam,tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam, tagadam ,tagadam, tagadam, tagadam, tagadam, tagadam ,tagadam, tagadam, tagadam tagadam,tagadam, tagadam, tagadam, tagadam. Calul iese din padure."
        };

        BindingContext = recipe;
    }
}