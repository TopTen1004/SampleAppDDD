using MediatR;
using SampleApplication.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Domain.Features.Products.Commands
{
    public class DeleteProductByIdCommand : IRequest<bool>
    {
        public int ID { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteProductByIdCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                return _unitOfWork.Products.DeleteByID(command.ID);
            }
        }
    }
}
