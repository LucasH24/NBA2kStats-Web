using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Team
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TeamID { get; set; }
    public string Year { get; set; }
    public string City { get; set; }
    public string TeamName { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public decimal Overall { get; set; }
    public string TeamColor1 { get; set; }
    public string TeamColor2 { get; set; }
    public string PrimaryColor { get; set; }
    public bool IsAppropriate { get; set; }
    public ICollection<PlayerTeam> PlayerTeams { get; set; }
}
