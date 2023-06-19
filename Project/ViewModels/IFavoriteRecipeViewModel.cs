using Project.Models;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IFavoriteRecipeViewModel : IQueryAttributable
    {
        Recipe Recipe { get; set; }
        ICommand RemoveRecipeCommand { get; }
    }
}