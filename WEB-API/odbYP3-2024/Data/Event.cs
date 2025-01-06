using System;
using System.Collections.Generic;

namespace odbYP3_2024.Data;

public partial class Event
{
    public int EventId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateOnly? DateTimeStart { get; set; }

    public DateOnly? DateTimeEnd { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
