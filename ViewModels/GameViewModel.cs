public class GameViewModel
{
  public Series series { get; set; }
  public IEnumerable<Game> Games { get; set; }
  public IEnumerable<PlayerBox> PlayerBoxes { get; set; }
}