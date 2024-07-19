using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class SeasonController : Controller
{
    private DataContext _dataContext;

    public SeasonController(DataContext db) => _dataContext = db;

    public IActionResult ViewSeasons() => View(new SeasonViewModel
    {
        seasons = _dataContext.Seasons,
        //seasons = _dataContext.Seasons.Where(s => s.Team1 != "Goobers" && s.Team1 != "Buffoons"),
    });

    public IActionResult SeasonDetail(int id) => View(new SeasonGameViewModel
    {
        season = _dataContext.Seasons.FirstOrDefault(s => s.SeasonID == id),
        SeasonGames = _dataContext.SeasonGames
        .Include(t => t.Team1)
        .Include(t => t.Team2)
        .Where(g => g.SeasonID == id),
        SeasonBoxes = _dataContext.SeasonBoxes.Where(p => p.SeasonID == id).Include(p => p.Player),
    });

    public IActionResult SeasonGameDetail(int id, int seasonID) => View(new SeasonBoxViewModel
    {
        season = _dataContext.Seasons.FirstOrDefault(s => s.SeasonID == seasonID),
        SeasonGame = _dataContext.SeasonGames
        .Include(t => t.Team1)
        .Include(t => t.Team2)
        .FirstOrDefault(g => g.SeasonGameID == id),
        SeasonBoxes = _dataContext.SeasonBoxes.Where(p => p.SeasonGameID == id).OrderBy(p => p.POS).Include(p => p.Player),
    });








}
