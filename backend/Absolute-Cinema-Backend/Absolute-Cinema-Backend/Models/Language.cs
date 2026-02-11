using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class Language
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Title { get; set; } = null!;

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();

    public virtual ICollection<Subtitle> Subtitles { get; set; } = new List<Subtitle>();
}
