using Project.ViewModels;

namespace Project.Views;

public partial class ProductPage : ContentPage
{
    public ProductPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await (BindingContext as IProductViewModel).SearchGroceryProductsAsync("Burger");
    }
}