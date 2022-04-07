using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public interface IGamesRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync();
        Task<Game> GetGameAsync(int gameId);
        //void AddGame(Game game);
        //void DeleteGame(Game game);
        //void UpdateGame(Game game);
        //Task<bool> GameExistsAsync(int gameId);
    }
}
