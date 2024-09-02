using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "admin")]
public class AddController : Controller
{
    private DataContext _dataContext;
    public AddController(DataContext db) => _dataContext = db;
    public IActionResult AddHub() => View();

    //Series
    public IActionResult AddSeries() => View(new AddingViewModel
    {
        Teams = _dataContext.Teams,
    });

    [HttpPost]
    public IActionResult AddSeries(AddingViewModel model)
    {
        model.Series.Team1ID = int.Parse(model.Team1ID);
        model.Series.Team2ID = int.Parse(model.Team2ID);
        _dataContext.AddSeries(model.Series);
        return RedirectToAction("ViewSeries", "Series");
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

    public IActionResult AddPlayerBox(int id) => View(new AddingViewModel
    {
        Game = _dataContext.Games.Include(s => s.Series).FirstOrDefault(g => g.GameID == id),
        PlayerTeams = _dataContext.PlayerTeams
        .Include(p => p.Player),
    });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddPlayerBox(AddingViewModel model)
    {
        model.Game = _dataContext.Games.FirstOrDefault(g => g.GameID == model.PlayerBox.GameID);
        model.PlayerBox.PlayerID = int.Parse(model.PlayerID);
        _dataContext.AddPlayerBox(model.PlayerBox);
        return RedirectToAction("AddPlayerBox", "Add", new { id = model.Game.GameID });
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


    public IActionResult AddSeasonGame() => View(new AddingViewModel
    {
        Teams = _dataContext.Teams,
    });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddSeasonGame(int id, AddingViewModel model)
    {
        model.SeasonGame.SeasonID = id;
        model.SeasonGame.Team1ID = int.Parse(model.Team1ID);
        model.SeasonGame.Team2ID = int.Parse(model.Team2ID);
        _dataContext.AddSeasonGame(model.SeasonGame);
   
        return RedirectToAction("ViewSeasons", "Season");
    }

    public IActionResult AddSeasonBox(int id) => View(new AddingViewModel
    {
        SeasonGame = _dataContext.SeasonGames.Include(s => s.Season).FirstOrDefault(g => g.SeasonGameID == id),
        PlayerTeams = _dataContext.PlayerTeams
        .Include(p => p.Player),
    });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddSeasonBox(AddingViewModel model)
    {
        model.SeasonGame = _dataContext.SeasonGames.FirstOrDefault(g => g.SeasonGameID == model.SeasonBox.SeasonGameID);
        model.SeasonBox.PlayerID = int.Parse(model.PlayerID);
        _dataContext.AddSeasonBox(model.SeasonBox);
        return RedirectToAction("AddSeasonBox", "Add", new { id = model.SeasonGame.SeasonGameID });
    }

    //Roster
    public IActionResult AddTeam() => View();

    [HttpPost]
    public IActionResult AddTeam(Team model)
    {
        if (ModelState.IsValid)
        {
            model.Overall = 0;
            _dataContext.AddTeam(model);
        }
        return View();
    }

    public IActionResult AddPlayer() => View(new AddPlayerViewModel
    {
        Players = _dataContext.Players,
    });

    [HttpPost]
    public IActionResult AddPlayer(AddPlayerViewModel model)
    {
        if (ModelState.IsValid)
        {
            _dataContext.AddPlayer(model.Player);
        }
        return RedirectToAction("AddPlayer", "Add");
    }

    public IActionResult AddPlayerTeam(int id) => View(new AddPlayerTeamViewModel
    {
        Team = _dataContext.Teams.FirstOrDefault(t => t.TeamID == id),
        Players = _dataContext.Players,
    });

    [HttpPost]
    public IActionResult CreatePlayerTeam(AddPlayerTeamViewModel inputModel)
    {
        try
        {
            PlayerTeam playerTeam = new PlayerTeam()
            {
                PlayerID = Convert.ToInt32(inputModel.PlayerID),
                TeamID = inputModel.TeamID,
                Overall = inputModel.Overall,
            };
            
            _dataContext.PlayerTeams.Add(playerTeam);
            _dataContext.SaveChanges();
            _dataContext.Dispose();
        }
        catch (Exception e)
        {
            var exceptionText = e.InnerException;
            Console.WriteLine(exceptionText);
        }

        return RedirectToAction("AddPlayerTeam", "Add", new { id = inputModel.TeamID });
    }
}
