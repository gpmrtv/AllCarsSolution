using AllCar.Shared.Dto.Identity;
using AllCar.Shared.Entities.Identity;
using AutoMapper;

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
