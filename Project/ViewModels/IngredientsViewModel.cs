using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Models;
using Project.Services;
using Project.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class IngredientsViewModel : ObservableObject, ISearchProductViewModel
    {
        public List<Product> _products = new();
        public List<Product> _productsSelected = new();
        private readonly IRestService _restService;
        public ICommand SelectProductCommand { get; }
        public ICommand GoToSearchRecipePageCommand { get; }

        public IngredientsViewModel()
        {
            _restService = new RestService();
            SelectProductCommand = new AsyncRelayCommand<Product>(SelectProductAsync);
            GoToSearchRecipePageCommand = new AsyncRelayCommand(GoToSearchRecipePageAsync);
        }
        private async Task SelectProductAsync(Product product)
        {
            if (product != null)
            {
                await Shell.Current.GoToAsync($"{nameof(ProductPage)}?ProductId={product.Id}");
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
        private async Task GoToSearchRecipePageAsync()
        {
            await Shell.Current.GoToAsync(nameof(AllRecipesPage));
        }
    }
}
