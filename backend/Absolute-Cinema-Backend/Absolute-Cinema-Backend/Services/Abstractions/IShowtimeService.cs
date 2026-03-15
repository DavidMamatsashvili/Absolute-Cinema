using Absolute_Cinema_Backend.Dto;
using Absolute_Cinema_Backend.Models;

namespace Absolute_Cinema_Backend.Services.Abstractions
{
    public interface IShowtimeService
    {
        Task<List<FrontPageMovieDto>> GetShowtimesJoinedWithMoviesAsync(QueryDto query);
        Task<List<FrontPageMovieDto>> SearchMoviesByTitle(string? searchText);
    }
}
