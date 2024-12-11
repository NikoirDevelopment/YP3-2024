using System;
using System.Collections.Generic;

namespace DESKTOP;

public partial class User
{
    public int UserId { get; set; }

    public int OrganizationId { get; set; }

    public int? DivisionId { get; set; }

    public int? MinDivisionId { get; set; }

    public int PostId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Middlename { get; set; } = null!;

    public DateOnly Date { get; set; }

    public string Phone { get; set; } = null!;

    public int CabinetId { get; set; }

    public string Email { get; set; } = null!;

    public int StatusUserId { get; set; }

    public DateOnly? DateFinish { get; set; }

    public virtual Cabinet Cabinet { get; set; } = null!;

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    public virtual Division? Division { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Division? MinDivision { get; set; }

    public virtual Organization Organization { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;

    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();

    public virtual StatusUser StatusUser { get; set; } = null!;
}
