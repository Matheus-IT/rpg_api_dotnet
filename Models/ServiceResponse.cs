using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg_game.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }

        public ServiceResponse(T? data)
        {
            Data = data;
        }

        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;

    }
}