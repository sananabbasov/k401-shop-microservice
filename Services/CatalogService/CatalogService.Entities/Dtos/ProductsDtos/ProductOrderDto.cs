using System;
namespace CatalogService.Entities.Dtos.ProductsDtos
{
	public class ProductOrderDto
	{
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

