using Absolute_Cinema_Backend.Models;
using System.Linq;

namespace Absolute_Cinema_Backend.Repository.Abstractions
{
    public interface IShowtimeRepository
    {
        IQueryable<Showtime> GetShowtimes();
    }
}
