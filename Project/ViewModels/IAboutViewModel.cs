using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IAboutViewModel
    {
        string Message { get; }
        string MoreInfoUrl { get; }
        ICommand ShowMoreInfoCommand { get; }
        string Title { get; }
        string Version { get; }
    }
}