using System;
using AutoMapper;
using CatalogService.Entities.Concrete;
using CatalogService.Entities.Dtos.CategoryDtos;
using CatalogService.Entities.Dtos.ProductsDtos;
using CatalogService.Entities.Dtos.SpecificationDtos;

namespace CatalogService.Business.AutoMapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{

            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryHomeDto>();
            CreateMap<Category, CategoryNavbarDto>();



            CreateMap<Product, ProductDetailDto>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<ProductCreateDto, Product>();

            CreateMap<Product, ProductRecentDto>();
            CreateMap<Product, ProductFilterDto>();
            CreateMap<Product, ProductFeaturedDto>();
            CreateMap<Product, ProductDto>();

            CreateMap<SpecificationCreateDto, Specification>();
            CreateMap<Specification, SpecificationListDto>();
        }
	}
}

