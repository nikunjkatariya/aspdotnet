using EDIParser.Models;

namespace EDIParser.Services
{
    public interface ICosmosDBService
    {
        Task<Watchlist> GetAsync(string id);
        Task AddAsync(Watchlist data);
        Task UpdateAsync(string id, Watchlist data);

    }
}
