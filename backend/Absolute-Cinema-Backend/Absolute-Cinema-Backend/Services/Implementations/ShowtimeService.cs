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
        private readonly ILogger<ShowtimeService> _logger;

        public ShowtimeService(
            IShowtimeRepository showtimeRepository,
            ILogger<ShowtimeService> logger)
        {
            _showtimeRepository = showtimeRepository;
            _logger = logger;
        }

        public async Task<List<FrontPageMovieDto>> GetShowtimesJoinedWithMoviesAsync(QueryDto query)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(query);

                var result = _showtimeRepository.GetShowtimes()
                    .Include(x => x.Movie)
                        .ThenInclude(x => x.Rating)
                    .AsQueryable();

                if (query.SessionTypes?.Any() == true)
                {
                    _logger.LogInformation("Filtering by session types: {SessionTypes}", query.SessionTypes);
                    result = result.Where(x => query.SessionTypes.Contains(x.SessionType.Title.ToLower()));
                }

                if (query.Resolutions?.Any() == true)
                {
                    _logger.LogInformation("Filtering by resolutions: {Resolutions}", query.Resolutions);
                    result = result.Where(x => query.Resolutions.Contains(x.Resolution.Title.ToLower()));
                }

                if (query.Genres?.Any() == true)
                {
                    _logger.LogInformation("Filtering by genres: {Genres}", query.Genres);
                    result = result.Where(x => x.Movie.Genres.Any(g => query.Genres.Contains(g.Title.ToLower())));
                }

                if (query.Languages?.Any() == true)
                {
                    _logger.LogInformation("Filtering by languages: {Languages}", query.Languages);
                    result = result.Where(x => query.Languages.Contains(x.Language.Title.ToLower()));
                }

                var showtimes = await result
                    .GroupBy(x => x.MovieId)
                    .Select(g => g.OrderBy(s => s.StartDateTime)
                    .Select(k =>
                        new FrontPageMovieDto(
                            k.Movie.Id,
                            k.Movie.Title,
                            k.Movie.Rating.Title,
                            k.Movie.DurationMinutes,
                            k.Movie.PosterUrl))
                    .FirstOrDefault())
                    .ToListAsync();

                _logger.LogInformation("Showtimes fetched successfully. Result count: {Count}", showtimes.Count);

                return showtimes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching showtimes with filters");
                throw;
            }
        }

        public async Task<List<FrontPageMovieDto>> SearchMoviesByTitle(string searchText)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(searchText);

                var result = _showtimeRepository.GetShowtimes()
                    .Include(x => x.Movie)
                        .ThenInclude(x => x.Rating)
                    .AsQueryable();

                List<FrontPageMovieDto> movies = await result
                    .Where(x => x.Movie.Title.ToLower().StartsWith(searchText.ToLower()))
                    .GroupBy(x => x.Movie.Id)
                    .Select(x =>
                        new FrontPageMovieDto(
                            x.FirstOrDefault().Movie.Id,
                            x.FirstOrDefault().Movie.Title,
                            x.FirstOrDefault().Movie.Rating.Title,
                            x.FirstOrDefault().Movie.DurationMinutes,
                            x.FirstOrDefault().Movie.PosterUrl))
                    .ToListAsync();

                _logger.LogInformation("Search completed. Found {Count} movies", movies.Count);

                return movies;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while searching movies");
                throw;
            }
        }
    }
}
