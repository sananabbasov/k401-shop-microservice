using System;
using CatalogService.DataAccess.Concrete.PostgreSql;
using CatalogService.Entities.Concrete;
using K123ShopApp.Core.DataAccess;

namespace CatalogService.DataAccess.Abstract
{
	public interface ICategoryDal : IRepositoryBase<Category>
	{
	}
}

