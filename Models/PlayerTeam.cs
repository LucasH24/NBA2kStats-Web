using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PlayerTeam
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PlayerTeamID { get; set; }
    public int PlayerID { get; set; }
    public int TeamID { get; set; }
    public int Overall { get; set; }
    public Player Player { get; set; }
    public Team Team { get; set; }
}
