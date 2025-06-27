using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Krovato.Application.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
