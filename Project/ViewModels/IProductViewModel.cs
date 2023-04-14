using Project.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Project.ViewModels
{
    public interface IProductViewModel : INotifyPropertyChanged
    {
        IList<Product> Products { get; set; }

        void OnPropertyChanged([CallerMemberName] string name = "");
        Task SearchGroceryProductsAsync(string query);
    }
}