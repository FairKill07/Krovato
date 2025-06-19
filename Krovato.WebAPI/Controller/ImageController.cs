using AutoMapper;
using Krovato.Application.Images.Commands.UploadImage;
using Krovato.Application.Products.Commands.AddProductImage;
using Krovato.WebAPI.Controllers;
using Krovato.WebAPI.Model;

using Microsoft.AspNetCore.Mvc;

namespace Krovato.WebAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : BaseController
    {
        private readonly IMapper _mapper;
        public ImageController(IMapper mapper) => _mapper = mapper;

        [HttpPost("Upload")]
        public async Task<ActionResult<Guid>> Upload([FromBody] UploadImageDto uploadImageDto)
        {
            var command = _mapper.Map<UploadImageCommand>(uploadImageDto);
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPost("Assign")]
        public async Task<ActionResult> AssignImage([FromBody] AssignImageDTO assignImageDTO )
        {
            var command = _mapper.Map<AssignImagesToProductCommand>(assignImageDTO);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
