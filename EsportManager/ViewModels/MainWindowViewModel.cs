using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EsportManager.Views;

namespace EsportManager.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private object? _currentView;

    [RelayCommand]
    private void ShowPlayersView()
    {
        CurrentView = new PlayersView();
    }
}