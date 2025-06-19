using System.ComponentModel.DataAnnotations;
using Krovato.Application.Common.Mappings;
using Krovato.Application.Products.Commands.AddProductImage;

namespace Krovato.WebAPI.Model
{
    public class AssignImageDTO : IMapWith<AssignImagesToProductCommand>
    {
        [Required]
        public List<Guid> ImageIds { get; set; } = [];
        public Guid ProductId { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<AssignImageDTO, AssignImagesToProductCommand>()
                .ForMember(command => command.ImageIds,
                    opt => opt.MapFrom(dto => dto.ImageIds))
                .ForMember(command => command.ProductId,
                    opt => opt.MapFrom(dto => dto.ProductId));
        }
    }
}
