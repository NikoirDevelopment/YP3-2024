using System;
using System.Collections.Generic;

namespace DESKTOP;

public partial class TypeCalendar
{
    public int TypeCalendarId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
