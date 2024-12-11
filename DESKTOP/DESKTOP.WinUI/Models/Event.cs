using System;
using System.Collections.Generic;

namespace DESKTOP.WinUI.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string? Description { get; set; }

    public int? TypeCalendarId { get; set; }

    public int? UserId { get; set; }

    public virtual TypeCalendar? TypeCalendar { get; set; }

    public virtual User? User { get; set; }
}
