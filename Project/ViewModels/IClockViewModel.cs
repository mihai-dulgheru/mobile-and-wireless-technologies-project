using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Project.ViewModels
{
    public interface IClockViewModel
    {
        DateTime DateTime { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "");
    }
}