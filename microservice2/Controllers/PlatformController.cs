using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace microservice2
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {

        private readonly ICommandData _commandData;
        private readonly IMapper _mapper;
        
        public PlatformController(ICommandData commandData, IMapper mapper)
        {
            _commandData=commandData;
            _mapper=mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms from CommandService");

            var platformsItems = _commandData.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformsItems));
        }

        [HttpPost]
        public ActionResult TestinboundConnection()
        {
            Console.WriteLine("--> Inboud POST # Command Service");
            return Ok("Inboud test from Platform Contoller");
        }
    }
}