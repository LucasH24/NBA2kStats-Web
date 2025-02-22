using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

[Authorize(Roles = "admin")]
public class StatsController : Controller
{
  private DataContext _dataContext;
  public StatsController(DataContext db) => _dataContext = db;

  public IActionResult StatsMaintenance() => View();

  [HttpPost]
  public ActionResult AddPlayer(string[] player, int season)
  {
      NbaPlayerStats playerToAdd = _dataContext.NbaPlayerStats.FirstOrDefault(n => n.Player == player[18] && n.Season == season);
      int adding = 0;
      if (playerToAdd == null) {
        playerToAdd = new NbaPlayerStats();
        adding = 1;
      }

      playerToAdd.Age = Convert.ToInt32(player[0]);
      playerToAdd.Assists = Convert.ToInt32(player[1]);
      playerToAdd.AttemptedFieldGoals = Convert.ToInt32(player[2]);
      playerToAdd.AttemptedFreeThrows = Convert.ToInt32(player[3]);
      playerToAdd.AttemptedThreePointFieldGoals = Convert.ToInt32(player[4]);
      playerToAdd.Blocks = Convert.ToInt32(player[5]);
      playerToAdd.DefensiveRebounds = Convert.ToInt32(player[6]);
      playerToAdd.GamesPlayed = Convert.ToInt32(player[7]);
      playerToAdd.GamesStarted = Convert.ToInt32(player[8]);
      playerToAdd.MadeFieldGoals = Convert.ToInt32(player[9]);
      playerToAdd.MadeFreeThrows = Convert.ToInt32(player[10]);
      playerToAdd.MadeThreePointFieldGoals = Convert.ToInt32(player[11]);
      playerToAdd.MinutesPlayed = Convert.ToInt32(player[12]);
      playerToAdd.Name = player[13];
      playerToAdd.OffensiveRebounds = Convert.ToInt32(player[14]);
      playerToAdd.PersonalFouls = Convert.ToInt32(player[15]);
      playerToAdd.Points = Convert.ToInt32(player[16]);
      playerToAdd.Positions = player[17];
      playerToAdd.Player = player[18];
      playerToAdd.Steals = Convert.ToInt32(player[19]);
      playerToAdd.Team = player[20];
      playerToAdd.Turnovers = Convert.ToInt32(player[21]);
      playerToAdd.Season = season;
      if (adding == 1) {
        _dataContext.AddNbaPlayerStats(playerToAdd);
      }
      else {
        _dataContext.SaveChanges();
        _dataContext.Dispose();
      }
    return RedirectToAction("StatsMaintenance", "Stats");
  }


  [HttpPost]
  public ActionResult UpdateAdvancedData(string[] player, int season)
  {
    NbaPlayerStats playerToUpdate = _dataContext.NbaPlayerStats.FirstOrDefault(n => n.Player == player[11] && n.Season == season);

    if (playerToUpdate != null) {
      playerToUpdate.AssistPercentage = Math.Round(Convert.ToDecimal(player[0]), 1);
      playerToUpdate.BlockPercentage = Math.Round(Convert.ToDecimal(player[1]), 1);
      playerToUpdate.BoxPlusMinus = Math.Round(Convert.ToDecimal(player[2]), 1);
      playerToUpdate.DefensiveBoxPlusMinus = Math.Round(Convert.ToDecimal(player[3]), 1);
      playerToUpdate.DefensiveReboundPercentage = Math.Round(Convert.ToDecimal(player[4]), 1);
      playerToUpdate.DefensiveWinShares = Math.Round(Convert.ToDecimal(player[5]), 1);
      playerToUpdate.FreeThrowAttemptRate = Math.Round(Convert.ToDecimal(player[6]), 3);
      playerToUpdate.OffensiveBoxPlusMinus = Math.Round(Convert.ToDecimal(player[7]), 1);
      playerToUpdate.OffensiveReboundPercentage = Math.Round(Convert.ToDecimal(player[8]), 1);
      playerToUpdate.OffensiveWinShares = Math.Round(Convert.ToDecimal(player[9]), 1);
      playerToUpdate.PlayerEfficiencyRating = Math.Round(Convert.ToDecimal(player[10]), 1);
      playerToUpdate.StealPercentage = Math.Round(Convert.ToDecimal(player[12]), 1);
      playerToUpdate.ThreePointAttemptRate = Math.Round(Convert.ToDecimal(player[13]), 3);
      playerToUpdate.TotalReboundPercentage = Math.Round(Convert.ToDecimal(player[14]), 1);
      playerToUpdate.TrueShootingPercentage = Math.Round(Convert.ToDecimal(player[15]), 1);
      playerToUpdate.TurnoverPercentage = Math.Round(Convert.ToDecimal(player[16]), 1);
      playerToUpdate.UsagePercentage = Math.Round(Convert.ToDecimal(player[17]), 1);
      playerToUpdate.ValueOverReplacementPlayer = Math.Round(Convert.ToDecimal(player[18]), 1);
      playerToUpdate.WinShares = Math.Round(Convert.ToDecimal(player[19]), 1);
      playerToUpdate.WinSharesPer48Minutes = (decimal)Math.Round(float.Parse(player[20]), 3);
    }
    
    _dataContext.SaveChanges();
    _dataContext.Dispose();
    return RedirectToAction("StatsMaintenance", "Stats");
  }


}
