using MainViewTool.Services;
using MainViewTool.Stores;
using MainViewTool.ViewModels;
using System.Windows;

namespace MainViewTool;

public partial class App : Application
{
    private readonly NavigationStore _navigationStore;

    public App()
    {
        _navigationStore = new NavigationStore();
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
        return new HomeViewModel(CreateAboutNavigationService());
    }

    private INavigationService CreateAboutNavigationService()
    {
        return new NavigationService<AboutViewModel>(_navigationStore, CreateAboutViewModel);
    }

    private AboutViewModel CreateAboutViewModel()
    {
        return new AboutViewModel(CreateHomeNavigationService());
    }
}
