using CommunityToolkit.Mvvm.Input;

namespace EsportManager.Models;

public class Player
{
    public int Id { get; set; }
    public string Nickname { get; set; } 
    public string Description { get; set; }
    
    public int Game { get; set; } = 0;
    public int SkillLevel { get; set; } = 0;
    public int StressLevel { get; set; } = 0;
    public int FatigueLevel { get; set; } = 0;
    public int Coins { get; set; } = 0;
}





