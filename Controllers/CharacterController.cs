using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rpg_game.Models;

namespace rpg_game.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static Character knight = new Character();
        [HttpGet]
        public ActionResult<Character> Get()
        {
            return Ok(knight);
        }
    }
}