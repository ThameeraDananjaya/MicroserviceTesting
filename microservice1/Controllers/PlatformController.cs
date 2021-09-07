using Microsoft.AspNetCore.Mvc;

namespace microservice1
{
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformData _platformData;

        public PlatformController(IPlatformData platformData)
        {
            _platformData = platformData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetPlatforms()
        {
            return Ok(_platformData.GetPlatforms());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetPlatform(int id)
        {
            return Ok(_platformData.GetPlatform(id));
        }

        [HttpPost]
        [Route("api/[controller]")]
         public IActionResult AddPlatform(Platform platformData)
        {
            _platformData.AddPlatform(platformData);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + platformData.Id,platformData);
            
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeletePlatform(int id)
        {
            _platformData.DeletePlatform(id);
            return NotFound();

        }

         [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdatePlatform(int id,Platform platform)
        {
            _platformData.UpdatePlatform(id,platform);
            return Ok(platform);

        }
    }
}