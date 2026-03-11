namespace Absolute_Cinema_Backend.Dto
{
    public class HallDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int RowsCount { get; set; }
        public int ColsCount { get; set; }
        public List<HallZoneDto>? Zones { get; set; }
        public HallDto() { }
        public HallDto(int id, string title, int rowsCount, int colsCount, List<HallZoneDto> zones)
        {
            Id = id;
            Title = title;
            RowsCount = rowsCount;
            ColsCount = colsCount;
            Zones = zones;
        }
    }
}
