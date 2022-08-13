using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Domain.Entities;
using SampleApplication.Domain.Features.Orders.Commands;
using SampleApplication.Domain.Features.Products.Commands;
using SampleApplication.Domain.Features.Products.Queries;
using SampleApplication.Domain.Interface;
using SampleApplication.DTOs.Orders;
using SampleApplication.DTOs.Product;
using SampleApplication.Infrastructure.Repositories;

namespace SampleApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;
        public readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel data)
        {
            var command = _mapper.Map<CreateProductCommand>(data);
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<IList<ProductViewModel>>(await _mediator.Send(new GetAllProductsQuery())));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<ProductViewModel>(await _mediator.Send(new GetProductsByIdQuery { Id = id })));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteProductByIdCommand { ID = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductViewModel data)
        {
            var command = _mapper.Map<UpdateProductCommand>(data);
            if (id != data.ID)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }
    }
}
