using System.Linq;
using System.Runtime.CompilerServices;
using Absolute_Cinema_Backend.Dto;
using Absolute_Cinema_Backend.Models;
using Absolute_Cinema_Backend.Repository.Abstractions;
using Absolute_Cinema_Backend.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Absolute_Cinema_Backend.Services.Implementations
{
    public class ShowtimeService : IShowtimeService
    {
        private readonly IShowtimeRepository _showtimeRepository;
        public ShowtimeService(IShowtimeRepository showtimeRepository)
        {
            _showtimeRepository = showtimeRepository;
        }
        public async Task<List<Showtime>> GetShowtimesJoinedWithMoviesAsync(QueryDto query)
        {
            var result = _showtimeRepository.GetShowtimes().AsQueryable();

            if (query.SessionTypes?.Any() == true)
            {
                result = result.Where(x => query.SessionTypes.Contains(x.SessionType.Title.ToLower()));
            }

            if (query.Resolutions?.Any() == true)
            {
                result = result.Where(x => query.Resolutions.Contains(x.Resolution.Title.ToLower()));
            }

            if (query.Genres?.Any() == true)
            {
                result = result.Where(x => x.Movie.Genres.Any(g => query.Genres.Contains(g.Title.ToLower())));
            }

            if (query.Languages?.Any() == true)
            {
                result = result.Where(x => query.Languages.Contains(x.Language.Title.ToLower()));
            }

            var showtimes = await result
                .GroupBy(x => x.MovieId)
                .Select(g => g
                    .OrderBy(s => s.StartDateTime)
                    .First())
                .ToListAsync();

            return showtimes;
        }
    }
}
