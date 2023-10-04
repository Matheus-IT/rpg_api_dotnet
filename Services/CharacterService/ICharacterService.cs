using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpg_game.Dtos.Character;
using rpg_game.Models;

namespace rpg_game.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAll();
        Task<ServiceResponse<GetCharacterDto>> GetById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddOne(AddCharacterDto character);
        Task<ServiceResponse<GetCharacterDto>> UpdateOne(UpdateCharacterDto character);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteOne(int id);
    }
}