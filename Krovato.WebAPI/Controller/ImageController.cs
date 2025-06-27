using AutoMapper;
using Krovato.Application.Images.Commands.UploadImage;
using Krovato.Application.Products.Commands.AssignImagesToProduct;
using Krovato.Application.Products.Commands.RemoveProductImages;
using Krovato.WebAPI.Controllers;
using Krovato.WebAPI.Model.Images;
using Krovato.WebAPI.Model.Products;
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

        [HttpPost("AssignImages")]
        public async Task<ActionResult> AssignImage([FromBody] AssignImagesDto assignImageDTO)
        {
            var command = _mapper.Map<AssignImagesToProductCommand>(assignImageDTO);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("RemoveAssignImages")]
        public async Task<ActionResult> RemoveAssignImage([FromBody] RemoveProductImagesDto removeImageDTO)
        {
            var command = _mapper.Map<RemoveProductImageCommand>(removeImageDTO);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
