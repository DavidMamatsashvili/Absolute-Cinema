using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class Actor
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
