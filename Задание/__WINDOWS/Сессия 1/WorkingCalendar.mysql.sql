CREATE TABLE WorkingCalendar
(
    Id            INT COMMENT 'Идентификатор строки' PRIMARY KEY,
    ExceptionDate DATE       NOT NULL COMMENT 'День-исключение',
    IsWorkingDay  TINYINT(1) NOT NULL COMMENT '0 - будний день, но законодательно принят выходным; 1 - сб или вс, но является рабочим'
)
    COMMENT 'Список дней исключений в производственном календаре';

INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (1, '2024-01-01', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (2, '2024-01-02', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (3, '2024-01-03', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (4, '2024-01-04', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (5, '2024-01-05', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (6, '2024-01-08', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (7, '2024-02-23', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (8, '2024-03-08', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (9, '2024-04-27', 1);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (10, '2024-04-29', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (11, '2024-04-30', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (12, '2024-05-01', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (13, '2024-05-09', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (14, '2024-05-10', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (15, '2024-06-12', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (16, '2024-11-02', 1);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (17, '2024-11-04', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (18, '2024-12-28', 1);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (19, '2024-12-30', 0);
INSERT INTO WorkingCalendar (Id, ExceptionDate, IsWorkingDay) VALUES (20, '2024-12-31', 0);
