using AutoMapper;
using AllCar.Shared.Dto;
using AllCar.Shared.Dto.References;
using AllCar.Shared.Entities;
using AllCar.Shared.Entities.References;
using AllCar.Shared.ViewModels;
using AllCar.Shared.ViewModels.References;

namespace AllCar.WebApi.Mappers
{
    public class ViewMapperProfile : Profile
    {
        public ViewMapperProfile()
        {
            CreateMap<CarEntity, CarDto>().ReverseMap();
            CreateMap<ColorEntity, ColorDto>().ReverseMap();
            CreateMap<MakeEntity, MakeDto>().ReverseMap();
            CreateMap<ModelEntity, ModelDto>().ReverseMap();
            CreateMap<BodyEntity, BodyDto>().ReverseMap();
            CreateMap<EquipmentVariantEntity, EquipmentVariantDto>().ReverseMap();
            CreateMap<GearboxEntity, GearboxDto>().ReverseMap();
            CreateMap<GearEntity, GearDto>().ReverseMap();
            CreateMap<GenerationEntity, GenerationDto>().ReverseMap();
            CreateMap<AreaEntity, AreaDto>().ReverseMap();
            CreateMap<CarAreasEntity, CarAreasDto>().ReverseMap();

            CreateMap<CarViewModel, CarDto>().ReverseMap();
            CreateMap<ColorViewModel, ColorDto>().ReverseMap();
            CreateMap<MakeViewModel, MakeDto>().ReverseMap();
            CreateMap<ModelViewModel, ModelDto>().ReverseMap();
            CreateMap<BodyViewModel, BodyDto>().ReverseMap();
            CreateMap<EquipmentVariantViewModel, EquipmentVariantDto>().ReverseMap();
            CreateMap<GearboxViewModel, GearboxDto>().ReverseMap();
            CreateMap<GearViewModel, GearDto>().ReverseMap();
            CreateMap<GenerationViewModel, GenerationDto>().ReverseMap();
            CreateMap<AreaViewModel, AreaDto>().ReverseMap();
            CreateMap<CarAreasViewModel, CarAreasDto>().ReverseMap();
        }
    }
}
