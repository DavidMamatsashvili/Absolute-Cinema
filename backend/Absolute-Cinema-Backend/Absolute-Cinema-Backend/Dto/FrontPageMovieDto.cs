namespace Absolute_Cinema_Backend.Dto
{
    public class FrontPageMovieDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Rating { get; set; }
        public int DurationMinutes { get; set; }
        public string? PosterUrl { get; set; }
        public FrontPageMovieDto() { }
        public FrontPageMovieDto(int id, string title, string rating, int durationminutes, string posterurl) 
        {
            Id = id;
            Title = title;
            Rating = rating;
            DurationMinutes = durationminutes;
            PosterUrl = posterurl;
        }
    }
}
