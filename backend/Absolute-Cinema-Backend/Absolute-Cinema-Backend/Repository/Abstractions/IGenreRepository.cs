using Absolute_Cinema_Backend.Models;

namespace Absolute_Cinema_Backend.Repository.Abstractions
{
    public interface IGenreRepository
    {
        IQueryable<Genre> GetGenres();
    }
}
