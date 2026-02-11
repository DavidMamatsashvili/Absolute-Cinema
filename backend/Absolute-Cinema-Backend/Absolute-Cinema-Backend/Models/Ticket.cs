using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public decimal PriceAtPurchase { get; set; }

    public int SeatReservationId { get; set; }

    public int ShowtimeId { get; set; }

    public int UserId { get; set; }

    public virtual SeatReservation SeatReservation { get; set; } = null!;

    public virtual Showtime Showtime { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
