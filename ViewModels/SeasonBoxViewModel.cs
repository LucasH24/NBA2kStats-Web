public class SeasonBoxViewModel
{
    public Season Season { get; set; }
    public SeasonGame SeasonGame { get; set; }
    public IEnumerable<SeasonBox> SeasonBoxes { get; set; }
}