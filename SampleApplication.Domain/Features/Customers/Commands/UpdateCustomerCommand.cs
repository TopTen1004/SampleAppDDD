using MediatR;
using SampleApplication.Domain.Entities;
using SampleApplication.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Domain.Features.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PostaCode { get; set; }
        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = _unitOfWork.Customers.GetById(command.Id);
                if (customer == null)
                {
                    return default;
                }
                else
                {
                    customer.FirstName = command.FirstName;
                    customer.LastName = command.LastName;
                    customer.Address = command.Address;
                    customer.PostaCode = command.PostaCode;
                    _unitOfWork.Customers.Update(customer);
                    return 1;
                }
            }
        }
    }
}
