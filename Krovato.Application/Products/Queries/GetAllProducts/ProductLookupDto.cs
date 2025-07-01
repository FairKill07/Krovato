using Krovato.Application.Common.Mappings;
using Krovato.Domain.Products.Entities;

namespace Krovato.Application.Products.Queries.GetAllProducts
{
    public class ProductLookupDto : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public int Stock { get; set; }
        public string? CategoryName { get; set; }
        public string? BrandName { get; set; }
        public List<string> ImageUrls { get; set; } = new();

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Product, ProductLookupDto>()
                    .ForMember(dest => dest.ImageUrls, opt => opt
                    .MapFrom(src => src.Images.Select(i => i.Url).ToList()));
        }
    }

}
