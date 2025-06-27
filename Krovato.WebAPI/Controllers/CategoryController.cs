using AutoMapper;
using Krovato.Application.Categorys.Commands.CreateCategory;
using Krovato.Application.Categorys.Commands.DeleteCategory;
using Krovato.Application.Categorys.Commands.UpdateCategory;
using Krovato.WebAPI.Model.Categorys;
using Microsoft.AspNetCore.Mvc;

namespace Krovato.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController:BaseController
    {
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper) => _mapper = mapper;

        [HttpPost("Create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            var command = _mapper.Map<CreateCategoryCommand>(createCategoryDto);
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(updateCategoryDto);
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }

    
}
