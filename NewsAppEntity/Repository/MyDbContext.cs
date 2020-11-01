using Microsoft.EntityFrameworkCore;
using NewsAppEntity.Models;

namespace NewsAppEntity.Repository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<News> News { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photo> Photos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Photo>()
              .Property(b => b.CreatedDate)
              .HasDefaultValueSql("getdate()");
        }

    }
}
