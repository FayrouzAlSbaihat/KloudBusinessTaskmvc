using Microsoft.EntityFrameworkCore;

namespace KloudTaskMVC.data
{
    public class SystemContext: DbContext
    {
        IConfiguration config;
        public SystemContext(IConfiguration _config)
        {
            config = _config;
        }

        public DbSet<Users> users { get; set; }
        public DbSet<Offers> offers { get; set; }
        public DbSet<OrderTime> orderTime { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("systemKloudconn"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}