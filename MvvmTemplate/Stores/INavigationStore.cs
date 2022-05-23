using MvvmTemplate.ViewModels.Base;
namespace MvvmTemplate.Stores;

public interface INavigationStore
{
    ViewModelBase? CurrentViewModel { set; }
}