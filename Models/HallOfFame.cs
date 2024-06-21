using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class HallOfFame
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int HOFID { get; set; }
    public string NBA2k { get; set; }
    public string Name { get; set; }
    public int MIN { get; set; }
    public int PTS { get; set; }
    public int REB { get; set; }
    public int AST { get; set; }
    public int STLS { get; set; }
    public int BLK { get; set; }
    public int FGM { get; set; }
    public int FGA { get; set; }
    public int TPM { get; set; }
    public int TPA { get; set; }
    public decimal Score { get; set; }

 }
