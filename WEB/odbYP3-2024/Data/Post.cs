using System;
using System.Collections.Generic;

namespace odbYP3_2024.Data;

public partial class Post
{
    public int PostId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
