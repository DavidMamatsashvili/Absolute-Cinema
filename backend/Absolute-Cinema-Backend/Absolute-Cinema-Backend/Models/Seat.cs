using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class Seat
{
    public int Id { get; set; }

    public int SRowNumber { get; set; }

    public int SeatNumber { get; set; }

    public int HallZoneId { get; set; }

    public virtual HallZone HallZone { get; set; } = null!;

    public virtual ICollection<SeatReservation> SeatReservations { get; set; } = new List<SeatReservation>();
}
