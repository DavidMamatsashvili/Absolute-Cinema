using Absolute_Cinema_Backend.Controllers;
using Absolute_Cinema_Backend.Models;

namespace Absolute_Cinema_Backend.Dto
{
    public class MovieDetailsDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public string? PosterUrl { get; set; }
        public RatingDto Rating { get; set; }
        public string? Director { get; set; }
        public List<GenreDto> Genres { get; set; }
        public List<ActorDto> Actors { get; set; }
        public List<ShowtimeDto> Showtimes { get; set; }
        public MovieDetailsDto() { }
        public MovieDetailsDto(int id, string? title, string? description, int duration, string? posterUrl, RatingDto rating, string? director, List<GenreDto> genres, List<ActorDto> actors, List<ShowtimeDto> showtimes)
        {
            Id = id;
            Title = title;
            Description = description;
            Duration = duration;
            PosterUrl = posterUrl;
            Rating = rating;
            Director = director;
            Genres = genres;
            Actors = actors;
            Showtimes = showtimes;
        }
    }
}
