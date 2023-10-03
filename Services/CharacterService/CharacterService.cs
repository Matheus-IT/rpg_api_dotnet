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
        private static List<Character> characters = new List<Character>{
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
            newCharacter.Id = characters.Max(c => c.Id) + 1;
            characters.Add(newCharacter);
            return new ServiceResponse<List<GetCharacterDto>>(characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList());
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAll()
        {
            return new ServiceResponse<List<GetCharacterDto>>(characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList());
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetById(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);
            return new ServiceResponse<GetCharacterDto>(_mapper.Map<GetCharacterDto>(character));
        }
    }
}