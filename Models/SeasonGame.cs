using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class SeasonGame
{
    public SeasonGame()
    {
        SeasonBoxes = new HashSet<SeasonBox>();
    }

    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SeasonGameID { get; set; }
    public int GameNumber { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
    public int? Team1ORB { get; set; }
    public int? Team2ORB { get; set; }
    public int? Team1FTA { get; set; }
    public int? Team2FTA { get; set; }
    public int Team1ID { get; set; }
    public int Team2ID { get; set; }

    public int SeasonID { get; set; }
    public Team Team1 { get; set; }
    public Team Team2 { get; set; }
    public Season Season { get; set; }
    [InverseProperty("SeasonGame")]
    public ICollection<SeasonBox> SeasonBoxes { get; set; }
}
