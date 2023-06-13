using Project.Models;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IRecipeViewModel : IQueryAttributable
    {
        ICommand AddRecipeCommand { get; }
        bool IsBusy { get; set; }
        Recipe Recipe { get; set; }
        bool RecipeExists { get; set; }
    }
}