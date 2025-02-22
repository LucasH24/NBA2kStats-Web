using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options) { }

  //Series
  public DbSet<Series> Series { get; set; }
  public DbSet<Game> Games { get; set; }
  public DbSet<PlayerBox> PlayerBoxes { get; set; }
  //Season
  public DbSet<Season> Seasons { get; set; }
  public DbSet<SeasonGame> SeasonGames { get; set; }
  public DbSet<SeasonBox> SeasonBoxes { get; set; }
  //Roster
  public DbSet<Team> Teams { get; set; }
  public DbSet<Player> Players { get; set; }
  public DbSet<PlayerTeam> PlayerTeams { get; set; }
  //NBA Data
  public DbSet<NbaPlayerStats> NbaPlayerStats { get; set; }

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
  public void AddPlayer(Player player)
  {
    this.Add(player);
    this.SaveChanges();
  }
  public void AddTeam(Team team)
  {
    this.Add(team);
    this.SaveChanges();
  }
  public void AddNbaPlayerStats(NbaPlayerStats nbaPlayerStats)
  {
    this.Add(nbaPlayerStats);
    this.SaveChanges();
  }
}