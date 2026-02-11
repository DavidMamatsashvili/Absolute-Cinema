using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class Hall
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int RowsCount { get; set; }

    public int ColsCount { get; set; }

    public int TheatreId { get; set; }

    public virtual ICollection<HallZone> HallZones { get; set; } = new List<HallZone>();

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();

    public virtual Theatre Theatre { get; set; } = null!;
}
