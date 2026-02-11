using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class HallZonePrice
{
    public int ShowtimeId { get; set; }

    public int HallZoneId { get; set; }

    public decimal Price { get; set; }

    public virtual HallZone HallZone { get; set; } = null!;

    public virtual Showtime Showtime { get; set; } = null!;
}
