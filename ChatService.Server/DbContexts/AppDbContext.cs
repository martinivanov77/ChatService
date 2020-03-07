using Microsoft.EntityFrameworkCore;

namespace ChatService.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() 
                {Id=1, Username = "Ivan", Password = "1234" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
