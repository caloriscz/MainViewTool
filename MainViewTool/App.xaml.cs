using MainViewTool.Services;
using MainViewTool.Stores;
using MainViewTool.ViewModels;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MainViewTool;

public partial class App : Application
{

    private static IHost? _host;
    private readonly NavigationStore _navigationStore;

    public App()
    {
        _navigationStore = new NavigationStore();
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MainWindow>();
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddLog4Net();
                logging.SetMinimumLevel(LogLevel.Trace);
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        INavigationService navigationService = CreateHomeNavigationService();
        navigationService.Navigate();

        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(_navigationStore)
        };
        MainWindow.Show();

        base.OnStartup(e);
    }

    private INavigationService CreateHomeNavigationService()
    {
        return new NavigationService<HomeViewModel>(_navigationStore, CreateHomeViewModel);
    }

    private HomeViewModel CreateHomeViewModel()
    {
        return new HomeViewModel(new NavigationService<AboutViewModel>(_navigationStore, CreateAboutViewModel));
    }

    private AboutViewModel CreateAboutViewModel()
    {
        return new AboutViewModel(new NavigationService<HomeViewModel>(_navigationStore, CreateHomeViewModel));
    }
}
