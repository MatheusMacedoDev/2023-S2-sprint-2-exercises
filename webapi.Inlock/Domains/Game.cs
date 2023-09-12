using System;
using System.Collections.Generic;

namespace webapi.Inlock.Domains;

public partial class Game
{
    public Guid Id { get; set; }

    public Guid? StudioId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public decimal Price { get; set; }

    public virtual Studio? Studio { get; set; }
}
