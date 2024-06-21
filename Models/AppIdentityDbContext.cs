using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public AppIdentityDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var user = new IdentityRole("user");
        user.NormalizedName = "user";

        var viewer = new IdentityRole("viewer");
        viewer.NormalizedName = "viewer";

        var admin = new IdentityRole("admin");
        admin.NormalizedName = "admin";

        builder.Entity<IdentityRole>().HasData(admin, viewer, user);
    }
}

