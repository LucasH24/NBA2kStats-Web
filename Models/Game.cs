using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Game
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GameID { get; set; }
    public int GameNumber { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
    public int? Team1ORB { get; set; }
    public int? Team2ORB { get; set; }
    public int? Team1FTA { get; set; }
    public int? Team2FTA { get; set; }
    public int SeriesID { get; set; }
    public Series Series { get; set; }
    public ICollection<PlayerBox> PlayerBoxes { get; set; }
}
