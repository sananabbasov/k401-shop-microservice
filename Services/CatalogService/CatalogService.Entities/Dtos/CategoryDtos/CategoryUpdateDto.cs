﻿using System;
namespace CatalogService.Entities.Dtos.CategoryDtos
{
	public class CategoryUpdateDto
	{
        public string CategoryName { get; set; }
        public bool IsNavbar { get; set; }
        public bool IsFeatured { get; set; }
        public string PhotoUrl { get; set; }
    }
}

