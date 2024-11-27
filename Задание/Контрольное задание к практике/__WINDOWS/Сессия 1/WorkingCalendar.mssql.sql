create table WorkingCalendar
(
    Id            bigint not null
        constraint WorkingCalendar_pk
            primary key,
    ExceptionDate date   not null,
    IsWorkingDay  bit    not null
)
go

exec sp_addextendedproperty 'MS_Description', N'Список дней исключений в производственном календаре', 'SCHEMA', 'dbo',
     'TABLE', 'WorkingCalendar'
go

exec sp_addextendedproperty 'MS_Description', N'Идентификатор строки', 'SCHEMA', 'dbo', 'TABLE', 'WorkingCalendar',
     'COLUMN', 'Id'
go

exec sp_addextendedproperty 'MS_Description', N'День-исключение', 'SCHEMA', 'dbo', 'TABLE', 'WorkingCalendar', 'COLUMN',
     'ExceptionDate'
go

exec sp_addextendedproperty 'MS_Description', N'0 - будний день, но законодательно принят выходным', 'SCHEMA', 'dbo',
     'TABLE', 'WorkingCalendar', 'COLUMN', 'IsWorkingDay'
go

INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (1, N'2024-01-01', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (2, N'2024-01-02', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (3, N'2024-01-03', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (4, N'2024-01-04', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (5, N'2024-01-05', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (6, N'2024-01-08', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (7, N'2024-02-23', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (8, N'2024-03-08', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (9, N'2024-04-27', 1);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (10, N'2024-04-29', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (11, N'2024-04-30', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (12, N'2024-05-01', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (13, N'2024-05-09', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (14, N'2024-05-10', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (15, N'2024-06-12', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (16, N'2024-11-02', 1);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (17, N'2024-11-04', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (18, N'2024-12-28', 1);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (19, N'2024-12-30', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (20, N'2024-12-31', 0);
