using Project.Models;
using Project.ViewModels;
using System.Collections.ObjectModel;

namespace Project.Views;

public partial class IngredientsPage : ContentPage
{
    public ObservableCollection<Product> ProductsSelected { get; set; } = new ObservableCollection<Product>();
    public IngredientsPage()
    {
        InitializeComponent();
    }
    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            if (e.CurrentSelection[0] is Product product)
            {
                ProductsSelected.Add(product);
                System.Diagnostics.Debug.WriteLine(product.Title);
            }
        }
    }
}