using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class SeatSelectionSession
{
    public int Id { get; set; }

    public DateTime ReservedAt { get; set; }

    public DateTime ExpiresAt { get; set; }

    public int ShowtimeId { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<SeatReservation> SeatReservations { get; set; } = new List<SeatReservation>();

    public virtual Showtime Showtime { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
