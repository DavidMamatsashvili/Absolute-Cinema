using System.Threading.Tasks;
using Absolute_Cinema_Backend.Dto;
using Absolute_Cinema_Backend.Services.Abstractions;
using Absolute_Cinema_Backend.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Absolute_Cinema_Backend.Controllers
{
    [Route("api/showtimes")]
    [ApiController]
    public class Showtime : ControllerBase
    {
        private readonly IShowtimeService _showtimeService;
        private readonly IMovieService _movieService;
        private readonly ILogger<Showtime> _logger;
        public Showtime(ShowtimeService showtimeService, IMovieService movieSevice, ILogger<Showtime> logger)
        {
            _showtimeService = showtimeService;
            _movieService = movieSevice;
            _logger = logger;
        }

        [HttpGet("movies")]
        public async Task<IActionResult> GetMovies([FromQuery]QueryDto query)
        {
            try
            {
                var result = await _showtimeService.GetShowtimesJoinedWithMoviesAsync(query);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting movies");
                return StatusCode(500, "server error");
            }
        }

        [HttpGet("movies/{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            try
            {
                var result = await _movieService.GetMovieDetailsAsync(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting movie");
                return StatusCode(500, "server error");
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchMovieByTitle([FromQuery(Name = "query")]string query)
        {
            try
            {
                var result = await _showtimeService.SearchMoviesByTitle(query);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while searching movies with query: {Query}", query);
                return StatusCode(500, "server error");
            }
        }
    }
}
