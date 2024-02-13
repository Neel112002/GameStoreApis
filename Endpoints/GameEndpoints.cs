using Gamestore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Repositories;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapGameEndpoints(this IEndpointRouteBuilder routes)
    {


        //define route group for endpoints
        var group = routes.MapGroup("/games")
                       .WithParameterValidation();

        group.MapGet("/", async (IGameRepository repository) =>
          (await repository.GetAllAsync()).Select(game => game.AsDto()));//.Select(game => game.AsDto() code for Dtos

        //get game by id 

        group.MapGet("/{id}", async (IGameRepository repository, int id) =>
        {
            Game? game = await repository.GetAsync(id);

            return game is not null ? Results.Ok(game.AsDto) : Results.NotFound(); // by repsitory pattern

            // (normal code without repository pattern)
            // if (game is null)
            // {
            // return Results.NotFound();
            // }
            // return Results.Ok(game);
        })

        //get game by name 
        .WithName(GetGameEndpointName);

        // add new game 

        group.MapPost("/", async (IGameRepository repository, CreateGameDto gameDto) =>
        {
            //create entity for Dtos
            Game game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                ImageUri = gameDto.ImageUri
            };

            await repository.CreateAsync(game);//by repository pattern

            // (normal code without repository pattern)
            // game.Id = games.Max(game => game.Id) + 1;
            // games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        //  upadte game
        group.MapPut("/{id}", async (IGameRepository repository, int id, UpdateGameDto updatedGameDto) =>
        {
            Game? existingGame = await repository.GetAsync(id); //by repository pattern

            // (normal code without repository pattern)
            //games.Find(game => game.Id == id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGameDto.Name;
            existingGame.Genre = updatedGameDto.Genre;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
            existingGame.ImageUri = updatedGameDto.ImageUri;

            await repository.UpdateAsync(existingGame); // by repository pattern

            return Results.NoContent();
        });

        // delete game 

        group.MapDelete("/{id}", async (IGameRepository repository, int id) =>
          {
              Game? game = await repository.GetAsync(id); // by repository pattern

              // (normal code without repository pattern)
              //games.Find(game => game.Id == id);

              if (game is not null)
              {
                  await repository.DeleteAsync(id); // by repository pattern

                  // (normal code without repository pattern)
                  //games.Remove(game);
              }
              return Results.NoContent();

          });
        return group;
    }
}