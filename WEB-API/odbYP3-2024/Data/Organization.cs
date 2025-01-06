using System;
using System.Collections.Generic;

namespace odbYP3_2024.Data;

public partial class Organization
{
    public int OrganizationId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
