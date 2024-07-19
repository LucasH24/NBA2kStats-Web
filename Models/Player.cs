using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Player
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PlayerID { get; set; }
    public string PlayerFullName { get; set; }
    public string PlayerShortName { get; set; }
    public bool IsAppropriate { get; set; }
}
