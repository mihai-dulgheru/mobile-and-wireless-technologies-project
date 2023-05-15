using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    internal interface IRecipeViewModel : IQueryAttributable
    {
        Recipe Recipe { get; set; }
    }
}