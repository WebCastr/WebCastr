using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebCaster.API.Authentication;
using WebCaster.API.Models;

namespace WebCaster.API.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public DbSet<Station> Stations { get; set; }
    public DbSet<MountPoint> Mountpoints { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Change default Identity entities tables name to remove prefix AspNet

        builder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable(name: "user");
            entity.Ignore(e => e.PhoneNumber);
            entity.Ignore(e => e.PhoneNumberConfirmed);
            entity.Ignore(e => e.TwoFactorEnabled);
        });

        builder.Entity<IdentityRole<int>>(entity =>
        {
            entity.ToTable(name: "role");
        });

        builder.Entity<IdentityUserClaim<int>>(entity =>
        {
            entity.ToTable("user_claim");
        });

        builder.Entity<IdentityUserLogin<int>>(entity =>
        {
            entity.ToTable("user_login");
        });

        builder.Entity<IdentityRoleClaim<int>>(entity =>
        {
            entity.ToTable("role_claim");
        });

        builder.Entity<IdentityUserRole<int>>(entity =>
        {
            entity.ToTable("UserRole");
        });

        builder.Entity<IdentityUserToken<int>>(entity =>
        {
            entity.ToTable("user_token");
        });
    }
}
