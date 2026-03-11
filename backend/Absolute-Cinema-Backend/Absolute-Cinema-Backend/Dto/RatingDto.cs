namespace Absolute_Cinema_Backend.Dto
{
    public class RatingDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string? Title { get; set; }
        public int? MinAge { get; set; }
        public RatingDto() { }
        public RatingDto(int id, string code, string? title, int? minAge)
        {
            Id = id;
            Code = code;
            Title = title;
            MinAge = minAge;
        }
    }
}
