using System;
using AutoMapper;
using CatalogService.Business.Abstract;
using CatalogService.Business.AutoMapper;
using CatalogService.Business.Concrete;
using CatalogService.Business.Consumers;
using CatalogService.DataAccess.Abstract;
using CatalogService.DataAccess.Concrete.PostgreSql;
using K123ShopApp.Core.EventBus;
using K123ShopApp.Core.EventBus.RabbitMq;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Business.DependencyResolver
{
	public static class ServiceRegistrations
	{
		public static void Create(this IServiceCollection services)
		{
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<ISpecificationDal, EfSpecificationDal>();
            services.AddScoped<ISpecificationService, SpecificationManager>();

            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManager>();


            services.AddScoped<CatalogDbContext>();
            services.AddMassTransit(config =>
            {
                config.AddConsumer<UpdateCompanyNameConsumer>();
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("amqp://guest:guest@localhost");
                    //cfg.Message<SendEmailCommand>(x => x.SetEntityName("SendEmailCommand"));

                    cfg.ReceiveEndpoint("update-prodcut-name", c =>
                    {
                        c.ConfigureConsumer<UpdateCompanyNameConsumer>(ctx);
                    });
                });
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}

