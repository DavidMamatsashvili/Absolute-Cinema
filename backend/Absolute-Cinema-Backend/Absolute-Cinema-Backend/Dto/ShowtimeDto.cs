namespace Absolute_Cinema_Backend.Dto
{
    public class ShowtimeDto
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public decimal MinPrice { get; set; }
        public string Status { get; set; }
        public HallDto Hall { get; set; }
        public ResolutionDto Resolution { get; set; }
        public SessiontypeDto SessionType { get; set; }
        public LanguageDto Language { get; set; }
        public SubtitleDto Subtitle { get; set; }
        public ShowtimeDto() { }
        public ShowtimeDto(
            int id,
            DateTime startDateTime,
            decimal minPrice,
            string status,
            HallDto hall,
            ResolutionDto resolution,
            SessiontypeDto sessionType,
            LanguageDto language,
            SubtitleDto subtitle)
        {
            Id = id;
            StartDateTime = startDateTime;
            MinPrice = minPrice;
            Status = status;
            Hall = hall;
            Resolution = resolution;
            SessionType = sessionType;
            Language = language;
            Subtitle = subtitle;
        }
    }
}
