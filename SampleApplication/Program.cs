using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SampleApplication.Domain.Features.Products.Commands;
using SampleApplication.Domain.Interface;
using SampleApplication.Infrastructure.Models;
using SampleApplication.Infrastructure.Repositories;
using SampleApplication.Infrastructure.UnitOfWork;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SampleDbContext>(c =>
                     c.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddTransient(typeof(IOrderRepository), typeof(OrderRepository));
//builder.Services.AddTransient(typeof(ICustomerRepository), typeof(CustomerRepository));
//builder.Services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(CreateProductCommand).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
