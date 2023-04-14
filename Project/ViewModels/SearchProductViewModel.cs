using Project.Models;
using Project.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class SearchProductViewModel : ISearchProductViewModel
    {
        private List<Product> _products = new();
        private readonly IRestService _restService;
        public event PropertyChangedEventHandler PropertyChanged;

        public SearchProductViewModel()
        {
            _restService = new RestService();
        }

        public ICommand PerformSearch => new Command<string>(async (string query) =>
        {
            IList<Product> products = await _restService.SearchGroceryProductsAsync(query);
            List<string> searchResults = new();
            foreach (Product product in products)
            {
                searchResults.Add(product.Title);
            }
            Products = products;
        });

        public IList<Product> Products
        {
            get => _products;
            set
            {
                if (_products != value)
                {
                    _products = (List<Product>)value;
                    OnPropertyChanged();
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
