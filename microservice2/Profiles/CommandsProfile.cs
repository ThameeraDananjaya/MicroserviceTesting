using AutoMapper;

namespace microservice2
{
    public class CommandsProfile : Profile
    {
        // Source -> Target
        public CommandsProfile()
        {
            CreateMap<Platform,PlatformReadDto>();
            CreateMap<CommandCreateDto,Command>();
            CreateMap<Command,CommandReadDto>();
        }
    }
}