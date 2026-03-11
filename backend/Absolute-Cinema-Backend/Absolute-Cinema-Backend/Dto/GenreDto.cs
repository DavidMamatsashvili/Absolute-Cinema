using Microsoft.Extensions.Primitives;

namespace Absolute_Cinema_Backend.Dto
{
    public class GenreDto 
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public GenreDto() { }
        public GenreDto(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
