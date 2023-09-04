using System;
using CatalogService.DataAccess.Concrete.PostgreSql;
using EventBus.Events;
using MassTransit;

namespace CatalogService.Business.Consumers
{
    public class UpdateCompanyNameConsumer : IConsumer<CompanyNameChangedEvent>
    {
        private readonly CatalogDbContext _context;

        public UpdateCompanyNameConsumer(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<CompanyNameChangedEvent> context)
        {
            var updatedData = _context.Products.Where(x => x.CompanyId == context.Message.UserId).ToList();
            var res = updatedData.Select(x => { x.CompanyName = context.Message.ChangedName; return x; }).ToList();
            _context.SaveChanges();

        }
    }
}

