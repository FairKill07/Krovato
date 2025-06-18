using AutoMapper;
using Krovato.Application.Products.Commands.CreateProducts;
using Krovato.Application.Products.Commands.DeleteProduct;
using Krovato.Application.Products.Commands.UpdateProduct;
using Krovato.WebAPI.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Krovato.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper) => _mapper = mapper;

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductDto createProductDto)
        {
            var command = _mapper.Map<CreateProductCommand>(createProductDto);
            var id = await Mediator.Send(command); 
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            var command = _mapper.Map<UpdateProductCommand>(updateProductDto);
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
