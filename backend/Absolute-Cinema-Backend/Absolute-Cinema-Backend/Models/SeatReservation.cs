using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class SeatReservation
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public decimal? Price { get; set; }

    public int SeatId { get; set; }

    public int ShowtimeId { get; set; }

    public int SeatSelectionSessionId { get; set; }

    public virtual Seat Seat { get; set; } = null!;

    public virtual SeatSelectionSession SeatSelectionSession { get; set; } = null!;

    public virtual Showtime Showtime { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
