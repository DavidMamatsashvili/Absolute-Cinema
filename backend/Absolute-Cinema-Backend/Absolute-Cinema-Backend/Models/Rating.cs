using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class Rating
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? Title { get; set; }

    public int? MinAge { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
