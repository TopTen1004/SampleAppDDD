using MediatR;
using SampleApplication.Domain.DTOs.Order;
using SampleApplication.Domain.Entities;
using SampleApplication.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Domain.Features.Orders.Commands
{
    public class UpdateOrderCommand : IRequest<OrderResponse>
    {
        public int Id { get; set; }
        public int? IDCustomer { get; set; }
        public decimal? TotalPrice { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateOrderCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<OrderResponse> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
            {
                var order = _unitOfWork.Orders.GetById(command.Id);
                if (order == null)
                {
                    return default;
                }
                else
                {
                    order.IDCustomer = command.IDCustomer;
                    order.TotalPrice = command.TotalPrice;
                    var orderUpdated = _unitOfWork.Orders.UpdateOrder(order, command.OrderItems);
                    return new OrderResponse
                    {
                        ID = orderUpdated.ID,
                        IDCustomer = orderUpdated.IDCustomer,
                        InsertionDate = orderUpdated.InsertionDate,
                        TotalPrice = orderUpdated.TotalPrice,
                        OrderItemsList = orderUpdated.OrderItems.Select(x => new OrderItemResponse
                        {
                            ID = x.ID,
                            IDOrder = x.IDOrder,
                            IDProduct = x.IDProduct,
                            Quantity = x.Quantity
                        }).ToList()
                    };
                }
            }
        }
    }
}
