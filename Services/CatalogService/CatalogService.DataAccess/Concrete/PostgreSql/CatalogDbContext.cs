using System;
using CatalogService.Entities.Concrete;
using K123ShopApp.Core.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.DataAccess.Concrete.PostgreSql
{
	public class CatalogDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=CatalogService;User Id=postgres;Password=mysecretpassword;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Specification> Specifications { get; set; }

        public override int SaveChanges()
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => data.Entity.CreatedDate = DateTime.UtcNow
                };

                //switch (data.State)
                //{
                //    case EntityState.Added:
                //        data.Entity.CreatedDate = DateTime.Now;
                //        data.Entity.UpdatedDate = DateTime.Now;
                //        break;
                //    case EntityState.Modified:
                //        data.Entity.UpdatedDate = DateTime.Now;
                //        break;
                //    default:
                //        data.Entity.UpdatedDate = DateTime.Now;
                //        data.Entity.CreatedDate = DateTime.Now;
                //        break;
                //}
            }

            return base.SaveChanges();
        }
    }
}

