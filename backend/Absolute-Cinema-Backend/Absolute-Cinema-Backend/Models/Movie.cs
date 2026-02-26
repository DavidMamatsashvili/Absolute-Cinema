using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly ReleaseDate { get; set; }

    public int DurationMinutes { get; set; }

    public string? PosterUrl { get; set; }

    public string? Director { get; set; }

    public int RatingId { get; set; }

    public virtual Rating Rating { get; set; } = null!;

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();

    public virtual ICollection<Actor> Actors { get; set; } = new List<Actor>();

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
