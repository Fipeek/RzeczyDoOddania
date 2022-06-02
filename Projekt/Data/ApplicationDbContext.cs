using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projekt.Models;

namespace Projekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
         
builder.Entity<CategoryGroup>()
.HasKey(pg => new { pg.OfferID, pg.CategoryID });
            //w tabeli posredniczacej PersonGroup
            builder.Entity<CategoryGroup>()
            .HasOne<Offer>(pg => pg.Offer) // dla jednej osoby
            .WithMany(p => p.CategoryGroups) // jest wiele PersonGroups
            .HasForeignKey(p => p.OfferID); // a powizanie jest
           
//w tabeli posredniczacej PersonGroup
builder.Entity<CategoryGroup>()
.HasOne<Category>(pg => pg.Category) // dla jednej grupy
.WithMany(g => g.CategoryGroups) // jest wiele PersonGroups
.HasForeignKey(g => g.CategoryID);
}

        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryGroup> CategoryGroups { get; set; }
    }
}