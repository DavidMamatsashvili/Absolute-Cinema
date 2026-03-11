using System.Linq;
using Absolute_Cinema_Backend.Models;

namespace Absolute_Cinema_Backend.Repository.Abstractions
{
    public interface IMovieRepository
    {
        IQueryable<Movie> GetMovies();
        IQueryable<Movie> GetMovieById(int id);
        IQueryable<Movie> GetMovieByTitle(string title);
    }
}
