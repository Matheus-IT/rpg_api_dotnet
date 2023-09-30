using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpg_game.Models;

namespace rpg_game.Services.CharacterService
{
    public interface ICharacterService
    {
        List<Character> GetAll();
        Character GetById(int id);
        List<Character> AddOne(Character character);
    }
}