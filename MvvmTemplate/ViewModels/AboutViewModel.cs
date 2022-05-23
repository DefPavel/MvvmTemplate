using System.Windows.Input;
using MvvmTemplate.Commands.Base;
using MvvmTemplate.Services.Base;
using MvvmTemplate.ViewModels.Base;

namespace MvvmTemplate.ViewModels;

public class AboutViewModel : ViewModelBase
{
    public ICommand CloseCommand { get; }
    
    public AboutViewModel(INavigationService closeModalNavigationService)
    {
        CloseCommand = new NavigateCommand(closeModalNavigationService);
    }
    
}