using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class DataController : Controller
{
  private DataContext _dataContext;
  public DataController(DataContext db) => _dataContext = db;

  public IActionResult StatView() => View();

  [HttpGet]
  public IActionResult GetSeasonBoxes()
  {
    var seasonBoxes = _dataContext.SeasonBoxes.Where(s => s.Season.IsAppropriate == true).Include(p => p.Player).ToList();

    if (User.IsInRole("viewer"))
    {
      seasonBoxes = _dataContext.SeasonBoxes.Include(p => p.Player).ToList();
    }

    return Json(seasonBoxes);
  }

  [HttpGet]
  public IActionResult GetSeasonGames()
  {
    IEnumerable<SeasonGame> SeasonGames = _dataContext.SeasonGames
        .Include(s => s.Team1)
        .Include(s => s.Team2)
        .Where(s => s.Season.IsAppropriate == true).ToList();

    if (User.IsInRole("viewer"))
    {
      SeasonGames = _dataContext.SeasonGames
        .Include(s => s.Team1)
        .Include(s => s.Team2)
        .ToList();
    }

    return Json(SeasonGames);
  }

  [HttpGet]
  public IActionResult GetSeries()
  {
    var series = _dataContext.Series.Where(s => s.IsAppropriate == true)
      .Include(s => s.Team1)
      .Include(s => s.Team2)
      .ToList();

    if (User.IsInRole("viewer"))
    {
      series = _dataContext.Series
      .Include(s => s.Team1)
      .Include(s => s.Team2)
      .ToList();
    }

    return Json(series);
  }

  [HttpGet]
  public IActionResult GetPlayerBoxes()
  {
    var playerBoxes = _dataContext.PlayerBoxes.Where(s => s.Series.IsAppropriate == true).Include(p => p.Player).ToList();

    if (User.IsInRole("viewer"))
    {
      playerBoxes = _dataContext.PlayerBoxes.Include(p => p.Player).ToList();
    }

    return Json(playerBoxes);
  }

  [HttpGet]
  public IActionResult GetGames()
  {
    var games = _dataContext.Games.Where(s => s.Series.IsAppropriate == true).ToList();

    if (User.IsInRole("viewer"))
    {
      games = _dataContext.Games.ToList();
    }

    return Json(games);
  }

  [HttpGet]
  public IActionResult GetSeasons()
  {
    var seasons = _dataContext.Seasons.Where(s => s.IsAppropriate == true).ToList();

    if (User.IsInRole("viewer"))
    {
      seasons = _dataContext.Seasons.ToList();
    }

    return Json(seasons);
  }

}
