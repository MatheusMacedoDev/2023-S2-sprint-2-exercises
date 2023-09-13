using System;
using System.Collections.Generic;

namespace webapi.Inlock.Domains;

public partial class Studio
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
