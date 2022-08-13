using MediatR;
using SampleApplication.Domain.Entities;
using SampleApplication.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Domain.Features.Products.Queries
{
    public class GetProductsByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductsByIdQuery, Product>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Product> Handle(GetProductsByIdQuery query, CancellationToken cancellationToken)
            {
                var product = _unitOfWork.Products.GetById(query.Id);
                if (product == null) return null;
                return product;
            }
        }
    }
}
