using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace microservice2
{
    [Route("api/c/platform/{platformId}/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommandData _repository;
        private readonly IMapper _mapper;

        public CommandController(ICommandData repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int platformId)
        {
            Console.WriteLine($"--> Hit GetCommandsForPatforms {platformId}");
            if(_repository.PlatformExist(platformId))
            {
                var commands = _repository.GetCommandsForPlatform(platformId);
                return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
            }
            else
            {
                return NotFound();
            }
        }
        
        [HttpPost]
        public ActionResult<CommandCreateDto> AddCommandForPlatform(int platformId, Command command)
        {
            if (_repository.PlatformExist(platformId))
            {
                command.PlatformId=platformId;
                _repository.CreateCommand(platformId,command);
                return Ok(_mapper.Map<CommandCreateDto>(command));
            }
            else
            {
                return NotFound();
            }
        }

    }
}