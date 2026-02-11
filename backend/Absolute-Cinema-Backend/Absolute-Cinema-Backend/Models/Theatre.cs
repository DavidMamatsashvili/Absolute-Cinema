using System;
using System.Collections.Generic;

namespace Absolute_Cinema_Backend.Models;

public partial class Theatre
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string LogoUrl { get; set; } = null!;

    public string? City { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Hall> Halls { get; set; } = new List<Hall>();
}
