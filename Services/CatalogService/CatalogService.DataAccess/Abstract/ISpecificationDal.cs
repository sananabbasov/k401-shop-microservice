using System;
using CatalogService.Entities.Concrete;
using K123ShopApp.Core.DataAccess;

namespace CatalogService.DataAccess.Abstract
{
	public interface ISpecificationDal : IRepositoryBase<Specification>
	{
        void AddSpecifications(int productId, List<Specification> specifications);
    }
}

