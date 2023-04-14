using Project.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Project.ViewModels
{
    public interface IProductViewModel : INotifyPropertyChanged
    {
        ICommand PerformSearch { get; }
        IList<Product> Products { get; set; }

        void OnPropertyChanged([CallerMemberName] string name = "");
    }
}