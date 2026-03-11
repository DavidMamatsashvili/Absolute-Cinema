namespace Absolute_Cinema_Backend.Dto
{
    public class TheatreDto
    {
        public int Id { get; set; }
        public string? Title { get; set; } = null!;
        public string? LogoUrl { get; set; } = null!;
        public string? City { get; set; }
        public string? Address { get; set; }
        public TheatreDto(){}
        public TheatreDto(int id, string title, string logorul,string city, string address)
        {
            Id = id; 
            Title = title; 
            LogoUrl = logorul; 
            City = city; 
            Address = address;
        }
    }
}
