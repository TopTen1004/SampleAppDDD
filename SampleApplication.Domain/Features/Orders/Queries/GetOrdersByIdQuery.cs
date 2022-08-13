using MediatR;
using SampleApplication.Domain.Entities;
using SampleApplication.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Domain.Features.Orders.Queries
{
    public class GetOrdersByIdQuery : IRequest<Order>
    {
        public int Id { get; set; }
        public class GetOrdersByIdQueryHandler : IRequestHandler<GetOrdersByIdQuery, Order>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetOrdersByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Order> Handle(GetOrdersByIdQuery query, CancellationToken cancellationToken)
            {
                var product = _unitOfWork.Orders.GetById(query.Id);
                if (product == null) return null;
                return product;
            }
        }
    }
}
