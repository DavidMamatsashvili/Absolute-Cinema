using Absolute_Cinema_Backend.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Absolute_Cinema_Backend.Controllers
{
    [Route("api/filters")]
    [ApiController]
    public class Filters : ControllerBase
    {
        private readonly IFilterService _filterService;
        private readonly ILogger<Filters> _logger;
        public Filters(IFilterService filterService, ILogger<Filters> logger)
        {
            _filterService = filterService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilters()
        {
            try
            {
                var result = await _filterService.GetFiltersAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "failed to get filters");
                return StatusCode(500, "server error");
            }
        }
    }
}
