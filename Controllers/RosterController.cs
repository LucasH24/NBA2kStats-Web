using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

public class RosterController : Controller
{
    private DataContext _dataContext;
    public RosterController(DataContext db) => _dataContext = db;

    public IActionResult ViewTeams() => View();

    public IActionResult ViewPlayers() => View();

    public IActionResult TeamDetail(int id) => View(new TeamDetailViewModel
    {
        Team = _dataContext.Teams.FirstOrDefault(t => t.TeamID == id),
        PlayerTeams = _dataContext.PlayerTeams.Where(p => p.TeamID == id)
        .Include(p => p.Player)
        .Include(t => t.Team),
    });

    public IActionResult PlayerDetail(int id) => View(new PlayerDetailViewModel
    {
        PlayerTeams = _dataContext.PlayerTeams.Where(p => p.PlayerID == id)
        .Include(p => p.Player)
        .Include(t => t.Team),
        Player = _dataContext.Players.FirstOrDefault(p => p.PlayerID == id),
    });

    [Authorize(Roles = "admin")]
    public IActionResult UpdateTeamOveralls() => View(new UpdateTeamOverallsViewModel
    {
        Teams = _dataContext.Teams,
        PlayerTeams = _dataContext.PlayerTeams
        .Include(p => p.Player)
        .Include(t => t.Team),
    });

    [Authorize(Roles = "admin")]
    [HttpPost]
    public ActionResult UpdateTeamOveralls(int team, decimal overall)
    {
        Team teamModel = _dataContext.Teams.FirstOrDefault(t => t.TeamID == team);

        if(teamModel != null)
        {
            teamModel.Overall = overall;
        }

        _dataContext.SaveChanges();
        _dataContext.Dispose();

        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public IActionResult UpdatePlayer(TeamDetailViewModel inputModel)
    {
        PlayerTeam playerTeam = _dataContext.PlayerTeams.FirstOrDefault(p => p.PlayerTeamID == inputModel.PlayerTeamID);

        if (playerTeam != null)
        {
            playerTeam.Overall = inputModel.Overall;
        }
        _dataContext.SaveChanges();
        _dataContext.Dispose();

        return RedirectToAction("TeamDetail", "Roster", new { id = inputModel.TeamID });
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public IActionResult DeletePlayer(TeamDetailViewModel inputModel)
    {
        PlayerTeam playerTeam = _dataContext.PlayerTeams.FirstOrDefault(p => p.PlayerTeamID == inputModel.PlayerTeamID);

        if (playerTeam != null)
        {
            _dataContext.PlayerTeams.Remove(playerTeam);
        }
        _dataContext.SaveChanges();
        _dataContext.Dispose();

        return RedirectToAction("TeamDetail", "Roster", new { id = inputModel.TeamID });
    }

    [HttpGet]
    public IActionResult GetTeams()
    {
        var teams = _dataContext.Teams.Where(t => t.IsAppropriate == true).ToList();

        if (User.IsInRole("viewer"))
        {
            teams = _dataContext.Teams.ToList();
        }
        return Json(teams);
    }

    [HttpGet]
    public IActionResult GetPlayerTeams()
    {
        var playerTeams = _dataContext.PlayerTeams
        .Include(p => p.Player)
        .Include(t => t.Team)
        .Where(p => p.Team.IsAppropriate == true)
        .ToList();

        if (User.IsInRole("viewer"))
        {
            playerTeams = _dataContext.PlayerTeams
            .Include(p => p.Player)
            .Include(t => t.Team)
            .ToList();
        }


        return Json(playerTeams);
    }

    [HttpGet]
    public IActionResult GetPlayers()
    {

        var players = _dataContext.Players.Where(p => p.IsAppropriate == true).ToList();

        if (User.IsInRole("viewer"))
        {
            players = _dataContext.Players.ToList();
        }
        return Json(players);
    }

    public IActionResult DataManagement() => View(new DataManagementModel
    {
        Players = _dataContext.Players,
    });
}
