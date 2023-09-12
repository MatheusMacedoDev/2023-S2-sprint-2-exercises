using System;
using System.Collections.Generic;

namespace webapi.Inlock.Domains;

public partial class UserType
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
