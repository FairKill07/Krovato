using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Krovato.Application.Interfaces;
using Krovato.Domain.Catalog.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Application.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Unit>
    {
        private readonly IKrovatoDbContext _dbContext;
        public DeleteBrandCommandHandler(IKrovatoDbContext context) => _dbContext = context;
        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _dbContext.Categories
                .Where(c => c.Id == request.Id)
                .ExecuteDeleteAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
