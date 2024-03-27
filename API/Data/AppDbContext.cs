using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Computer> Computer { get; set; }
		public DbSet<User> User { get; set; }
		public DbSet<Apontment> Apontment { get; set; }
	}
}
