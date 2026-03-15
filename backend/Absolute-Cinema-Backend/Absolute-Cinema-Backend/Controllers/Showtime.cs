using System.Threading.Tasks;
using Absolute_Cinema_Backend.Dto;
using Absolute_Cinema_Backend.Services.Abstractions;
using Absolute_Cinema_Backend.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Absolute_Cinema_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Showtime : ControllerBase
    {
        private readonly IShowtimeService _showtimeService;
        private readonly IMovieService _movieService;
        public Showtime(ShowtimeService showtimeService, IMovieService movieSevice)
        {
            _showtimeService = showtimeService;
            _movieService = movieSevice;
        }

        [HttpGet("movies")]
        public async Task<IActionResult> GetMovies([FromQuery]QueryDto query)
        {
            var result = await _showtimeService.GetShowtimesJoinedWithMoviesAsync(query);
            if(result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("movies/{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var result = await _movieService.GetMovieDetailsAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchMovieByTitle([FromQuery(Name = "query")]string query)
        {
            var result = await _showtimeService.SearchMoviesByTitle(query);
            if(result == null) return NotFound();
            return Ok(result);
        }
    }
}
