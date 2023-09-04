using System;
using AutoMapper;
using OrderService.Api.Dtos;
using OrderService.Api.Models;

namespace OrderService.Api.AutoMapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Order, CreateOrderDto>().ReverseMap();
			CreateMap<Order, OrderDto>().ReverseMap();

			CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        }
	}
}

