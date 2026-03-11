namespace Absolute_Cinema_Backend.Dto
{
    public class ActorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public ActorDto() { }
        public ActorDto(int id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
    }
}
