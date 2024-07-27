public class SeasonGameViewModel
{
    public Season Season { get; set; }
    public IEnumerable<SeasonGame> SeasonGames { get; set; }
    public IEnumerable<SeasonBox> SeasonBoxes { get; set; }
}