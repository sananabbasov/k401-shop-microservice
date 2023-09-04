using System;
namespace OrderService.Api.Dtos
{
	public class CreateOrderDto
	{
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrderNumber { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}

