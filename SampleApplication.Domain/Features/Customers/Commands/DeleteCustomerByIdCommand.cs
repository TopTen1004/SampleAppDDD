using MediatR;
using SampleApplication.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Domain.Features.Customers.Commands
{
    public class DeleteCustomerByIdCommand : IRequest<bool>
    {
        public int ID { get; set; }
        public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteCustomerByIdCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(DeleteCustomerByIdCommand command, CancellationToken cancellationToken)
            {
                return _unitOfWork.Customers.DeleteByID(command.ID);
            }
        }
    }
}
