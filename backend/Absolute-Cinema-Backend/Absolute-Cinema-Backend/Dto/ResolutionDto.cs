namespace Absolute_Cinema_Backend.Dto
{
    public class ResolutionDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public ResolutionDto() { }
        public ResolutionDto(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
