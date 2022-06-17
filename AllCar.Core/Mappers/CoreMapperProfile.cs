using AutoMapper;
using AllCar.Shared.Dto;
using AllCar.Shared.Dto.Identity;
using AllCar.Shared.Dto.References;
using AllCar.Shared.Entities;
using AllCar.Shared.Entities.Identity;
using AllCar.Shared.Entities.References;

namespace AllCar.Core.Mappers
{
    public class CoreMapperProfile : Profile
    {
        public CoreMapperProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
