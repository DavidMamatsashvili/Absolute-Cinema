using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class Subtitle
{
    public int Id { get; set; }

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; } = null!;

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}
