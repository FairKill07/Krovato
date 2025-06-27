using AutoMapper;
using Krovato.Application.Products.Commands.AssignBrandToProduct;
using Krovato.Application.Products.Commands.AssignCategoryToProduct;
using Krovato.Application.Products.Commands.CreateProducts;
using Krovato.Application.Products.Commands.DeleteProduct;
using Krovato.Application.Products.Commands.UpdateProduct;
using Krovato.WebAPI.Model.Products;
using Microsoft.AspNetCore.Mvc;

namespace Krovato.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper) => _mapper = mapper;

        [HttpPost("Create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductDto createProductDto)
        {
            var command = _mapper.Map<CreateProductCommand>(createProductDto);
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromBody] UpdateProductDto updateProductDto)
        {
            var command = _mapper.Map<UpdateProductCommand>(updateProductDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost("AssignCategoryToProduct")]
        public async Task<ActionResult<Guid>> AssignCategoryToProduct([FromBody] AssignCategoryToProductDto assignCategoryToProductDto)
        {
            var command = _mapper.Map<AssignCategoryToProductCommand>(assignCategoryToProductDto);
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPost("AssignBrandToProduct")]

        public async Task<ActionResult<Guid>> AssignBrandToProduct([FromBody] AssignBrandToProductDto assignBrandToProductDto)
        {
            var command = _mapper.Map<AssignBrandToProductCommand>(assignBrandToProductDto);
            var id = await Mediator.Send(command);
            return Ok(id);
        }
    }
}
