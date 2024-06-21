public class SeasonBoxViewModel
{
    public Season season { get; set; }
    public SeasonGame SeasonGame { get; set; }
    public IEnumerable<SeasonBox> SeasonBoxes { get; set; }
}