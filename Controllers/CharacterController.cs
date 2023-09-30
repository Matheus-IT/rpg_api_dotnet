using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<Character>> Get()
        {
            return Ok(_characterService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {
            return Ok(_characterService.GetById(id));
        }

        [HttpPost]
        public ActionResult<List<Character>> Add(Character character)
        {
            _characterService.AddOne(character);
            return Ok(_characterService.GetAll());
        }
    }
}