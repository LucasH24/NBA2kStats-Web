public class SeasonGameViewModel
{
    public Season season { get; set; }
    public IEnumerable<SeasonGame> SeasonGames { get; set; }
    public IEnumerable<SeasonBox> SeasonBoxes { get; set; }
}