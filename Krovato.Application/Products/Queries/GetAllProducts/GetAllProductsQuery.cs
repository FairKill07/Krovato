﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Krovato.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ProductListVm>
    {
    }
}
