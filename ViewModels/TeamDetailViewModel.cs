public class TeamDetailViewModel
{
    public Team Team { get; set; }
    public IEnumerable<PlayerTeam> PlayerTeams { get; set; }
    public string TeamID { get; set; }
    public int PlayerTeamID { get; set; }
    public int Overall { get; set; }
}