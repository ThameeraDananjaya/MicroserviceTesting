using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace microservice1
{
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformData _platformData;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformController(IPlatformData platformData, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _platformData = platformData;
            _mapper=mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetPlatforms()
        {
            var platformItems = _platformData.GetPlatforms();
            var platformreaddtoList = _mapper.Map<List<Platform>,List<PlatformReadDto>>(platformItems);
            return Ok(platformreaddtoList);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetPlatform(int id)
        {
            var platformItem = _platformData.GetPlatform(id);
            return Ok(_mapper.Map<PlatformReadDto>(platformItem));
        }

        [HttpPost]
        [Route("api/[controller]")]
         public async Task<ActionResult<PlatformReadDto>> AddPlatform(PlatformCreateDto platformData)
        {
            Platform newPlatform = _mapper.Map<Platform>(platformData);
            _platformData.AddPlatform(newPlatform);

            var PlatformReadDto = _mapper.Map<PlatformReadDto>(newPlatform);

            try
            {
                await _commandDataClient.SendPlatformToCommand(PlatformReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously : {ex.Message}");
            }

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + PlatformReadDto.Name,PlatformReadDto);
            
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