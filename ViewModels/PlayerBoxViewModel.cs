public class PlayerBoxViewModel
{
  public Series series { get; set; }
  public Game game { get; set; }
  public IEnumerable<PlayerBox> PlayerBoxes { get; set; }
}