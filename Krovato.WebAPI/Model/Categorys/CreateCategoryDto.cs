using Krovato.Application.Categorys.Commands.CreateCategory;
using Krovato.Application.Common.Mappings;

namespace Krovato.WebAPI.Model.Categorys
{
    public class CreateCategoryDto: IMapWith<CreateCategoryCommand>
    {
        public string Name { get; set; } = null!;
        public Guid? ParentId { get; set; }
        public string Slug { get; set; } = null!;
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<CreateCategoryDto, CreateCategoryCommand>()
                .ForMember(command => command.Name,
                    opt => opt.MapFrom(dto => dto.Name))
                .ForMember(command => command.ParentId,
                    opt => opt.MapFrom(dto => dto.ParentId))
                .ForMember(command => command.Slug,
                    opt => opt.MapFrom(dto => dto.Slug));
        }
    }
}
