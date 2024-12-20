﻿using System;
using System.Collections.Generic;

namespace odbYP3_2024.Data;

public partial class StatusCalendar
{
    public int StatusCalendarId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();
}