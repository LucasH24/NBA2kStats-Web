using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Series
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SeriesID { get; set; }
    public int Team1W { get; set; }
    public int Team2W { get; set; }
    public int PlayedGames { get; set; }
    public decimal Minutes { get; set; }
    public string NBA2k { get; set; }
    public bool IsAppropriate { get; set; }
    public int Team1ID { get; set; }
    public int Team2ID { get; set; }
    public Team Team1 { get; set; }
    public Team Team2 { get; set; }
    public ICollection<Game> Games { get; set; }

}
