public class GameViewModel
{
  public Series Series { get; set; }
  public IEnumerable<Game> Games { get; set; }
  public IEnumerable<PlayerBox> PlayerBoxes { get; set; }
}