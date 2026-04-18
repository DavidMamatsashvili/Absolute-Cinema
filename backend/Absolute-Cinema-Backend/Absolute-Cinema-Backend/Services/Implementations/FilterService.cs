using Absolute_Cinema_Backend.Dto;
using Absolute_Cinema_Backend.Models;
using Absolute_Cinema_Backend.Repository.Abstractions;
using Absolute_Cinema_Backend.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Absolute_Cinema_Backend.Services.Implementations
{
    public class FilterService : IFilterService
    {
        private readonly IFilterRepository _filterRepository;
        private readonly ILogger<FilterService> _logger;

        public FilterService(IFilterRepository filterRepository, ILogger<FilterService> logger)
        {
            _filterRepository = filterRepository;
            _logger = logger;
        }

        public async Task<FiltersDto> GetFiltersAsync()
        {
            try
            {
                List<GenreDto> genres = await _filterRepository.GetGenres()
                    .Select(x => new GenreDto(x.Id, x.Title))
                    .ToListAsync();

                List<LanguageDto> languages = await _filterRepository.GetLanguages()
                    .Select(x => new LanguageDto(x.Id, x.Code, x.Title))
                    .ToListAsync();

                var subtitlesRawData = await _filterRepository.GetSubtitles()
                    .Select(s => new
                    {
                        SubtitleId = s.Id,
                        LanguageId = s.Language.Id,
                        LanguageCode = s.Language.Code,
                        LanguageTitle = s.Language.Title
                    })
                    .ToListAsync();

                List<SubtitleDto> subtitles = subtitlesRawData
                    .GroupBy(x => x.LanguageId)
                    .Select(g => g.First())
                    .Select(x => new SubtitleDto(
                        x.SubtitleId,
                        new LanguageDto(x.LanguageId, x.LanguageCode, x.LanguageTitle)
                    ))
                    .ToList();

                List<ResolutionDto> resolutions = await _filterRepository.GetResolutions()
                    .Select(x => new ResolutionDto(x.Id, x.Title))
                    .ToListAsync();

                List<SessiontypeDto> sessions = await _filterRepository.GetSessionTypes()
                    .Select(x => new SessiontypeDto(x.Id, x.Title))
                    .ToListAsync();

                List<TheatreDto> theatres = await _filterRepository.GetTheatres()
                    .Select(x => new TheatreDto(x.Id, x.Title, x.LogoUrl, x.City, x.Address))
                    .ToListAsync();

                _logger.LogInformation(
                    "Filters fetched successfully: Genres={GenreCount}, Languages={LanguageCount}, Theatres={TheatreCount}",
                    genres.Count,
                    languages.Count,
                    theatres.Count
                );

                return new FiltersDto(genres, languages, subtitles, resolutions, sessions, theatres);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching filters");
                throw;
            }
        }
    }
}
