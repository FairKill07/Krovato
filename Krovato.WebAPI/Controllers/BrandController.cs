using AutoMapper;
using Krovato.Application.Brands.Commands.CreateBrand;
using Krovato.Application.Brands.Commands.DeleteBrand;
using Krovato.Application.Brands.Commands.UpdateBrand;
using Krovato.WebAPI.Model.Brands;
using Microsoft.AspNetCore.Mvc;

namespace Krovato.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : BaseController
    {
        private readonly IMapper _mapper;

        public BrandController(IMapper mapper) => _mapper = mapper;

        [HttpPost("Create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBrandDto createBrandDto)
        {
            var command = _mapper.Map<CreateBrandCommand>(createBrandDto);
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateBrandDto updateBrandDto)
        {
            var command = _mapper.Map<UpdateBrandCommand>(updateBrandDto);
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteBrandCommand { Id = id };
            var deletedId = await Mediator.Send(command);
            return Ok(deletedId);
        }
    }
}
