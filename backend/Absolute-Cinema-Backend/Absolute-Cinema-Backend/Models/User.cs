using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class User
{
    public int Id { get; set; }

    public virtual ICollection<SeatSelectionSession> SeatSelectionSessions { get; set; } = new List<SeatSelectionSession>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
