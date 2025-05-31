using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dapper;
using EsportManager.Models;
using Npgsql;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace EsportManager.ViewModels;

public partial class PlayersViewModel : ObservableObject
{
    private readonly string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=esportmanager";

    [ObservableProperty] private string nickname = "";
    [ObservableProperty] private string description = "";
    [ObservableProperty] private int game;
    [ObservableProperty] private int skillLevel;
    [ObservableProperty] private int stressLevel;
    [ObservableProperty] private int fatigueLevel;
    [ObservableProperty] private int coins;

    public ObservableCollection<Player> Players { get; } = new();

    public ICommand AddPlayerCommand { get; }

    public PlayersViewModel()
    {
        AddPlayerCommand = new RelayCommand(AddPlayer);
        InitializeDatabase();
        LoadPlayers();
    }

    private void InitializeDatabase()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute(@"
            CREATE TABLE IF NOT EXISTS players (
                id SERIAL PRIMARY KEY,
                nickname TEXT NOT NULL,
                description TEXT,
                game INTEGER,
                skill_level INTEGER,
                stress_level INTEGER,
                fatigue_level INTEGER,
                coins INTEGER
            );
        ");
    }

    private void AddPlayer()
    {
        var player = new Player
        {
            Nickname = Nickname,
            Description = Description,
            Game = Game,
            SkillLevel = SkillLevel,
            StressLevel = StressLevel,
            FatigueLevel = FatigueLevel,
            Coins = Coins
        };

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Execute(@"
            INSERT INTO players 
                (nickname, description, game, skill_level, stress_level, fatigue_level, coins) 
            VALUES 
                (@Nickname, @Description, @Game, @SkillLevel, @StressLevel, @FatigueLevel, @Coins);
        ", player);

        LoadPlayers();
        ClearInputs();
    }

    private void LoadPlayers()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var players = connection.Query<Player>("SELECT * FROM players").ToList();

        Players.Clear();
        foreach (var p in players)
            Players.Add(p);
    }

    private void ClearInputs()
    {
        Nickname = "";
        Description = "";
        Game = 0;
        SkillLevel = 0;
        StressLevel = 0;
        FatigueLevel = 0;
        Coins = 0;
    }
}
