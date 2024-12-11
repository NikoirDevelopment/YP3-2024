using System;
using System.Collections.Generic;

namespace DESKTOP;

public partial class Cabinet
{
    public int CabinetId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
