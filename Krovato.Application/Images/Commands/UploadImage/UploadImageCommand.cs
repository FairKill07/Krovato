using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Krovato.Domain.Products.Entities;
using MediatR;

namespace Krovato.Application.Images.Commands.UploadImage
{
    public class UploadImageCommand: IRequest<Unit>
    {
        public string Url { get; set; } = null!;
        public string? AltText { get; set; }
    }
}
