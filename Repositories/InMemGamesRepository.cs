using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public class InMemGamesRepository : IGameRepository
{
    private readonly List<Game> games = new()
 {
    new Game()
    {
        Id= 1,
        Name="fifa 21",
        Genre="sports",
        Price=200,
        ReleaseDate= new DateTime(2024,11,5),
        ImageUri="https://placehold.co/100"
     },
        new Game()
    {
        Id= 2,
        Name="Counter Strike",
        Genre="Action",
        Price=250,
        ReleaseDate= new DateTime(2024,10,5),
        ImageUri="https://placehold.co/100"
     },
        new Game()
    {
        Id= 3,
        Name="MineCraft",
        Genre="Adventure",
        Price=150,
        ReleaseDate= new DateTime(2024,3,6),
        ImageUri="https://placehold.co/100"
     }
 };


    // get games
    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await Task.FromResult(games);
    }

    //get game by id 
    public async Task<Game?> GetAsync(int id)
    {
        return await Task.FromResult(games.Find(game => game.Id == id));
    }

    // add new game 
    public async Task CreateAsync(Game game)
    {

        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);

        await Task.CompletedTask;
    }

    //  upadte game
    public async Task UpdateAsync(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;

        await Task.CompletedTask;
    }

    // delete game
    public async Task DeleteAsync(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);

        await Task.CompletedTask;
    }
}