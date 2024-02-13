using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Gamestore.Api.Dtos;

namespace GameStore.Api.Entities
{
    public static class EntityExtensions
    {
        public static GameDto AsDto(this Game game)
        {
            return new GameDto(game.Id,
            game.Name,
            game.Genre,
            game.Price,
            game.ReleaseDate,
            game.ImageUri);
        }
    }
}