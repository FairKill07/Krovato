using Krovato.Application.Common.Mappings;
using Krovato.Application.Categorys.Commands.UpdateCategory;

namespace Krovato.WebAPI.Model.Categorys
{
    public class UpdateCategoryDto : IMapWith<UpdateCategoryCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? ParentId { get; set; }
        public string Slug { get; set; } = null!;

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<UpdateCategoryDto, UpdateCategoryCommand>();
        }
    }
}
