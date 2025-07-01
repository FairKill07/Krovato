using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Krovato.Application.Common.Mappings;
using Krovato.Domain.Products.Entities;

namespace Krovato.Application.Products.Queries.GetProductById
{
    public class ProductVm : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public int Stock { get; set; }
        public string? CategoryName { get; set; }
        public string? BrandName { get; set; }
        public List<string> ImageUrls { get; set; } = new();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductVm>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name))
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand!.Name))
            .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.Images.Select(x => x.Url)));
        }
    }

}
