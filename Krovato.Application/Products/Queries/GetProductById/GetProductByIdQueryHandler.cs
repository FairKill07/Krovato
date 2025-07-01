using AutoMapper;
using Krovato.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductVm?>
    {
        private readonly IKrovatoDbContext _context;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IKrovatoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVm?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (product is null)
                return null;

            return _mapper.Map<ProductVm>(product);
        }
    }

}
