using System;
using System.Collections.Generic;

namespace DESKTOP.WinUI;

public partial class Resume
{
    public int ResumeId { get; set; }

    public DateOnly DateCreate { get; set; }

    public byte[] Photo { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
