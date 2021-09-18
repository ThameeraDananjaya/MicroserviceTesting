using System.Threading.Tasks;

namespace microservice1
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto plat);
    }
}