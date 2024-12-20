using System;
using System.Collections.Generic;

namespace odbYP3_2024.Data;

public partial class Division
{
    public int DivisionId { get; set; }

    public int? OrganizationId { get; set; }

    public string Title { get; set; } = null!;

    public virtual Organization? Organization { get; set; }

    public virtual ICollection<User> UserDivisions { get; set; } = new List<User>();

    public virtual ICollection<User> UserMinDivisions { get; set; } = new List<User>();
}
