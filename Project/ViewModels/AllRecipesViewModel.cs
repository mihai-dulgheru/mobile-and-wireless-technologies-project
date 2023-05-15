using CommunityToolkit.Mvvm.ComponentModel;
using Project.Models;
using Project.Services;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class AllRecipesViewModel : ObservableObject, IAllRecipesViewModel
    {
        public string Label { get; } = "Recommended recipes";
        private List<Recipe> _recipes = new();
        private readonly IRestService _restService;

        public ICommand PerformSearchRecipe => new Command<string>(async (string query) =>
        {
            IList<Recipe> recipes = await _restService.SearchRecipesAsync(query);
            List<string> searchResults = new();
            foreach (Recipe recipe in recipes)
            {
                searchResults.Add(recipe.Title);
            }
            Recipes = recipes;
        });

        public async void PerformSearchRecipe2(string query)
        {
            IList<Recipe> recipes = await _restService.SearchRecipesAsync(query);
            List<string> searchResults = new();
            foreach (Recipe recipe in recipes)
            {
                searchResults.Add(recipe.Title);
            }
            Recipes = recipes;
        }

        public AllRecipesViewModel()
        {
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            string ingredients = query["Ingredients"] as string;
            System.Diagnostics.Debug.WriteLine(ingredients);
            // TODO
            PerformSearchRecipe2(ingredients);
        }

        public IList<Recipe> Recipes
        {

            get => _recipes;
            //get
            //{

            //    //Mock data
            //    _recipes.Add(new Recipe
            //    {
            //        Id = 642582,
            //        Title = "Farfalle With Broccoli, Carrots and Tomatoes",
            //        Image = "https://spoonacular.com/recipeImages/642582-312x231.jpg",
            //        ImageType = "jpg",
            //        UsedIngredientCount = 2,
            //        MissedIngredientCount = 6,
            //        MissedIngredients = new List<Ingredient>
            //        {
            //            new Ingredient
            //            {
            //                Id = 10120420,
            //                Amount = 1.0,
            //                Unit = "pound",
            //                UnitLong = "pound",
            //                UnitShort = "lb",
            //                Aisle = "Pasta and Rice",
            //                Name = "farfalle pasta",
            //                Original = "1 pound farfalle pasta",
            //                OriginalName = "farfalle pasta",
            //                Meta = Array.Empty < string >(),
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/farfalle.png"
            //            },
            //            new Ingredient
            //            {
            //                Id = 4042,
            //                Amount = 2.0,
            //                Unit = "tablespoons",
            //                UnitLong = "tablespoons",
            //                UnitShort = "Tbsp",
            //                Aisle = "Oil, Vinegar, Salad Dressing",
            //                Name = "peanut oil",
            //                Original = "2 tablespoons peanut oil",
            //                OriginalName = "peanut oil",
            //                Meta = Array.Empty < string >(),
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/peanut-oil.jpg"
            //            },
            //            new Ingredient
            //            {
            //                Id = 11090,
            //                Amount = 2.0,
            //                Unit = "inches",
            //                UnitLong = "inches",
            //                UnitShort = "inches",
            //                Aisle = "Produce",
            //                Name = "broccoli heads",
            //                Original = "2 inches large broccoli heads (that's what she said)",
            //                OriginalName = "broccoli heads (that's what she said)",
            //                Meta = new string[] {"(that's what she said)"},
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/broccoli.jpg"
            //            },
            //            new Ingredient
            //            {
            //                Id = 11291,
            //                Amount = 2.0,
            //                Unit = "bunches",
            //                UnitLong = "bunches",
            //                UnitShort = "bunches",
            //                Aisle = "Produce",
            //                Name = "scallions",
            //                Original = "2 bunches of scallions",
            //                OriginalName = "scallions",
            //                Meta = Array.Empty < string >(),
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/spring-onions.jpg"
            //            },
            //            new Ingredient
            //            {
            //                Id = 10211215,
            //                Amount = 3.0,
            //                Unit = "",
            //                UnitLong = "",
            //                UnitShort = "",
            //                Aisle = "Produce",
            //                Name = "garlic cloves",
            //                Original = "3 garlic cloves, minced",
            //                OriginalName = "garlic cloves, minced",
            //                Meta = new string[] { "minced" },
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/garlic.jpg"
            //            },
            //            new Ingredient
            //            {
            //                Id = 1033,
            //                Amount = 1.0,
            //                Unit = "cup",
            //                UnitLong = "cup",
            //                UnitShort = "cup",
            //                Aisle = "Cheese",
            //                Name = "parmigiano-reggiano",
            //                Original = "1 cup + of Parmigiano-Reggiano, grated",
            //                OriginalName = "of Parmigiano-Reggiano, grated",
            //                Meta = new string[] { "grated" },
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/parmesan.jpg"
            //            }
            //        },
            //        UsedIngredients = new List<Ingredient>
            //        {
            //            new Ingredient
            //            {
            //                Id = 11124,
            //                Name = "carrots",
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/sliced-carrot.png",
            //                Amount = 3.0,
            //                Unit = "",
            //                UnitShort = "",
            //                UnitLong = "",
            //                Aisle = "Produce",
            //                Original = "3 carrots",
            //                OriginalName = "carrots",
            //                Meta = Array.Empty<string>()
            //            },
            //            new Ingredient
            //            {
            //                Id = 10111529,
            //                Name = "grape tomatoes",
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/cherry-tomatoes.png",
            //                Amount = 1.0,
            //                Unit = "container",
            //                UnitShort = "container",
            //                UnitLong = "container",
            //                Aisle = "Produce",
            //                Original = "1 container grape tomatoes",
            //                OriginalName = "grape tomatoes",
            //                Meta = Array.Empty<string>()
            //            }
            //        },
            //        UnusedIngredients = new List<Ingredient>(),
            //        Likes = 4,
            //        ReadyInMinutes = 40,
            //    });
            //    _recipes.Add(new Recipe
            //    {
            //        Id = 642582,
            //        Title = "Farfalle With Broccoli, Carrots and Tomatoes",
            //        Image = "https://spoonacular.com/recipeImages/642582-312x231.jpg",
            //        ImageType = "jpg",
            //        UsedIngredientCount = 2,
            //        MissedIngredientCount = 6,
            //        MissedIngredients = new List<Ingredient>
            //        {
            //            new Ingredient
            //            {
            //                Id = 10120420,
            //                Amount = 1.0,
            //                Unit = "pound",
            //                UnitLong = "pound",
            //                UnitShort = "lb",
            //                Aisle = "Pasta and Rice",
            //                Name = "farfalle pasta",
            //                Original = "1 pound farfalle pasta",
            //                OriginalName = "farfalle pasta",
            //                Meta = Array.Empty < string >(),
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/farfalle.png"
            //            },
            //            new Ingredient
            //            {
            //                Id = 4042,
            //                Amount = 2.0,
            //                Unit = "tablespoons",
            //                UnitLong = "tablespoons",
            //                UnitShort = "Tbsp",
            //                Aisle = "Oil, Vinegar, Salad Dressing",
            //                Name = "peanut oil",
            //                Original = "2 tablespoons peanut oil",
            //                OriginalName = "peanut oil",
            //                Meta = Array.Empty < string >(),
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/peanut-oil.jpg"
            //            },
            //            new Ingredient
            //            {
            //                Id = 11090,
            //                Amount = 2.0,
            //                Unit = "inches",
            //                UnitLong = "inches",
            //                UnitShort = "inches",
            //                Aisle = "Produce",
            //                Name = "broccoli heads",
            //                Original = "2 inches large broccoli heads (that's what she said)",
            //                OriginalName = "broccoli heads (that's what she said)",
            //                Meta = new string[] {"(that's what she said)"},
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/broccoli.jpg"
            //            },
            //            new Ingredient
            //            {
            //                Id = 11291,
            //                Amount = 2.0,
            //                Unit = "bunches",
            //                UnitLong = "bunches",
            //                UnitShort = "bunches",
            //                Aisle = "Produce",
            //                Name = "scallions",
            //                Original = "2 bunches of scallions",
            //                OriginalName = "scallions",
            //                Meta = Array.Empty < string >(),
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/spring-onions.jpg"
            //            },
            //            new Ingredient
            //            {
            //                Id = 10211215,
            //                Amount = 3.0,
            //                Unit = "",
            //                UnitLong = "",
            //                UnitShort = "",
            //                Aisle = "Produce",
            //                Name = "garlic cloves",
            //                Original = "3 garlic cloves, minced",
            //                OriginalName = "garlic cloves, minced",
            //                Meta = new string[] { "minced" },
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/garlic.jpg"
            //            },
            //            new Ingredient
            //            {
            //                Id = 1033,
            //                Amount = 1.0,
            //                Unit = "cup",
            //                UnitLong = "cup",
            //                UnitShort = "cup",
            //                Aisle = "Cheese",
            //                Name = "parmigiano-reggiano",
            //                Original = "1 cup + of Parmigiano-Reggiano, grated",
            //                OriginalName = "of Parmigiano-Reggiano, grated",
            //                Meta = new string[] { "grated" },
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/parmesan.jpg"
            //            }
            //        },
            //        UsedIngredients = new List<Ingredient>
            //        {
            //            new Ingredient
            //            {
            //                Id = 11124,
            //                Name = "carrots",
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/sliced-carrot.png",
            //                Amount = 3.0,
            //                Unit = "",
            //                UnitShort = "",
            //                UnitLong = "",
            //                Aisle = "Produce",
            //                Original = "3 carrots",
            //                OriginalName = "carrots",
            //                Meta = Array.Empty<string>()
            //            },
            //            new Ingredient
            //            {
            //                Id = 10111529,
            //                Name = "grape tomatoes",
            //                Image = "https://spoonacular.com/cdn/ingredients_100x100/cherry-tomatoes.png",
            //                Amount = 1.0,
            //                Unit = "container",
            //                UnitShort = "container",
            //                UnitLong = "container",
            //                Aisle = "Produce",
            //                Original = "1 container grape tomatoes",
            //                OriginalName = "grape tomatoes",
            //                Meta = Array.Empty<string>()
            //            }
            //        },
            //        UnusedIngredients = new List<Ingredient>(),
            //        Likes = 4,
            //        ReadyInMinutes = 40,
            //    });
            //    return _recipes;
            //}
            set
            {
                if (_recipes != value)
                {
                    _recipes = (List<Recipe>)value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
