using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Krovato.Application.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Country { get; set; }
        public string? Description { get; set; }
    }
}
