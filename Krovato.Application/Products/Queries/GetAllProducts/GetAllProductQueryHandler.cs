using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Krovato.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, ProductListVm>
    {
        private readonly IKrovatoDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllProductQueryHandler(IKrovatoDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public async Task<ProductListVm> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productsQuery = await _dbContext.Products
                .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProductListVm { Products = productsQuery };

        }
    }
}
