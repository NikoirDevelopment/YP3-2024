using System;
using System.Collections.Generic;

namespace DESKTOP.WinUI.Models;

public partial class StatusUser
{
    public int StatusUserId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
