using Krovato.Application.Brands.Commands.CreateBrand;
using Krovato.Application.Common.Mappings;

namespace Krovato.WebAPI.Model.Brands
{
    public class CreateBrandDto : IMapWith<CreateBrandCommand>
    {
        public string Name { get; set; } = null!;
        public string? Country { get; set; }
        public string? Description { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<CreateBrandDto, CreateBrandCommand>();
        }
    }
}
