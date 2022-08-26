using Microsoft.EntityFrameworkCore;
namespace webAppProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Actions> Actions { get; set; }
        // public DbSet<Targets> Targets { get; set; }


    }
}
