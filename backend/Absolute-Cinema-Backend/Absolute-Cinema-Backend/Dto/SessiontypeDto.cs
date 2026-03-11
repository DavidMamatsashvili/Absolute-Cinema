namespace Absolute_Cinema_Backend.Dto
{
    public class SessiontypeDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public SessiontypeDto() { }
        public SessiontypeDto(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
