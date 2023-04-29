using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    internal interface IAllRecipesViewModel
    {
        string Label { get; }
        IList<Recipe> Recipes { get; set; }
    }
}
