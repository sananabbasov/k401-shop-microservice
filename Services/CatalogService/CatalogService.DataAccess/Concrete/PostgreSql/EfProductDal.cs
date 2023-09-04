using System;
using CatalogService.DataAccess.Abstract;
using CatalogService.Entities.Concrete;
using CatalogService.Entities.Dtos.ProductsDtos;
using K123ShopApp.Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.DataAccess.Concrete.PostgreSql
{
	public class EfProductDal : EfRepositoryBase<Product, CatalogDbContext>, IProductDal
    {
        public Product GetProduct(int id)
        {
            using var context = new CatalogDbContext();
            var product = context.Products.Include(x => x.Category).Include(x => x.Specifications).SingleOrDefault(x => x.Id == id);
            return product;
        }

        public void RemoveProductQuantity(List<ProductDecrementDto> productDecrement)
        {
            using var context = new CatalogDbContext();
            for (int i = 0; i < productDecrement.Count; i++)
            {
                var product = context.Products.FirstOrDefault(x => x.Id == productDecrement[i].ProductId);
                product.Quantity -= productDecrement[i].Quantity;
                context.SaveChanges();
            }

        }
    }
}

