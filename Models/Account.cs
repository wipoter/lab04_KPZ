using System;
using System.Collections.Generic;

namespace labb04_KPZ.Models;

public partial class Account
{
    public int Id { get; set; }

    public string? Loggin { get; set; }

    public string? Password { get; set; }

    public virtual Student? Student { get; set; }
}
