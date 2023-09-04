using System;
using IdentityService.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Api.Data
{
	public class AppDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=127.0.0.1,1433;Database=K401IdentityServiceDb; User Id=SA; Password=Ehmed123; TrustServerCertificate=True;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

    }
}

