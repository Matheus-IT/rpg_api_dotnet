using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpg_game.Models;

namespace rpg_game.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<Character>>> GetAll();
        Task<ServiceResponse<Character>> GetById(int id);
        Task<ServiceResponse<List<Character>>> AddOne(Character character);
    }
}