using CommunityToolkit.Mvvm.ComponentModel;
using Project.Models;
using Project.Services;

namespace Project.ViewModels
{
    internal class ProductViewModel : ObservableObject, IProductViewModel
    {
        public string ProductId { get; set; }
        public string Text { get; set; } = string.Empty;
        private readonly IRestService _restService;

        public ProductViewModel()
        {
            _restService = new RestService();
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            ProductId = query["ProductId"] as string;
            OnPropertyChanged("ProductId");
            ProductInformation productInformation = await _restService.GetProductInformationAsync(ProductId);
            if (productInformation != null)
            {
                Text = "Succes";
                OnPropertyChanged("Text");
            }
        }
    }
}
