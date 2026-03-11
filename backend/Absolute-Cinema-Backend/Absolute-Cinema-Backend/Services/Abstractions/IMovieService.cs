using Absolute_Cinema_Backend.Dto;

namespace Absolute_Cinema_Backend.Services.Abstractions
{
    public interface IMovieService
    {
        Task<MovieDetailsDto>GetMovieDetailsAsync(int movieid);
    }
}
