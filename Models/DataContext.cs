using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options) { }

  public DbSet<Series> Series { get; set; }
  public DbSet<Game> Games { get; set; }
  public DbSet<PlayerBox> PlayerBoxes { get; set; }
  public DbSet<HallOfFame> HallOfFame { get; set; }
  public DbSet<Season> Seasons { get; set; }
  public DbSet<SeasonGame> SeasonGames { get; set; }
  public DbSet<SeasonBox> SeasonBoxes { get; set; }

  public void AddSeries(Series series)
  {
    this.Add(series);
    this.SaveChanges();
  }

  public void AddGame(Game game)
  {
    this.Add(game);
    this.SaveChanges();
  }
  public void AddPlayerBox(PlayerBox playerBox)
  {
    this.Add(playerBox);
    this.SaveChanges();
  }
  public void AddHallOfFame(HallOfFame hallOfFame)
  {
    this.Add(hallOfFame);
    this.SaveChanges();
  }
  public void AddSeason(Season season)
  {
    this.Add(season);
    this.SaveChanges();
  }
  public void AddSeasonGame(SeasonGame seasonGame)
  {
    this.Add(seasonGame);
    this.SaveChanges();
  }
  public void AddSeasonBox(SeasonBox seasonBox)
  {
    this.Add(seasonBox);
    this.SaveChanges();
  }
}