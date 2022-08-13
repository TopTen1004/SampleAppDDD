using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Domain.Features.Customers.Commands;
using SampleApplication.Domain.Features.Customers.Queries;
using SampleApplication.Domain.Features.Products.Commands;
using SampleApplication.Domain.Features.Products.Queries;
using SampleApplication.DTOs.Customers;

namespace SampleApplication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediator;
        public readonly IMapper _mapper;

        public CustomerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel data)
        {
            var command = _mapper.Map<CreateCustomerCommand>(data); 
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _mediator.Send(new GetAllCustomerQuery());
            return Ok(_mapper.Map<IList<CustomerViewModel>>(data.ToList()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(_mapper.Map<CustomerViewModel>(await _mediator.Send(new GetCustomerByIdQuery { Id = id })));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCustomerByIdCommand { ID = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerViewModel data)
        {
            var command = _mapper.Map<UpdateCustomerCommand>(data);
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }
    }
}
