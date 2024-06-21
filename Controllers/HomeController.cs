using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
  private DataContext _dataContext;
  public HomeController(DataContext db) => _dataContext = db;
  public ActionResult Index() => View();
}
