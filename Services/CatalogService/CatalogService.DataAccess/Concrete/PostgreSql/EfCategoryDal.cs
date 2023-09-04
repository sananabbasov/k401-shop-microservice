using System;
using CatalogService.DataAccess.Abstract;
using CatalogService.Entities.Concrete;
using K123ShopApp.Core.DataAccess.EntityFramework;

namespace CatalogService.DataAccess.Concrete.PostgreSql
{
	public class EfCategoryDal : EfRepositoryBase<Category,CatalogDbContext>, ICategoryDal
	{
	}
}

