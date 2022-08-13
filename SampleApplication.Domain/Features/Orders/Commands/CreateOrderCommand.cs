using MediatR;
using SampleApplication.Domain.Entities;
using SampleApplication.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Domain.Features.Orders.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public int? IDCustomer { get; set; }
        public decimal? TotalPrice { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Order> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
            {
                var order = new Order();
                order.IDCustomer = command.IDCustomer;
                order.TotalPrice = command.TotalPrice;

                
                return _unitOfWork.Orders.AddOrder(order, command.OrderItems);
            }
        }
    }
}
