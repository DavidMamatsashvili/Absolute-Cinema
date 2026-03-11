namespace Absolute_Cinema_Backend.Dto
{
    public class LanguageDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
        public LanguageDto() { }
        public LanguageDto(int id, string code, string title)
        {
            Id = id;
            Code = code;
            Title = title;
        }
    }
}
