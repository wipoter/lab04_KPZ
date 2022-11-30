using System;
using System.Collections.Generic;

namespace labb04_KPZ.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public int? Age { get; set; }

    public string? Institute { get; set; }

    public string? Group { get; set; }

    public int? Num { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<Achievement> Achievements { get; } = new List<Achievement>();
}
