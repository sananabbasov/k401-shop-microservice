using System;
using AutoMapper;
using CatalogService.Business.Abstract;
using CatalogService.DataAccess.Abstract;
using CatalogService.Entities.Concrete;
using CatalogService.Entities.Dtos.ProductsDtos;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Core.Utilities.Results.Concrete.ErrorResults;
using K123ShopApp.Core.Utilities.Results.Concrete.SuccessResults;

namespace CatalogService.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ISpecificationService _specificationService;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper, ISpecificationService specificationService)
        {
            _productDal = productDal;
            _mapper = mapper;
            _specificationService = specificationService;
        }

        public IDataResult<bool> CheckProductStock(List<int> ids)
        {
            var product = _productDal.GetAll(x => ids.Contains(x.Id));
            if (product.Where(x => x.Quantity == 0).Any())
            {
                return new ErrorDataResult<bool>(false);
            }
            return new SuccessDataResult<bool>(true);

        }

        public IResult CreateProduct(int companyId, string companyName, ProductCreateDto productCreate)
        {
            var mapper = _mapper.Map<Product>(productCreate);
            mapper.CompanyId = companyId;
            mapper.CompanyName = companyName;
            _productDal.Add(mapper);
            _specificationService.CreateSpecifications(mapper.Id, productCreate.Specifications);
            return new SuccessResult();
        }

        public IDataResult<List<ProductFilterDto>> FilterProduct(int categoryId, decimal minPrice, decimal maxPrice)
        {
            var products = _productDal.GetAll(x => x.CategoryId == categoryId && x.Price > minPrice && x.Price < maxPrice).OrderByDescending(x => x.Id);
            var mapper = _mapper.Map<List<ProductFilterDto>>(products);
            return new SuccessDataResult<List<ProductFilterDto>>(mapper);
        }

        public IDataResult<List<ProductDto>> GetAllProdcuts()
        {
            var products = _productDal.GetAll().OrderByDescending(x => x.Id);
            var mapper = _mapper.Map<List<ProductDto>>(products);
            return new SuccessDataResult<List<ProductDto>>(mapper);
        }

        public IDataResult<List<ProductFeaturedDto>> GetFeaturedProducts()
        {
            var products = _productDal.GetAll(x => x.IsFeatured == true).OrderByDescending(x => x.Id).Take(8);
            var mapper = _mapper.Map<List<ProductFeaturedDto>>(products);
            return new SuccessDataResult<List<ProductFeaturedDto>>(mapper);
        }

        public IDataResult<ProductDetailDto> GetProductById(int id)
        {
            var product = _productDal.GetProduct(id);
            var mapper = _mapper.Map<ProductDetailDto>(product);
            mapper.CategoryName = product.Category.CategoryName;
            return new SuccessDataResult<ProductDetailDto>(mapper);

        }

        public IDataResult<List<ProductRecentDto>> GetRecentProduct()
        {
            var products = _productDal.GetAll().OrderByDescending(x => x.Id).Take(8);
            var mapper = _mapper.Map<List<ProductRecentDto>>(products);
            return new SuccessDataResult<List<ProductRecentDto>>(mapper);
        }

        public IResult ProductOrder(List<ProductDecrementDto> productDecrement)
        {
            _productDal.RemoveProductQuantity(productDecrement);

            return new SuccessResult();
        }

        public IResult RemoveProduct(int id)
        {
            var product = _productDal.Get(x => x.Id == id);
            product.IsDeleted = true;
            _productDal.Update(product);
            return new SuccessResult();
        }

        public IResult UpdateProduct(ProductUpdateDto productUpdate)
        {
            var product = _productDal.Get(x => x.Id == productUpdate.Id);
            var mapper = _mapper.Map<Product>(productUpdate);
            _productDal.Update(mapper);
            return new SuccessResult();
        }
    }
}

