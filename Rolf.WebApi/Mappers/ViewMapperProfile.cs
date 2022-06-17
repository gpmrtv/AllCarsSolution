using AutoMapper;
using AllCar.Shared.Dto;
using AllCar.Shared.Dto.Identity;
using AllCar.Shared.Dto.References;
using AllCar.Shared.ViewModels;
using AllCar.Shared.ViewModels.Identity;
using AllCar.Shared.ViewModels.References;

namespace AllCar.WebApi.Mappers
{
    public class ViewMapperProfile : Profile
    {
        public ViewMapperProfile()
        {
            CreateMap<UserViewModel, UserDto>().ReverseMap();

            CreateMap<CarViewModel, CarDto>().ReverseMap();
            CreateMap<MakeViewModel, MakeDto>().ReverseMap();
            CreateMap<ModelViewModel, ModelDto>().ReverseMap();
            CreateMap<BodyViewModel, BodyDto>().ReverseMap();
            CreateMap<EquipmentVariantViewModel, EquipmentVariantDto>().ReverseMap();
            CreateMap<GearboxViewModel, GearboxDto>().ReverseMap();
            CreateMap<GearViewModel, GearDto>().ReverseMap();
            CreateMap<GenerationViewModel, GenerationDto>().ReverseMap();
        }
    }
}
