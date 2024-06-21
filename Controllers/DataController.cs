using Microsoft.AspNetCore.Mvc;

public class DataController : Controller
{
  private DataContext _dataContext;
  public DataController(DataContext db) => _dataContext = db;

  public IActionResult StatView() => View();

  [HttpGet]
  public IActionResult GetSeasonBoxes()
  {
    var seasonBoxes = _dataContext.SeasonBoxes.Where(s => s.Season.IsAppropriate == true).ToList();

    if (User.IsInRole("viewer"))
    {
      seasonBoxes = _dataContext.SeasonBoxes.ToList();
    }

    return Json(seasonBoxes);
  }

  [HttpGet]
  public IActionResult GetSeasonGames()
  {
    var seasonGames = _dataContext.SeasonGames.Where(s => s.Season.IsAppropriate == true).ToList();

    if (User.IsInRole("viewer"))
    {
      seasonGames = _dataContext.SeasonGames.ToList();
    }

    return Json(seasonGames);
  }

  [HttpGet]
  public IActionResult GetSeries()
  {
    var series = _dataContext.Series.Where(s => s.IsAppropriate == true).ToList();

    if (User.IsInRole("viewer"))
    {
      series = _dataContext.Series.ToList();
    }

    return Json(series);
  }

  [HttpGet]
  public IActionResult GetPlayerBoxes()
  {
    var playerBoxes = _dataContext.PlayerBoxes.Where(s => s.Series.IsAppropriate == true).ToList();

    if (User.IsInRole("viewer"))
    {
      playerBoxes = _dataContext.PlayerBoxes.ToList();
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
