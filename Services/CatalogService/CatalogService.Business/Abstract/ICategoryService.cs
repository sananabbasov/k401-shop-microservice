using System;
using CatalogService.Entities.Dtos.CategoryDtos;
using K123ShopApp.Core.Utilities.Results.Abstract;

namespace CatalogService.Business.Abstract
{
	public interface ICategoryService
	{
        IResult CreateCategory(CategoryCreateDto categoryCreate);
        IResult UpdateCategory(int id, CategoryUpdateDto category);
        IResult DeleteCategory(int id);
        IDataResult<List<CategoryDto>> GetCategories();
        IDataResult<List<CategoryHomeDto>> GetHomeCagories();
        IDataResult<List<CategoryNavbarDto>> GetNavbarCategories();
    }
}

