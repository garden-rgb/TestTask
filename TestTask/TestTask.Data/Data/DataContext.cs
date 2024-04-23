using Microsoft.EntityFrameworkCore;


namespace TestTask.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}
