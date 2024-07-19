public class AddPlayerTeamViewModel
{
    public Team team { get; set; }
    public IEnumerable<Player> Players { get; set; }
    public string PlayerID { get; set; }
    public int Overall { get; set; }
    public int TeamID { get; set; }
}