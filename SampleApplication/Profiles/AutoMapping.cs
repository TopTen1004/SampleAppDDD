using AutoMapper;
using SampleApplication.Domain.DTOs.Order;
using SampleApplication.Domain.Entities;
using SampleApplication.Domain.Features.Customers.Commands;
using SampleApplication.Domain.Features.Orders.Commands;
using SampleApplication.Domain.Features.Products.Commands;
using SampleApplication.DTOs.Customers;
using SampleApplication.DTOs.Orders;
using SampleApplication.DTOs.Product;

namespace SampleApplication.Profiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CustomerViewModel, Customer>().ReverseMap();
            CreateMap<OrderItemsViewModel, OrderItem>().ReverseMap();
            CreateMap<OrderViewModel, Order>().ReverseMap();
            CreateMap<ProductViewModel, Product>().ReverseMap();
            CreateMap<OrderItemsViewModel, OrderItem>().ReverseMap();
            CreateMap<OrderViewModel, OrderResponse>().ReverseMap();
            CreateMap<ProductViewModel, CreateProductCommand>().ReverseMap().ForMember(sen => sen.ID, a => a.Ignore());
            CreateMap<ProductViewModel, UpdateProductCommand>().ReverseMap();

            CreateMap<OrderViewModel, CreateOrderCommand>().ReverseMap().ForMember(sen => sen.ID, a => a.Ignore());
            CreateMap<OrderViewModel, UpdateOrderCommand>().ReverseMap();

            CreateMap<CustomerViewModel, CreateCustomerCommand>().ReverseMap().ForMember(sen => sen.ID, a => a.Ignore());
            CreateMap<CustomerViewModel, UpdateCustomerCommand>().ReverseMap();

        }
    }
}
