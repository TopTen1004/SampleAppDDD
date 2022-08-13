using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApplication.Domain.Entities;
using SampleApplication.Domain.Interface;

namespace SampleApplication.Domain.Features.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
        {
            private readonly IUnitOfWork _context;
            public GetAllProductsQueryHandler(IUnitOfWork context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = _context.Products.ListAll();
                if (productList == null)
                {
                    return null;
                }
                return productList.ToList();
            }
        }
    }
}
