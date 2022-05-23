using System.Windows.Input;
using MvvmTemplate.Commands.Base;
using MvvmTemplate.Services.Base;
using MvvmTemplate.ViewModels.Base;

namespace MvvmTemplate.ViewModels;

public class SingleViewModel : ViewModelBase
{
    public ICommand GoToHome { get; }
    public SingleViewModel(INavigationService navigateToHome)
    {
        GoToHome = new NavigateCommand(navigateToHome);
    }
}