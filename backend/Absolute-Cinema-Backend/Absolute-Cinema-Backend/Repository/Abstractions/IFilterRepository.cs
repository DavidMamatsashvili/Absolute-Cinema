using Absolute_Cinema_Backend.Models;

namespace Absolute_Cinema_Backend.Repository.Abstractions
{
    public interface IFilterRepository
    {
        IQueryable<Genre> GetGenres();
        IQueryable<Language> GetLanguages();
        IQueryable<Subtitle> GetSubtitles();
        IQueryable<Resolution> GetResolutions();
        IQueryable<SessionType> GetSessionTypes();
        IQueryable<Theatre> GetTheatres();
    }
}
