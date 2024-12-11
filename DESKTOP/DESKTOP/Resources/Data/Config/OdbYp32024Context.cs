using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DESKTOP;

public partial class OdbYp32024Context : DbContext
{
    public OdbYp32024Context()
    {
    }

    public OdbYp32024Context(DbContextOptions<OdbYp32024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<Calendar> Calendars { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Resume> Resumes { get; set; }

    public virtual DbSet<StatusCalendar> StatusCalendars { get; set; }

    public virtual DbSet<StatusUser> StatusUsers { get; set; }

    public virtual DbSet<TypeCalendar> TypeCalendars { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Database=OdbYP3-2024;Username=postgres;Password=root;Port=5432");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cabinet>(entity =>
        {
            entity.HasKey(e => e.CabinetId).HasName("Cabinet_pkey");

            entity.ToTable("Cabinet");

            entity.Property(e => e.CabinetId).HasColumnName("CabinetID");
            entity.Property(e => e.Title).HasMaxLength(20);
        });

        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.HasKey(e => e.CalendarId).HasName("Calendar_pkey");

            entity.ToTable("Calendar");

            entity.Property(e => e.CalendarId).HasColumnName("CalendarID");
            entity.Property(e => e.DateTimeEnd).HasColumnName("DateTime_End");
            entity.Property(e => e.DateTimeStart).HasColumnName("DateTime_Start");
            entity.Property(e => e.StatusCalendarId).HasColumnName("StatusCalendarID");
            entity.Property(e => e.TypeCalendarId).HasColumnName("TypeCalendarID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.StatusCalendar).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.StatusCalendarId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Calendar_StatusCalendarID_fkey");

            entity.HasOne(d => d.TypeCalendar).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.TypeCalendarId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Calendar_TypeCalendarID_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Calendar_UserID_fkey");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.DivisionId).HasName("Divisions_pkey");

            entity.ToTable("Division");

            entity.Property(e => e.DivisionId)
                .HasDefaultValueSql("nextval('\"Divisions_DivisionsID_seq\"'::regclass)")
                .HasColumnName("DivisionID");
            entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Organization).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("Divisions_OrganizationID_fkey");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("Event_pkey");

            entity.ToTable("Event");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.TypeCalendarId).HasColumnName("TypeCalendarID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.TypeCalendar).WithMany(p => p.Events)
                .HasForeignKey(d => d.TypeCalendarId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Event_TypeCalendarID_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Events)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Event_UserID_fkey");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.OrganizationId).HasName("Organization_pkey");

            entity.ToTable("Organization");

            entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("Post_pkey");

            entity.ToTable("Post");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.HasKey(e => e.ResumeId).HasName("Resume_pkey");

            entity.ToTable("Resume");

            entity.Property(e => e.ResumeId).HasColumnName("ResumeID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Resumes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Resume_UserID_fkey");
        });

        modelBuilder.Entity<StatusCalendar>(entity =>
        {
            entity.HasKey(e => e.StatusCalendarId).HasName("StatusCalendar_pkey");

            entity.ToTable("StatusCalendar");

            entity.Property(e => e.StatusCalendarId).HasColumnName("StatusCalendarID");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<StatusUser>(entity =>
        {
            entity.HasKey(e => e.StatusUserId).HasName("StatusUser_pkey");

            entity.ToTable("StatusUser");

            entity.Property(e => e.StatusUserId).HasColumnName("StatusUserID");
            entity.Property(e => e.Title).HasMaxLength(15);
        });

        modelBuilder.Entity<TypeCalendar>(entity =>
        {
            entity.HasKey(e => e.TypeCalendarId).HasName("TypeCalendar_pkey");

            entity.ToTable("TypeCalendar");

            entity.Property(e => e.TypeCalendarId).HasColumnName("TypeCalendarID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("User_pkey");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CabinetId).HasColumnName("CabinetID");
            entity.Property(e => e.DivisionId).HasColumnName("DivisionID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Middlename).HasMaxLength(50);
            entity.Property(e => e.MinDivisionId).HasColumnName("MinDivisionID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.StatusUserId).HasColumnName("StatusUserID");
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.Cabinet).WithMany(p => p.Users)
                .HasForeignKey(d => d.CabinetId)
                .HasConstraintName("User_CabinetID_fkey");

            entity.HasOne(d => d.Division).WithMany(p => p.UserDivisions)
                .HasForeignKey(d => d.DivisionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("User_DivisionsID_fkey");

            entity.HasOne(d => d.MinDivision).WithMany(p => p.UserMinDivisions)
                .HasForeignKey(d => d.MinDivisionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("User_MinDivisionsID_fkey");

            entity.HasOne(d => d.Organization).WithMany(p => p.Users)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("User_OrganizationID_fkey");

            entity.HasOne(d => d.Post).WithMany(p => p.Users)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("User_PostID_fkey");

            entity.HasOne(d => d.StatusUser).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusUserId)
                .HasConstraintName("User_StatusUserID_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
