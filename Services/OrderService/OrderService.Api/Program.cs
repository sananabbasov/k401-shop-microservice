using System.Text;
using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OrderService.Api.AutoMapper;
using OrderService.Api.Consumers;
using OrderService.Api.Repositories.Abstract;
using OrderService.Api.Repositories.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    var key = Encoding.ASCII.GetBytes("l3kj4afsdfdas2kl34j234j23kl4j23lkj4");
    var issuer = "ComparAcademy";
    var audience = "ComparAcademy";

    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        RequireExpirationTime = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = audience,
        ValidIssuer = issuer,
    };
});

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<UpdateUserInfoConsumer>();
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("amqp://guest:guest@localhost");
        //cfg.Message<SendEmailCommand>(x => x.SetEntityName("SendEmailCommand"));

        cfg.ReceiveEndpoint("update-user-info", c =>
        {
            c.ConfigureConsumer<UpdateUserInfoConsumer>(ctx);
        });
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

