using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PlayerBox
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PlayerID { get; set; }
    public int POS { get; set; }
    public string PlayerName { get; set; }
    public int Team { get; set; }
    public int SeriesID { get; set; }
    public int MIN { get; set; }
    public int PTS { get; set; }
    public int REB { get; set; }
    public int AST { get; set; }
    public int STLS { get; set; }
    public int BLK { get; set; }
    public int TOR { get; set; }
    public int FGM { get; set; }
    public int FGA { get; set; }
    public int TPM { get; set; }
    public int TPA { get; set; }
    public int GameID { get; set; }
    public Game? Game { get; set; }
    public Series? Series { get; set; }

}