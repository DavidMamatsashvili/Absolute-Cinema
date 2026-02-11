using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class SessionType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}
