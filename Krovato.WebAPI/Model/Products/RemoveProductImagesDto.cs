using System.ComponentModel.DataAnnotations;
using Krovato.Application.Common.Mappings;
using Krovato.Application.Products.Commands.RemoveProductImages;

namespace Krovato.WebAPI.Model.Products
{
    public class RemoveProductImagesDto : IMapWith<RemoveProductImageCommand>
    {
        [Required]
        public List<Guid> ImageIds { get; set; } = [];
        public Guid ProductId { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<RemoveProductImagesDto, RemoveProductImageCommand>()
                .ForMember(command => command.ImageIds,
                    opt => opt.MapFrom(dto => dto.ImageIds))
                .ForMember(command => command.ProductId,
                    opt => opt.MapFrom(dto => dto.ProductId));
        }
    }
}
