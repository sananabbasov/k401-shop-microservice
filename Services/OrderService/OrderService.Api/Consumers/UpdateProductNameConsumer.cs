using System;
using EventBus.Events;
using MassTransit;

namespace OrderService.Api.Consumers
{
    public class UpdateProductNameConsumer : IConsumer<ProductNameChangeEvent>
    {
        public Task Consume(ConsumeContext<ProductNameChangeEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}

