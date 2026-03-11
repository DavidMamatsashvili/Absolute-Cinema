using Absolute_Cinema_Backend.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Absolute_Cinema_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Filters : ControllerBase
    {
        private readonly IFilterService _filterService;
        public Filters(IFilterService filterService)
        {
            _filterService = filterService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetFilters()
        {
            var result = await _filterService.GetFiltersAsync();
            return Ok(result);
        }
    }
}
