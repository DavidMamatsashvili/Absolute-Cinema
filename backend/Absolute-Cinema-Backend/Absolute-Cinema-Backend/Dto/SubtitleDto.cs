namespace Absolute_Cinema_Backend.Dto
{
    public class SubtitleDto
    {
        public int Id { get; set; }
        public LanguageDto Language { get; set; } = null!;
        public SubtitleDto() { }
        public SubtitleDto(int id, LanguageDto language)
        {
            Id = id;
            Language = language;
        }
    }
}
