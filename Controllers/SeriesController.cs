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
        series = _dataContext.Series,
    });

    public IActionResult SeriesDetail(int id) => View(new GameViewModel
    {
        series = _dataContext.Series.FirstOrDefault(s => s.SeriesID == id),
        Games = _dataContext.Games.Where(g => g.SeriesID == id),
        PlayerBoxes = _dataContext.PlayerBoxes.Where(p => p.SeriesID == id),
    });

    public IActionResult GameDetail(int id, int seriesID) => View(new PlayerBoxViewModel
    {
        series = _dataContext.Series.FirstOrDefault(s => s.SeriesID == seriesID),
        game = _dataContext.Games.FirstOrDefault(g => g.GameID == id),
        PlayerBoxes = _dataContext.PlayerBoxes.Where(p => p.GameID == id).OrderBy(p => p.POS),
    });

}
