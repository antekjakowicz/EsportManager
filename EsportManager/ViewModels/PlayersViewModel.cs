using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EsportManager.Models;

namespace EsportManager.ViewModels;

public partial class PlayersViewModel : ViewModelBase
{
    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private int age;

    public ObservableCollection<Player> Players { get; } = new();

    [RelayCommand]
    private void AddPlayer()
    {
        if (!string.IsNullOrWhiteSpace(Name))
        {
            Players.Add(new Player { Name = Name, Age = Age });
            Name = string.Empty;
            Age = 0;
        }
    }
}