using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

[Authorize(Roles = "admin")]
public class AddController : Controller
{
    private DataContext _dataContext;
    public AddController(DataContext db) => _dataContext = db;
    public IActionResult AddHub() => View();

    //Series
    public IActionResult AddSeries() => View();
    [HttpPost]

    public IActionResult AddSeries(Series model)
    {
        if (ModelState.IsValid)
        {
            _dataContext.AddSeries(model);
            return RedirectToAction("ViewSeries", "Series");
        }
        return View();
    }

    public IActionResult AddGame() => View();
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult AddGame(int id, Game model)
    {
        model.SeriesID = id;
        if (ModelState.IsValid)
        {
            _dataContext.AddGame(model);
        }
        return View();
    }

    public IActionResult AddPlayerBox() => View();
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult AddPlayerBox(int id, PlayerBox model)
    {
        model.GameID = id;
        if (ModelState.IsValid)
        {
            _dataContext.AddPlayerBox(model);
        }
        return View();
    }


    //Season
    public IActionResult AddSeason() => View();
    [HttpPost]

    public IActionResult AddSeason(Season model)
    {
        if (ModelState.IsValid)
        {
            _dataContext.AddSeason(model);
            return RedirectToAction("ViewSeasons", "Season");
        }
        return View();
    }


    public IActionResult AddSeasonGame() => View();
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult AddSeasonGame(int id, SeasonGame model)
    {
        model.SeasonID = id;
        if (ModelState.IsValid)
        {
            _dataContext.AddSeasonGame(model);
        }
        return View();
    }

    public IActionResult AddSeasonBox() => View();
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult AddSeasonBox(int id, SeasonBox model)
    {
        model.SeasonGameID = id;
        if (ModelState.IsValid)
        {
            _dataContext.AddSeasonBox(model);
        }
        return View();
    }


    //Hall of Fame
    public IActionResult AddHallOfFame() => View();
    [HttpPost]

    public IActionResult AddHallOfFame(HallOfFame model)
    {
        if (ModelState.IsValid)
        {
            _dataContext.AddHallOfFame(model);
        }
        return View();
    }
}
