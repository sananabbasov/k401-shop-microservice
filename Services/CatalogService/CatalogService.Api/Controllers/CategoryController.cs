using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogService.Business.Abstract;
using CatalogService.Entities.Dtos.CategoryDtos;
using K123ShopApp.Core.Utilities.Results.Concrete.SuccessResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatalogService.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        [ProducesResponseType(typeof(SuccessDataResult<CategoryDto>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetCategories();
            return Ok(result);
        }

        [HttpGet("featured")]
        public IActionResult GetHomeFeatured()
        {
            var result = _categoryService.GetHomeCagories();
            return Ok(result);
        }


        [HttpGet("navbar")]
        public IActionResult GetNavbarLower()
        {
            var result = _categoryService.GetNavbarCategories();
            return Ok(result);
        }


        [Authorize]
        [HttpPost("create")]
        public IActionResult Create([FromBody] CategoryCreateDto categoryCreate)
        {
            var result = _categoryService.CreateCategory(categoryCreate);
            return Ok(result);
        }

        // sitename/api/category/12
        [Authorize]
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] CategoryUpdateDto categoryUpdate)
        {
            var result = _categoryService.UpdateCategory(id, categoryUpdate);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.DeleteCategory(id);
            return Ok(result);
        }
    }
}

