using Project.Models;

namespace Project.Views;

public partial class SearchProductPage : ContentPage
{
    public SearchProductPage()
    {
        InitializeComponent();
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            if (e.CurrentSelection[0] is Product product)
            {
                await Shell.Current.GoToAsync($"{nameof(ProductPage)}?ProductId={product.Id}");
            }
        }
    }

}