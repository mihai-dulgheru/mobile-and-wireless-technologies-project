using CommunityToolkit.Mvvm.ComponentModel;


namespace Project.ViewModels
{
    internal class ProductViewModel : ObservableObject, IProductViewModel
    {
        public string ProductId { get; set; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            ProductId = query["ProductId"] as string;
            OnPropertyChanged("ProductId");
        }
    }
}
