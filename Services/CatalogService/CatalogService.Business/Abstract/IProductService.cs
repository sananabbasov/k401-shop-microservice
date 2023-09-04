using System;
using CatalogService.Entities.Dtos.ProductsDtos;
using K123ShopApp.Core.Utilities.Results.Abstract;

namespace CatalogService.Business.Abstract
{
	public interface IProductService
	{
        IResult CreateProduct(int companyId, string companyName, ProductCreateDto productCreate);
        IResult UpdateProduct(ProductUpdateDto productUpdate);
        IResult RemoveProduct(int id);
        IDataResult<ProductDetailDto> GetProductById(int id);
        IDataResult<List<ProductFeaturedDto>> GetFeaturedProducts();
        IDataResult<List<ProductRecentDto>> GetRecentProduct();
        IDataResult<List<ProductFilterDto>> FilterProduct(int categoryId, decimal minPrice, decimal maxPrice);
        IDataResult<List<ProductDto>> GetAllProdcuts();
        IDataResult<bool> CheckProductStock(List<int> ids);
        IResult ProductOrder(List<ProductDecrementDto> productDecrement);
    }
}

