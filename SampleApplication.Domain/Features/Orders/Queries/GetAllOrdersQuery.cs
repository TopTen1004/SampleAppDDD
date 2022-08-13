using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApplication.Domain.Entities;
using SampleApplication.Domain.Interface;

namespace SampleApplication.Domain.Features.Orders.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {
        public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
        {
            private readonly IUnitOfWork _context;
            public GetAllOrdersQueryHandler(IUnitOfWork context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
            {
                var orderList = _context.Orders.ListAll();
                if (orderList == null)
                {
                    return null;
                }
                return orderList.ToList();
            }
        }
    }
}
