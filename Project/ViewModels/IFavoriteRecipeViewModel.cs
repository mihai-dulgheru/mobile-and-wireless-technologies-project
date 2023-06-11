using Project.Models;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IFavoriteRecipeViewModel : IQueryAttributable
    {
        ICommand RemoveRecipeCommand { get; }
        Recipe Recipe { get; set; }
    }
}