using Project.Models;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IRecipeViewModel
    {
        ICommand AddOrDeleteRecipeCommand { get; }
        Recipe Recipe { get; set; }

        void ApplyQueryAttributes(IDictionary<string, object> query);
    }
}