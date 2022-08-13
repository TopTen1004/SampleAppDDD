using MediatR;
using SampleApplication.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Domain.Features.Orders.Commands
{
    public class DeleteOrderByIdCommand : IRequest<bool>
    {
        public int ID { get; set; }
        public class DeleteOrderByIdCommandHandler : IRequestHandler<DeleteOrderByIdCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteOrderByIdCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(DeleteOrderByIdCommand command, CancellationToken cancellationToken)
            {
                return _unitOfWork.Orders.DeleteByID(command.ID);
            }
        }
    }
}
