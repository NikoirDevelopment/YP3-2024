using System;
using System.Collections.Generic;

namespace DESKTOP.WinUI;

public partial class Calendar
{
    public int CalendarId { get; set; }

    public DateOnly DateTimeStart { get; set; }

    public DateOnly DateTimeEnd { get; set; }

    public int? StatusCalendarId { get; set; }

    public int? TypeCalendarId { get; set; }

    public int? UserId { get; set; }

    public string? Description { get; set; }

    public virtual StatusCalendar? StatusCalendar { get; set; }

    public virtual TypeCalendar? TypeCalendar { get; set; }

    public virtual User? User { get; set; }
}
