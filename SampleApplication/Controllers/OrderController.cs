using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Domain.Features.Customers.Commands;
using SampleApplication.Domain.Features.Customers.Queries;
using SampleApplication.Domain.Features.Orders.Commands;
using SampleApplication.Domain.Features.Orders.Queries;
using SampleApplication.DTOs.Orders;

namespace SampleApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IMediator _mediator;
        public readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel data)
        {
            var command = _mapper.Map<CreateOrderCommand>(data);
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<IList<OrderViewModel>>(await _mediator.Send(new GetAllOrdersQuery())));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<OrderViewModel>(await _mediator.Send(new GetOrdersByIdQuery { Id = id })));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteOrderByIdCommand { ID = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderViewModel data)
        {
            var command = _mapper.Map<UpdateOrderCommand>(data);
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<OrderViewModel>(await _mediator.Send(command)));
        }
    }
}
