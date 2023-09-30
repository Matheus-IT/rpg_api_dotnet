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

        public List<Character> AddOne(Character character)
        {
            characters.Add(character);
            return characters;
        }

        public List<Character> GetAll()
        {
            return characters;
        }

        public Character GetById(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id) ?? throw new Exception("Character not found");
        }
    }
}