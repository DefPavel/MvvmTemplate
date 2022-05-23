using System.Windows.Input;
using MvvmTemplate.ViewModels.Base;

namespace MvvmTemplate.Commands.Base;

public delegate ICommand CreateCommand<in TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase;