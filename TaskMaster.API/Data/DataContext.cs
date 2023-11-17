using Microsoft.EntityFrameworkCore;
using TaskMaster.Shared.Entities;

namespace TaskMaster.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Shared.Entities.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(c => c.UserId).IsUnique();
        }
    }
}
