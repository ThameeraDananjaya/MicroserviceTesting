
using System.Collections.Generic;
using System.Linq;

namespace microservice1
{
    public class SqlPlatformData : IPlatformData
    {
        private readonly MS1Context MS1Context;

        public SqlPlatformData(MS1Context ms1Context)
        {
            MS1Context= ms1Context;
        }

        public Platform AddPlatform(Platform platform)
        {
           if(platform!=null)
            {
                MS1Context.Platforms.Add(platform);
                MS1Context.SaveChanges();
            }

            return platform;
        }

        public void DeletePlatform(int id)
        {
            Platform platform = MS1Context.Platforms.Where(x => x.Id == id).FirstOrDefault();
                if(platform != null)
                {
                    MS1Context.Platforms.Remove(platform);
                    MS1Context.SaveChanges();
                }
        }

        public Platform GetPlatform(int id)
        {
             return MS1Context.Platforms.Where(x => x.Id==id).FirstOrDefault();
        }

        public List<Platform> GetPlatforms()
        {
             return MS1Context.Platforms.ToList();
        }

        public Platform UpdatePlatform(int id, Platform platform)
        {
            if (platform!=null)
            {
                Platform existingPlatform = MS1Context.Platforms.Where(x => x.Id==id).FirstOrDefault();
                existingPlatform.Name = platform.Name;
                existingPlatform.Publisher=platform.Publisher;
                existingPlatform.Cost=platform.Cost;
                MS1Context.SaveChanges();
                platform.Id=id;
            }
            return platform;
        }
    }
}
