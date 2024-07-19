public class AddingViewModel
{
    public Series Series { get; set; }
    public PlayerBox PlayerBox { get; set; }
    public SeasonGame SeasonGame { get; set; }
    public SeasonBox SeasonBox { get; set; }
    public Game Game { get; set; }

    public IEnumerable<Player> Players { get; set; }
    public IEnumerable<PlayerTeam> PlayerTeams { get; set; }
    public IEnumerable<Team> Teams { get; set; }

    public string Team1ID { get; set; }
    public string Team2ID { get; set; }
    public string PlayerID { get; set; }
}