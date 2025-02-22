using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class NbaPlayerStats
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int NbaPlayerID { get; set; }
    public string? Player { get; set; }
    public string? Name { get; set; }
    public string? Team { get; set; }
    public string? Positions { get; set; }
    public int? Season { get; set; }
    public int? Age { get; set; }
    public int? GamesPlayed { get; set; }
    public int? GamesStarted { get; set; }
    public int? MinutesPlayed { get; set; }
    public int? Points { get; set; }
    public int? Assists { get; set; }
    public int? Steals { get; set; }
    public int? Blocks { get; set; }
    public int? Turnovers { get; set; }
    public int? PersonalFouls { get; set; }
    public int? OffensiveRebounds { get; set; }
    public int? DefensiveRebounds { get; set; }
    public int? MadeFieldGoals { get; set; }
    public int? AttemptedFieldGoals { get; set; }
    public int? MadeThreePointFieldGoals { get; set; }
    public int? AttemptedThreePointFieldGoals { get; set; }
    public int? MadeFreeThrows { get; set; }
    public int? AttemptedFreeThrows { get; set; }
    public decimal? AssistPercentage { get; set; }
    public decimal? BlockPercentage { get; set; }
    public decimal? BoxPlusMinus { get; set; }
    public decimal? DefensiveBoxPlusMinus { get; set; }
    public decimal? DefensiveReboundPercentage { get; set; }
    public decimal? DefensiveWinShares { get; set; }
    public decimal? FreeThrowAttemptRate { get; set; }
    public decimal? OffensiveBoxPlusMinus { get; set; }
    public decimal? OffensiveReboundPercentage { get; set; }
    public decimal? OffensiveWinShares { get; set; }
    public decimal? PlayerEfficiencyRating { get; set; }
    public decimal? StealPercentage { get; set; }
    public decimal? ThreePointAttemptRate { get; set; }
    public decimal? TotalReboundPercentage { get; set; }
    public decimal? TrueShootingPercentage { get; set; }
    public decimal? TurnoverPercentage { get; set; }
    public decimal? UsagePercentage { get; set; }
    public decimal? ValueOverReplacementPlayer { get; set; }
    public decimal? WinShares { get; set; }
    public decimal? WinSharesPer48Minutes { get; set; }
}
