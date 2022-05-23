using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmTemplate.Services.Base;
using MvvmTemplate.Stores;
using MvvmTemplate.ViewModels;
using MvvmTemplate.ViewModels.Base;

namespace MvvmTemplate;

public partial class App
{
    private readonly IHost _host;
    
    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddTransient(CreateAboutViewModel);
                services.AddSingleton<CreateViewModel<AboutViewModel>>(s => s.GetRequiredService<AboutViewModel>);
                services.AddSingleton(CreateAboutNavigationService);

                services.AddTransient(CreateHomeViewModel);
                services.AddSingleton<CreateViewModel<HomeViewModel>>(s => s.GetRequiredService<HomeViewModel>);
                services.AddSingleton(CreateHomeNavigationService);
                
                services.AddTransient(CreateSingeViewModel);
                services.AddSingleton<CreateViewModel<SingleViewModel>>(s => s.GetRequiredService<SingleViewModel>);
                services.AddSingleton(CreateSingleNavigationService);

                
                
                services.AddSingleton<CloseModalNavigationService>();
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<ModalNavigationStore>();
                services.AddSingleton<MainViewModel>();
                services.AddSingleton(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                });
            })
            .Build();
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();

        INavigationService navigationService = _host.Services.GetRequiredService<NavigationService<HomeViewModel>>();
        navigationService.Navigate();

        MainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.Dispose();

        base.OnExit(e);
    }

    private static AboutViewModel CreateAboutViewModel(IServiceProvider services)
    {
        return new AboutViewModel(
            services.GetRequiredService<CloseModalNavigationService>());
    }

    private static NavigationService<AboutViewModel> CreateAboutNavigationService(IServiceProvider services)
    {
        return new NavigationService<AboutViewModel>(
            services.GetRequiredService<ModalNavigationStore>(),
            services.GetRequiredService<CreateViewModel<AboutViewModel>>());
    }

    private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
    {
        return new HomeViewModel(
            services.GetRequiredService<NavigationService<AboutViewModel>>(),
            services.GetRequiredService<NavigationService<SingleViewModel>>(),
            string.Empty
        );
    }

    private static NavigationService<HomeViewModel> CreateHomeNavigationService(IServiceProvider services)
    {
        return new NavigationService<HomeViewModel>(
            services.GetRequiredService<NavigationStore>(),
            services.GetRequiredService<CreateViewModel<HomeViewModel>>());
    }
    
    
    private static SingleViewModel CreateSingeViewModel(IServiceProvider services)
    {
        return new SingleViewModel(
            services.GetRequiredService<NavigationService<HomeViewModel>>()
            );
    }

    private static NavigationService<SingleViewModel> CreateSingleNavigationService(IServiceProvider services)
    {
        return new NavigationService<SingleViewModel>(
            services.GetRequiredService<NavigationStore>(),
            services.GetRequiredService<CreateViewModel<SingleViewModel>>());
    }
}
