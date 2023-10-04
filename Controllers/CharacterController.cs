using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rpg_game.Dtos.Character;
using rpg_game.Models;
using rpg_game.Services.CharacterService;

namespace rpg_game.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok(await _characterService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Add(AddCharacterDto character)
        {
            await _characterService.AddOne(character);
            return Ok(await _characterService.GetAll());
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Update(UpdateCharacterDto updatedCharacter)
        {
            var serviceRes = await _characterService.UpdateOne(updatedCharacter);
            if (serviceRes.Data is null)
                return NotFound(serviceRes);
            return Ok(serviceRes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteSingle(int id)
        {
            var serviceRes = await _characterService.DeleteOne(id);
            if (serviceRes.Data is null)
                return NotFound(serviceRes);
            return Ok(serviceRes);
        }
    }
}