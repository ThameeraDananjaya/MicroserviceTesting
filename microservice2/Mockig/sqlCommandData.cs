using System.Collections.Generic;
using System.Linq;

namespace microservice2
{
    public class sqlCommandData : ICommandData
    {
        private readonly MS2Context MS2Context;

        public sqlCommandData(MS2Context context)
        {
            MS2Context=context;
        }

        public void CreateCommand(int platformId, Command command)
        {
            if(command!=null)
            {
                command.PlatformId=platformId;
                MS2Context.Commands.Add(command);
            }
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform != null)
            {
                MS2Context.Platforms.Add(platform);
            }
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return MS2Context.Platforms.ToList();
        }

        public Command GetCommand(int platformId, int commandId)
        {
            return MS2Context.Commands.Where(c => c.PlatformId == platformId && c.Id == commandId).FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformId)
        {
            return MS2Context.Commands.Where(c => c.PlatformId == platformId).OrderBy(c => c.Platform.Name);
        }

        public bool PlatformExist(int platformId)
        {
            return MS2Context.Platforms.Any(p => p.Id == platformId);
        }

        public bool SaveChanges()
        {
            return(MS2Context.SaveChanges() >=0);
        }
    }
}