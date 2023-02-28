CREATE TABLE main(
ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
SURNAME nvarchar(50) NOT NULL,
NAME nvarchar(50) NOT NULL,
MIDDLENAME nvarchar(50) NOT NULL,
NAMEORGANIZATION nvarchar(50) NOT NULL,
PHONENUMBER nvarchar(50) NOT NULL,
EDUPROGRAM nvarchar(50) NOT NULL,
EDUDATE nvarchar(50) NOT NULL,
EXPCERTIFICATE nvarchar(50) NOT NULL,
logs nvarchar(50) NOT NULL
)


CREATE TABLE Users(
UID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Login nvarchar(50) NOT NULL,
Password nvarchar(50) NOT NULL,
User_Role nvarchar(50) NOT NULL
)

insert into Users(Login, Password, User_Role)
values
('def','def','Участник'),
('edit','edit','Редактор')


CREATE TABLE DayWeekAdded(
DayWeek nvarchar(16),
AddedCount nvarchar(50) NOT NULL
)

insert into DayWeekAdded(DayWeek, AddedCount)
values
('Понедельник','0'),
('Вторник','0'),
('Среда','0'),
('Четверг','0'),
('Пятница','0'),
('Суббота','0'),
('Воскресенье','0')

CREATE TABLE AutoCheckDay(
AlreadyChecked nvarchar(12) NOT NULL
)

insert into AutoCheckDay(AlreadyChecked)
values
('Да')