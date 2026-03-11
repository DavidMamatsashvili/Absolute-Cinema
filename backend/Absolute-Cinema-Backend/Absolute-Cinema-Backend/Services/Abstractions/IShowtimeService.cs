using Absolute_Cinema_Backend.Dto;
using Absolute_Cinema_Backend.Models;

namespace Absolute_Cinema_Backend.Services.Abstractions
{
    public interface IShowtimeService
    {
        Task<List<Showtime>> GetShowtimesJoinedWithMoviesAsync(QueryDto query);
    }
}
