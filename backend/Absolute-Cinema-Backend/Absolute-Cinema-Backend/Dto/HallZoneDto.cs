namespace Absolute_Cinema_Backend.Dto
{
    public class HallZoneDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int HallId { get; set; }
        public HallZoneDto() { }
        public HallZoneDto(int id, string title, int hallid)
        {
            Id = id;
            Title = title;
            HallId = hallid;
        }
    }
}
