using System;
using System.Collections.Generic;

namespace webapi.Inlock.Domains;

public partial class User
{
    public Guid Id { get; set; }

    public Guid? UserTypeId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual UserType? UserType { get; set; }
}
