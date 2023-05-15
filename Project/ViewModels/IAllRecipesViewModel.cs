using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IAllRecipesViewModel
    {
        string Label { get; }
        IList<Recipe> Recipes { get; set; }
        ICommand PerformSearchRecipe { get; }
    }
}
