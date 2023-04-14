using Project.Models;

namespace Project.Views;

public partial class SearchProductPage : ContentPage
{
    public SearchProductPage()
    {
        InitializeComponent();
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Product)
        {
            //await Shell.Current.GoToAsync($"{nameof(MVVM.Views.FirstPage)}?productId={product.Id}");
        }
    }

}