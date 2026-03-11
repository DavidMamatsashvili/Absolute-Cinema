using Absolute_Cinema_Backend.Models;
using Absolute_Cinema_Backend.Repository.Abstractions;

namespace Absolute_Cinema_Backend.Repository.Implementations
{
    public class FilterRepository:IFilterRepository
    {
        private readonly AbsoluteCinemaDbContext _context;
        public FilterRepository(AbsoluteCinemaDbContext context)
        {
            _context = context;
        }
        public IQueryable<Genre> GetGenres()
        {
            return _context.Genres;
        }
        public IQueryable<Language> GetLanguages()
        {
            return _context.Languages;
        }
        public IQueryable<Subtitle> GetSubtitles()
        {
            return _context.Subtitles;
        }
        public IQueryable<Resolution> GetResolutions()
        {
            return _context.Resolutions;
        }
        public IQueryable<SessionType> GetSessionTypes()
        {
            return _context.SessionTypes;
        }
        public IQueryable<Theatre> GetTheatres()
        {
            return _context.Theatres;
        }
    }
}
