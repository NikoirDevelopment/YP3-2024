create table public.WorkingCalendar
(
    Id            integer not null
        constraint WorkingCalendar_pk
            primary key,
    ExceptionDate date    not null,
    IsWorkingDay  boolean not null
);

comment on table public.WorkingCalendar is 'Список дней исключений в производственном календаре';

comment on column public.WorkingCalendar.ExceptionDate is 'День-исключение';

comment on column public.WorkingCalendar.IsWorkingDay is '0 - будний день, но законодательно принят выходным; 1 - сб или вс, но является рабочим';

insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (1, '2024-01-01', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (2, '2024-01-02', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (3, '2024-01-03', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (4, '2024-01-04', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (5, '2024-01-05', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (6, '2024-01-08', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (7, '2024-02-23', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (8, '2024-03-08', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (9, '2024-04-27', TRUE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (10, '2024-04-29', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (11, '2024-04-30', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (12, '2024-05-01', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (13, '2024-05-09', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (14, '2024-05-10', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (15, '2024-06-12', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (16, '2024-11-02', TRUE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (17, '2024-11-04', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (18, '2024-12-28', TRUE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (19, '2024-12-30', FALSE);
insert into WorkingCalendar (Id, ExceptionDate, IsWorkingDay) values (20, '2024-12-31', FALSE);
