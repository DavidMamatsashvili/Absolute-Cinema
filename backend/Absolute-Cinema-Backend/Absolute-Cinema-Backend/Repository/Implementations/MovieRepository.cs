using Absolute_Cinema_Backend.Models;
using Absolute_Cinema_Backend.Repository.Abstractions;

namespace Absolute_Cinema_Backend.Repository.Implementations
{
    public class MovieRepository:IMovieRepository
    {
        private readonly AbsoluteCinemaDbContext _context;
        public MovieRepository(AbsoluteCinemaDbContext context)
        {
            _context = context;
        }
        public IQueryable<Movie> GetMovies()
        {
            return _context.Movies;
        }
        public IQueryable<Movie> GetMovieById(int id)
        {
            return _context.Movies.Where(x=>x.Id == id);
        }
        public IQueryable<Movie> GetMovieByTitle(string title)
        {
           return _context.Movies.Where(x=>x.Title == title);
        }
    }
}
