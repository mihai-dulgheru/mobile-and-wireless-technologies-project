﻿using Project.Models;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IRecipeViewModel : IQueryAttributable
    {
        ICommand AddRecipeCommand { get; }
        Recipe Recipe { get; set; }
    }
}