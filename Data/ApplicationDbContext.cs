using Assignment2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Use seed method here
        builder.Seed();
    }

    public DbSet<Assignment2.Models.Book> Book { get; set; } = default!;
    public DbSet<Assignment2.Models.Reservation> Reservation { get; set; } = default!;
}
