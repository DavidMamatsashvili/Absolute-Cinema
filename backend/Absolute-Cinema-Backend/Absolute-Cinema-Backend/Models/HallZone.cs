using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class HallZone
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int HallId { get; set; }

    public virtual Hall Hall { get; set; } = null!;

    public virtual ICollection<HallZonePrice> HallZonePrices { get; set; } = new List<HallZonePrice>();

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
