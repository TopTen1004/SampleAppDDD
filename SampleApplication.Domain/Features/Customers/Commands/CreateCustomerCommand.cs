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
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PostaCode { get; set; }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Customer> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = new Customer();
                customer.FirstName = command.FirstName;
                customer.LastName = command.LastName;
                customer.Address = command.Address;
                customer.PostaCode = command.PostaCode;

                return _unitOfWork.Customers.Add(customer);
            }
        }
    }
}
