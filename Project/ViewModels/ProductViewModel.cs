using CommunityToolkit.Mvvm.ComponentModel;
using Project.Models;
using Project.Services;

namespace Project.ViewModels
{
    internal class ProductViewModel : ObservableObject, IProductViewModel
    {
        private ProductInformation _productInformation;
        private readonly IRestService _restService;

        public ProductViewModel()
        {
            _restService = new RestService();
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
    }
}
