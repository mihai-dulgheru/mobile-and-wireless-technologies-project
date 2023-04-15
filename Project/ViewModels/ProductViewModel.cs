using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Data;
using Project.Models;
using Project.Services;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class ProductViewModel : ObservableObject, IProductViewModel
    {
        private ProductInformation _productInformation;
        private readonly IProductDatabase _productDatabase;
        private readonly IRestService _restService;
        public ICommand AddProductCommand { get; }

        public ProductViewModel()
        {
            _productDatabase = new ProductDatabase();
            _restService = new RestService();
            AddProductCommand = new AsyncRelayCommand(AddProductAsync);
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            string productId = query["ProductId"] as string;
            ProductInformation productInformation = await _restService.GetProductInformationAsync(productId);
            if (productInformation != null)
            {
                ProductInformation = productInformation;
            }
        }

        public ProductInformation ProductInformation
        {
            get => _productInformation;
            set
            {
                if (_productInformation != value)
                {
                    _productInformation = value;
                    OnPropertyChanged();
                }
            }
        }

        private async Task AddProductAsync()
        {
            _ = await _productDatabase.CreateProductAsync(new Product(_productInformation.Id, _productInformation.Title, _productInformation.Image, _productInformation.ImageType));
            await Shell.Current.GoToAsync("..");
        }
    }
}
