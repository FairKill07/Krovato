using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krovato.Application.Products.Queries.GetAllProducts
{
    public class ProductListVm 
    {
        public List<ProductLookupDto> Products { get; set; } = new();
    }
}
