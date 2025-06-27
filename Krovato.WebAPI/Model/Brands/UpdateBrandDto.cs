using Krovato.Application.Brands.Commands.UpdateBrand;
using Krovato.Application.Common.Mappings;

namespace Krovato.WebAPI.Model.Brands
{
    public class UpdateBrandDto : IMapWith<UpdateBrandCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Country { get; set; }
        public string? Description { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<UpdateBrandDto, UpdateBrandCommand>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Country, opt => opt.MapFrom(x => x.Country))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description));
        }

    }
}
