using System.Collections.Generic;

namespace microservice2
{
    public interface IPlatformData
    {
        List<Platform> GetPlatforms();

        Platform GetPlatform(int id);

        Platform AddPlatform(Platform platform);
        
        Platform UpdatePlatform(int id,Platform platform);

        void DeletePlatform(int id);
    }
}
