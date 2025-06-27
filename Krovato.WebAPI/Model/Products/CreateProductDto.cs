using AutoMapper;
using Krovato.Application.Common.Mappings;
using Krovato.Application.Products.Commands.CreateProducts;
using System.ComponentModel.DataAnnotations;

namespace Krovato.WebAPI.Model.Products
{
    public class CreateProductDto : IMapWith<CreateProductCommand>
    {
        [Required]
        public Guid CategoryId { get; set; }
        public Guid? BrandId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public int Stock { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, CreateProductCommand>()
                .ForMember(productCommand => productCommand.CategoryId,
                    opt => opt.MapFrom(productDto => productDto.CategoryId))
                .ForMember(productCommand => productCommand.BrandId,
                    opt => opt.MapFrom(productDto => productDto.BrandId))
                .ForMember(productCommand => productCommand.Name,
                    opt => opt.MapFrom(productDto => productDto.Name))
                .ForMember(productCommand => productCommand.Description,
                    opt => opt.MapFrom(productDto => productDto.Description))
                .ForMember(productCommand => productCommand.BasePrice,
                    opt => opt.MapFrom(productDto => productDto.BasePrice))
                .ForMember(productCommand => productCommand.Stock,
                    opt => opt.MapFrom(productDto => productDto.Stock));
        }
    }
}

