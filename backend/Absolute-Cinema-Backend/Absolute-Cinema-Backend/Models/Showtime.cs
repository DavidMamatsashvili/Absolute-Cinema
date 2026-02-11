using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class Showtime
{
    public int Id { get; set; }

    public DateTime StartDateTime { get; set; }

    public decimal MinPrice { get; set; }

    public string Status { get; set; } = null!;

    public int MovieId { get; set; }

    public int HallId { get; set; }

    public int ResolutionId { get; set; }

    public int SessionTypeId { get; set; }

    public int LanguageId { get; set; }

    public int SubtitleId { get; set; }

    public virtual Hall Hall { get; set; } = null!;

    public virtual ICollection<HallZonePrice> HallZonePrices { get; set; } = new List<HallZonePrice>();

    public virtual Language Language { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual Resolution Resolution { get; set; } = null!;

    public virtual ICollection<SeatReservation> SeatReservations { get; set; } = new List<SeatReservation>();

    public virtual ICollection<SeatSelectionSession> SeatSelectionSessions { get; set; } = new List<SeatSelectionSession>();

    public virtual SessionType SessionType { get; set; } = null!;

    public virtual Subtitle Subtitle { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
