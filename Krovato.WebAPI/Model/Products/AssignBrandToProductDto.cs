using AutoMapper;
using Krovato.Application.Common.Mappings;
using Krovato.Application.Products.Commands.AssignBrandToProduct;

namespace Krovato.WebAPI.Model.Products
{
    public class AssignBrandToProductDto : IMapWith<AssignBrandToProductCommand>
    {
        public Guid ProductId { get; set; }
        public Guid BrandId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AssignBrandToProductDto, AssignBrandToProductCommand>()
                .ForMember(command => command.ProductId,
                    opt => opt.MapFrom(dto => dto.ProductId))
                .ForMember(command => command.BrandId,
                    opt => opt.MapFrom(dto => dto.BrandId));
        }
    }
}
