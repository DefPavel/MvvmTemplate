using System.Windows.Input;
using MvvmTemplate.Commands;
using MvvmTemplate.Commands.Base;
using MvvmTemplate.Services.Base;
using MvvmTemplate.Stores;
using MvvmTemplate.ViewModels.Base;

namespace MvvmTemplate.ViewModels;

public class HomeViewModel : ViewModelBase
{
    private readonly string _token;
    public HomeViewModel(INavigationService navigationToLogin, INavigationService navigationToSingle , string token)
    {
        NavigateAbout = new NavigateCommand(navigationToLogin);

        NavigateSingle = new NavigateCommand(navigationToSingle);

        _token = token;
    }

    public string WelcomeMessage => "Welcome to the WPF MVVM Template!";
    public ICommand NavigateAbout { get; }
    public ICommand NavigateSingle { get; }
    
   
}
