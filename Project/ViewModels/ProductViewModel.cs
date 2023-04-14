using Project.Data;
using Project.Models;
using Project.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Project.ViewModels
{
    public class ProductViewModel : IProductViewModel
    {
        private IList<Product> _products;
        private readonly IProductDatabase _database;
        private readonly IRestService _restService;
        public event PropertyChangedEventHandler PropertyChanged;
        private string _text = string.Empty;

        public IList<Product> Products
        {
            get => _products;
            set
            {
                if (value != _products)
                {
                    _products = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                if (value != _text)
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
        }

        public ProductViewModel()
        {
            _database = new ProductDatabase();
            _products = new List<Product>();
            _restService = new RestService();
        }

        public async Task SearchGroceryProductsAsync(string query)
        {
            IList<Product> products = await _restService.SearchGroceryProductsAsync(query);
            foreach (Product product in products)
            {
                _ = await _database.CreateProductAsync(product);
            }
            Products = products;
            Text = "The products have been saved in the database.";
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
