using MainViewTool.ViewModels;

namespace MainViewTool.Stores;

public interface INavigationStore
{
    ViewModelBase CurrentViewModel { set; }
}