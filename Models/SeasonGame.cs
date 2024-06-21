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
    public string Team1Name { get; set; }
    public string Team2Name { get; set; }
    public string Team1Color { get; set; }
    public string Team2Color { get; set; }
    public int? Team1ORB { get; set; }
    public int? Team2ORB { get; set; }
    public int? Team1FTA { get; set; }
    public int? Team2FTA { get; set; }

    public int SeasonID { get; set; }
    public Season Season { get; set; }
    [InverseProperty("SeasonGame")]
    public ICollection<SeasonBox> SeasonBoxes { get; set; }
}
