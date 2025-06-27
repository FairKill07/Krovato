using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Krovato.Application.Common.Mappings;
using Krovato.Application.Images.Commands.UploadImage;

namespace Krovato.WebAPI.Model.Images
{
    public class UploadImageDto : IMapWith<UploadImageCommand>
    {
        [Required]
        public string Url { get; set; } = null!;
        public string? AltText { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UploadImageDto, UploadImageCommand>()
                .ForMember(command => command.Url,
                    opt => opt.MapFrom(dto => dto.Url))
                .ForMember(command => command.AltText,
                    opt => opt.MapFrom(dto => dto.AltText));
        }
    }
}
