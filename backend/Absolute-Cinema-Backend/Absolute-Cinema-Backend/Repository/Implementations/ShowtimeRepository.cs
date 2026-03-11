using Absolute_Cinema_Backend.Models;
using Absolute_Cinema_Backend.Repository.Abstractions;

namespace Absolute_Cinema_Backend.Repository.Implementations
{
    public class ShowtimeRepository:IShowtimeRepository
    {
        private readonly AbsoluteCinemaDbContext _context;
        public ShowtimeRepository(AbsoluteCinemaDbContext context) 
        {
            _context = context;
        }
        public IQueryable<Showtime> GetShowtimes()
        {
            return _context.Showtimes;
        }
    }
}
