using Absolute_Cinema_Backend.Models;
using Absolute_Cinema_Backend.Repository.Abstractions;

namespace Absolute_Cinema_Backend.Repository.Implementations
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AbsoluteCinemaDbContext _context;
        public GenreRepository(AbsoluteCinemaDbContext context) 
        { 
            _context = context;
        }
        public IQueryable<Genre> GetGenres()
        {
            return _context.Genres;
        }
    }
}
