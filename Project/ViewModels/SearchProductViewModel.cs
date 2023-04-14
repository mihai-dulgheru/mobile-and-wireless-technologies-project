using CommunityToolkit.Mvvm.Input;
using Project.Models;
using Project.Services;
using Project.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class SearchProductViewModel : ISearchProductViewModel
    {
        private List<Product> _products = new();
        private readonly IRestService _restService;
        public ICommand GoToHomePageCommand { get; private set; }
        public ICommand SelectProductCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public SearchProductViewModel()
        {
            _restService = new RestService();
            GoToHomePageCommand = new AsyncRelayCommand(GoToHomepageAsync);
            SelectProductCommand = new AsyncRelayCommand<Product>(SelectProductAsync);
        }

        private async Task GoToHomepageAsync()
        {
            await Shell.Current.GoToAsync(nameof(HomePage));
        }

        private async Task SelectProductAsync(Product product)
        {
            if (product != null)
            {
                await Shell.Current.GoToAsync($"{nameof(ProductPage)}?productId={product.Id}");
            }
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
