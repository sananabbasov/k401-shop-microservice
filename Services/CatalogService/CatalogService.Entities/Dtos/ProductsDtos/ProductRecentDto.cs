﻿using System;

namespace CatalogService.Entities.Dtos.ProductsDtos
{
	public class ProductRecentDto
	{
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
    }
}

