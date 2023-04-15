using Project.Models;

namespace Project.ViewModels
{
    internal interface IProductViewModel : IQueryAttributable
    {
        ProductInformation ProductInformation { get; set; }
    }
}