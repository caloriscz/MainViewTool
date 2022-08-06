using MainViewTool.Commands;
using MainViewTool.Services;
using System.Windows.Input;

namespace MainViewTool.ViewModels;

public class AboutViewModel : ViewModelBase
{
    public ICommand NavigateHomeCommand { get; }

    public AboutViewModel(INavigationService homeNavigationService)
    {
        NavigateHomeCommand = new NavigateCommand(homeNavigationService);
    }
}