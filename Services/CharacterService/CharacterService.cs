using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using rpg_game.Dtos.Character;
using rpg_game.Models;

namespace rpg_game.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> _characters = new List<Character>{
            new Character(),
            new Character { Id = 1, Name = "sam" },
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddOne(AddCharacterDto character)
        {
            var newCharacter = _mapper.Map<Character>(character);
            newCharacter.Id = _characters.Max(c => c.Id) + 1;
            _characters.Add(newCharacter);
            return new ServiceResponse<List<GetCharacterDto>>(_characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList());
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteOne(int id)
        {
            try
            {
                var character = _characters.FirstOrDefault(c => c.Id == id);
                if (character is null)
                    throw new Exception($"Character of id '{id}' not found.");

                _characters.Remove(character);

                return new ServiceResponse<List<GetCharacterDto>>(_characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList());
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<GetCharacterDto>>(null, e.Message, false);
            }
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAll()
        {
            return new ServiceResponse<List<GetCharacterDto>>(_characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList());
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetById(int id)
        {
            var character = _characters.FirstOrDefault(c => c.Id == id);
            return new ServiceResponse<GetCharacterDto>(_mapper.Map<GetCharacterDto>(character));
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateOne(UpdateCharacterDto updatedCharacter)
        {
            try
            {
                var character = _characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                if (character is null)
                    throw new Exception($"Character of id '{updatedCharacter.Id}' not found.");
                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strength = updatedCharacter.Strength;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                return new ServiceResponse<GetCharacterDto>(_mapper.Map<GetCharacterDto>(character));
            }
            catch (Exception e)
            {
                return new ServiceResponse<GetCharacterDto>(null, e.Message, false);
            }
        }
    }
}