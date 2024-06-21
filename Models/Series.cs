using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Series
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SeriesID { get; set; }
    public string Team1 { get; set; }
    public string Team2 { get; set; }
    public int Team1W { get; set; }
    public int Team2W { get; set; }
    public int PlayedGames { get; set; }
    public decimal Minutes { get; set; }
    public string NBA2k { get; set; }
    public string Team1Color { get; set; }
    public string Team2Color { get; set; }
    public bool IsAppropriate { get; set; }
    public ICollection<Game> Games { get; set; }

}
