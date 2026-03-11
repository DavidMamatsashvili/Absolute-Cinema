using Absolute_Cinema_Backend.Models;

namespace Absolute_Cinema_Backend.Dto
{
    public class FiltersDto
    {
        public List<GenreDto>? Genres { get; set; }
        public List<LanguageDto>? Languages { get; set; }
        public List<SubtitleDto>? Subtitles { get; set; }
        public List<ResolutionDto>? Resolutions { get; set; }
        public List<SessiontypeDto>? SessionTypes { get; set; }
        public List<TheatreDto>? Theatres { get; set; }
        public FiltersDto() { }
        public FiltersDto(List<GenreDto>? genres, List<LanguageDto>? languages, List<SubtitleDto>? subtitles, List<ResolutionDto>? resolutions, List<SessiontypeDto>? sessionTypes, List<TheatreDto>? theatres)
        {
            Genres = genres;
            Languages = languages;
            Subtitles = subtitles;
            Resolutions = resolutions;
            SessionTypes = sessionTypes;
            Theatres = theatres;
        }
    }
}
