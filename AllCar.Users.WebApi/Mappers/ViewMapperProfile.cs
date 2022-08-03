using AllCar.Shared.Dto.Identity;
using AllCar.Shared.Entities.Identity;
using AutoMapper;

namespace AllCar.Users.WebApi.Mappers
{
    public class ViewMapperProfile : Profile
    {
        public ViewMapperProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
