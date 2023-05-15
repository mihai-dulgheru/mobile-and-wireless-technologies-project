using Project.Models;
using Project.ViewModels;

namespace Project.Views;

public partial class IngredientsPage : ContentPage
{
    public IngredientsPage()
    {
        InitializeComponent();
    }

    private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (searchBar.IsFocused)
        {
            if (e.CurrentSelection[0] is Ingredient ingredient)
            {
                ((IIngredientsViewModel)BindingContext).AddIngredientCommand.Execute(ingredient);
            }
        }
        else
        {
            ingredientCollectionView.SelectedItem = null;
        }
    }
}