using System;
using CatalogService.Entities.Dtos.SpecificationDtos;

namespace CatalogService.Entities.Dtos.ProductsDtos
{
	public class ProductCreateDto
	{
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsDeleted { get; set; }
        public List<SpecificationCreateDto> Specifications { get; set; }
    }
}

