using System;
using System.Collections.Generic;

namespace labb04_KPZ.Models;

public partial class Achievement
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Describtion { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
