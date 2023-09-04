using System;
using MassTransit;
using EventBus.Events;
using OrderService.Api.Repositories.Abstract;
using OrderService.Api.Models;

namespace OrderService.Api.Consumers
{
    public class UpdateUserInfoConsumer : IConsumer<UserInfoChangeEvent>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateUserInfoConsumer(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Consume(ConsumeContext<UserInfoChangeEvent> context)
        {
            Order order = new()
            {
                FirstName = context.Message.FirstName,
                LastName = context.Message.LastName
            };
            _orderRepository.UpdateRangeById(x=>x.UserId == context.Message.UserId, order);
        }
    }
}


