using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IIngredientsViewModel
    {
        ICommand GoToSearchRecipePageCommand { get; }
    }
}