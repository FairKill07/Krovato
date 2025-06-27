using AutoMapper;
using Krovato.Application.Common.Mappings;
using Krovato.Application.Products.Commands.AssignCategoryToProduct;

namespace Krovato.WebAPI.Model.Products
{
    public class AssignCategoryToProductDto : IMapWith<AssignCategoryToProductCommand>
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AssignCategoryToProductDto, AssignCategoryToProductCommand>()
                .ForMember(command => command.ProductId,
                    opt => opt.MapFrom(dto => dto.ProductId))
                .ForMember(command => command.CategoryId,
                    opt => opt.MapFrom(dto => dto.CategoryId));
        }
    }
}
