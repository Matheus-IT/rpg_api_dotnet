using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpg_game.Models;

namespace rpg_game.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character { Id = 1, Name = "sam" },
        };

        public async Task<ServiceResponse<List<Character>>> AddOne(Character character)
        {
            characters.Add(character);
            return new ServiceResponse<List<Character>>(characters);
        }

        public async Task<ServiceResponse<List<Character>>> GetAll()
        {
            return new ServiceResponse<List<Character>>(characters);
        }

        public async Task<ServiceResponse<Character>> GetById(int id)
        {
            return new ServiceResponse<Character>(characters.FirstOrDefault(c => c.Id == id));
        }
    }
}