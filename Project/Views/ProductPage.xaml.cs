using Project.Models;

namespace Project.Views;

public partial class ProductPage : ContentPage
{
    public ProductPage()
    {
        InitializeComponent();
    }

    private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Product product = e.SelectedItem as Product;
        if (product != null )
        {
            await Shell.Current.GoToAsync($"{nameof(MVVM.Views.FirstPage)}?productId={product.Id}");
        }
    }
}