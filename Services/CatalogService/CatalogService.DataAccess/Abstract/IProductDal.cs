using System;
using CatalogService.Entities.Concrete;
using CatalogService.Entities.Dtos.ProductsDtos;
using K123ShopApp.Core.DataAccess;

namespace CatalogService.DataAccess.Abstract
{
	public interface IProductDal : IRepositoryBase<Product>
	{
        Product GetProduct(int id);
        void RemoveProductQuantity(List<ProductDecrementDto> productDecrement);
    }
}

