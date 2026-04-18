using Absolute_Cinema_Backend.Dto;
using Absolute_Cinema_Backend.Models;
using Absolute_Cinema_Backend.Repository.Abstractions;
using Absolute_Cinema_Backend.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Absolute_Cinema_Backend.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly ILogger<MovieService> _logger;

        public MovieService(IMovieRepository repository, ILogger<MovieService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<MovieDetailsDto?> GetMovieDetailsAsync(int movieid)
        {
            try
            {
                Movie? movie = await _repository.GetMovieById(movieid)
                    .Include(x => x.Actors)
                    .Include(x => x.Genres)
                    .Include(x => x.Rating)
                    .Include(x => x.Showtimes)
                        .ThenInclude(x => x.Hall)
                            .ThenInclude(x => x.HallZones)
                    .Include(x => x.Showtimes)
                        .ThenInclude(x => x.Language)
                    .Include(x => x.Showtimes)
                        .ThenInclude(x => x.Subtitle)
                    .Include(x => x.Showtimes)
                        .ThenInclude(x => x.Resolution)
                    .Include(x => x.Showtimes)
                        .ThenInclude(x => x.SessionType)
                    .FirstOrDefaultAsync();

                if (movie == null)
                {
                    _logger.LogWarning("Movie not found with the movieId: {MovieId}", movieid);
                    return null;
                }

                List<GenreDto> genres = movie.Genres
                    .Select(x => new GenreDto(x.Id, x.Title))
                    .ToList();

                RatingDto? rating = new RatingDto(
                    movie.Rating.Id,
                    movie.Rating.Code,
                    movie.Rating.Title,
                    movie.Rating.MinAge);

                List<ActorDto> actors = movie.Actors
                    .Select(x => new ActorDto(x.Id, x.FullName))
                    .ToList();

                List<ShowtimeDto> showtimes = movie.Showtimes
                    .Select(x => new ShowtimeDto(
                        x.Id,
                        x.StartDateTime,
                        x.MinPrice,
                        x.Status!,
                        x.Hall != null
                            ? new HallDto(
                                x.Hall.Id,
                                x.Hall.Title!,
                                x.Hall.RowsCount,
                                x.Hall.ColsCount,
                                x.Hall.HallZones?
                                    .Select(y => new HallZoneDto(y.Id, y.Title!, y.HallId))
                                    .ToList() ?? new List<HallZoneDto>()
                              )
                            : null!,
                        x.Resolution != null ? new ResolutionDto(x.Resolution.Id, x.Resolution.Title!) : null!,
                        x.SessionType != null ? new SessiontypeDto(x.SessionType.Id, x.SessionType.Title!) : null!,
                        x.Language != null ? new LanguageDto(x.Language.Id, x.Language.Code!, x.Language.Title!) : null!,
                        x.Subtitle != null && x.Subtitle.Language != null
                            ? new SubtitleDto(
                                x.Subtitle.Id,
                                new LanguageDto(
                                    x.Subtitle.Language.Id,
                                    x.Subtitle.Language.Code!,
                                    x.Subtitle.Language.Title!))
                            : null!
                    ))
                    .ToList();

                MovieDetailsDto movieDetails =
                    new MovieDetailsDto(
                        movieid,
                        movie.Title,
                        movie.Description,
                        movie.DurationMinutes,
                        movie.PosterUrl,
                        rating,
                        movie.Director,
                        genres,
                        actors,
                        showtimes);

                _logger.LogInformation("Movie details successfully fetched. MovieId: {MovieId}", movieid);

                return movieDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching movie details. MovieId: {MovieId}", movieid);
                throw;
            }
        }
    }
}
