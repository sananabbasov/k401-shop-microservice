using System;
using AutoMapper;
using CatalogService.Business.Abstract;
using CatalogService.DataAccess.Abstract;
using CatalogService.Entities.Concrete;
using CatalogService.Entities.Dtos.CategoryDtos;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Core.Utilities.Results.Concrete.SuccessResults;

namespace CatalogService.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public IResult CreateCategory(CategoryCreateDto categoryCreate)
        {
            var map = _mapper.Map<Category>(categoryCreate);
            _categoryDal.Add(map);
            return new SuccessResult();
        }

        public IResult DeleteCategory(int id)
        {
            var findCategory = _categoryDal.Get(x=>x.Id == id);
            _categoryDal.Delete(findCategory);
            return new SuccessResult();
        }

        public IDataResult<List<CategoryDto>> GetCategories()
        {
            var categories = _categoryDal.GetAll();
            var mapToCategoryList = _mapper.Map<List<CategoryDto>>(categories);
            return new SuccessDataResult<List<CategoryDto>>(mapToCategoryList);
        }

        public IDataResult<List<CategoryHomeDto>> GetHomeCagories()
        {
            var categories = _categoryDal.GetAll(x=>x.IsFeatured == true);
            var mapToCategoryList = _mapper.Map<List<CategoryHomeDto>>(categories);
            return new SuccessDataResult<List<CategoryHomeDto>>(mapToCategoryList);
        }

        public IDataResult<List<CategoryNavbarDto>> GetNavbarCategories()
        {
            var categories = _categoryDal.GetAll(x => x.IsNavbar == true);
            var mapToCategoryList = _mapper.Map<List<CategoryNavbarDto>>(categories);
            return new SuccessDataResult<List<CategoryNavbarDto>>(mapToCategoryList);
        }

        public IResult UpdateCategory(int id, CategoryUpdateDto category)
        {
            var findCategory = _categoryDal.Get(x => x.Id == id);
            var mapToCategory = _mapper.Map<CategoryUpdateDto>(findCategory);
            return new SuccessResult();
        }
    }
}

