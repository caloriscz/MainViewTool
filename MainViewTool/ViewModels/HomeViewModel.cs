using MainViewTool.Commands;
using MainViewTool.Services;
using System.Windows.Input;

namespace MainViewTool.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public ICommand NavigateAboutCommand { get; }

    public HomeViewModel(INavigationService navigateAboutCommand)
    {
        NavigateAboutCommand = new NavigateCommand(navigateAboutCommand);
    }
}