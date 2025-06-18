using AutoMapper;
using Krovato.Application.Products.Commands.CreateProducts;
using Krovato.Application.Products.Commands.DeleteProduct;
using Krovato.Application.Products.Commands.UpdateProduct;
using Krovato.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace Krovato.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : BaseController
    {
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper) => _mapper = mapper;

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

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDto dto)
        //{
        //    var command = _mapper.Map<UpdateProductCommand>(dto);
        //    command.Id = id;
        //    await Mediator.Send(command);
        //    return NoContent();
        //}
    }
}
