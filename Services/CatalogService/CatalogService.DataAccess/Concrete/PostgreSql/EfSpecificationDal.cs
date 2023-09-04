using System;
using CatalogService.DataAccess.Abstract;
using CatalogService.Entities.Concrete;
using K123ShopApp.Core.DataAccess.EntityFramework;

namespace CatalogService.DataAccess.Concrete.PostgreSql
{
	public class EfSpecificationDal : EfRepositoryBase<Specification, CatalogDbContext>, ISpecificationDal
    {
        public void AddSpecifications(int productId, List<Specification> specifications)
        {
            using var context = new CatalogDbContext();
            List<Specification> res = specifications.Select(x =>
            {
                x.ProductId = productId;
                x.CreatedDate = DateTime.UtcNow;
                return x;
            }).ToList();

            context.Specifications.AddRange(res);
            context.SaveChanges();
        }
    }
}

