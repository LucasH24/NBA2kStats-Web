public class AddPlayerTeamViewModel
{
    public Team Team { get; set; }
    public IEnumerable<Player> Players { get; set; }
    public string PlayerID { get; set; }
    public int Overall { get; set; }
    public int TeamID { get; set; }
}