using AutoMapper;

namespace microservice1
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            // Source -> Target
            CreateMap<Platform,PlatformReadDto>().ReverseMap();
            CreateMap<PlatformCreateDto,Platform>();
        }
    }
}