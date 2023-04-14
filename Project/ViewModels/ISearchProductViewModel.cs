using Project.Models;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface ISearchProductViewModel
    {
        ICommand PerformSearch { get; }
        ICommand SelectProductCommand { get; }
        IList<Product> Products { get; set; }
    }
}