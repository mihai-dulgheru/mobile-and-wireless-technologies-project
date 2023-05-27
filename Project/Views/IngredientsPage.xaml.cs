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
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0 && e.CurrentSelection[0] is Ingredient ingredient)
            {
                ((IIngredientsViewModel)BindingContext).AddIngredientCommand.Execute(ingredient);
            }
#if __MOBILE__
            ingredientCollectionView.SelectedItem = null;
            searchBar.Unfocus();
#endif
        }
        else
        {
            ingredientCollectionView.SelectedItem = null;
        }
    }
}