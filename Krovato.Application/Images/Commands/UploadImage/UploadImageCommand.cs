using MediatR;

namespace Krovato.Application.Images.Commands.UploadImage
{
    public class UploadImageCommand: IRequest<Unit>
    {
        public string Url { get; set; } = null!;
        public string? AltText { get; set; }
    }
}
