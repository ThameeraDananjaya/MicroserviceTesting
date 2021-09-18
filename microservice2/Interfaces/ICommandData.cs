using System.Collections.Generic;

namespace microservice2
{
    public interface ICommandData
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform (Platform platform);
        bool PlatformExist(int platformId);

        IEnumerable<Command> GetCommandsForPlatform(int platformId);
        Command GetCommand(int platformId, int commandId);
        void CreateCommand(int platformId,Command command);
        
    }
}