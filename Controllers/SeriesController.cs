using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class SeriesController : Controller
{
    private DataContext _dataContext;
    public SeriesController(DataContext db) => _dataContext = db;

    public IActionResult ViewSeries() => View(new SeriesViewModel
    {
        Series = _dataContext.Series
        .Include(t => t.Team1)
        .Include(t => t.Team2),
    });

    public IActionResult SeriesDetail(int id) => View(new GameViewModel
    {
        Series = _dataContext.Series
        .Include(t => t.Team1)
        .Include(t => t.Team2)
        .FirstOrDefault(s => s.SeriesID == id),
        Games = _dataContext.Games.Where(g => g.SeriesID == id),
        PlayerBoxes = _dataContext.PlayerBoxes.Where(p => p.SeriesID == id).Include(p => p.Player),
    });

    public IActionResult GameDetail(int id, int seriesID) => View(new PlayerBoxViewModel
    {
        Series = _dataContext.Series
        .Include(t => t.Team1)
        .Include(t => t.Team2)
        .FirstOrDefault(s => s.SeriesID == seriesID),
        Game = _dataContext.Games.FirstOrDefault(g => g.GameID == id),
        PlayerBoxes = _dataContext.PlayerBoxes.Where(p => p.GameID == id).OrderBy(p => p.POS).Include(p => p.Player),
    });

}
