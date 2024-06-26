﻿using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
	public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
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
