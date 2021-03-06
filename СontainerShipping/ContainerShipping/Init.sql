﻿insert into dbo.[Client] ([Name], [Company], [Address], [Phone], [Fax], [Email]) values 
(N'Иванов', N'Вектор', N'Невский', '1234567', '1234567', '1234567@.'),
(N'Петрова',	'IBM',	N'Садовая,21', '2345678', '2345678', '2345678@.'),
(N'Сидоров',	'IBM', '', '3456789', '3456789', '3456789@.'),
(N'Алексеев', 'Company',	N'Гороховая,2', '4567890', '4567890', '4567890@.'),
(N'Иванова', 'Company',	'', '', '', '')

GO

insert into dbo.[Booking] ([Date], [Name], [Weight], [Volume], [Cost], [IdClient]) values 
('2005-07-01 12:34:00', 'Booking', '12', '123', '1', '1'),
('2010-02-12 10:35:00', 'Smth', '234', '234', '2', '2'),
('2007-01-01 12:33:00', 'Cookies', '1523', '345', '3', '2'),
('2000-04-04 08:35:00', 'Windows', '456', '456', '4', '3'),
('2003-01-02 19:35:00', 'Bananas', '324', '43', '435', '4')

GO

insert into dbo.[Container] ([Type], [Weight], [Volume]) values 
('Tank', '12', '1'),
('Tank', '234', '2'),
('Open', '76', '3'),
('Open', '4', '4'),
('DC', '324', '435'),
('DC', '324', '435'),
('Empty', '23', '23'),
('Empty', '77', '73')

GO

insert into dbo.[Ship] ([Name], [OutputPort], [InputPort], [OutputTime], [InputTime]) values 
(N'Титаник', N'Квинстаун', N'Нью Йорк', '2012-03-03 12:34:00', '2013-03-03 12:34:00'),
(N'Британник', N'Одесса', N'Пермь', '2014-02-12 10:35:00', '2015-02-12 10:35:00'),
(N'Беда', N'Санкт-Петербург', N'Мурманск', '2008-01-01 12:33:00', '2009-01-01 12:33:00'),
('Ship', N'А', N'Б', '2005-01-02 19:35:00', '2005-01-02 19:35:00'),
('Planet Express', N'Севастополь', N'Владивосток', '3001-04-02 10:35:00.000', '3001-04-02 10:36:00.000')

GO

insert into dbo.[DownloadContainer] ([Weight], [IdContainer], [IdBooking], [IdShip]) values 
('24', '1', '1', '1'),
('468', '2', '2', '1'),
('76', '3', '2', '2'),
('1527', '4', '3', '3'),
('780', '5', '4', '4'),
('648', '6', '5', '5'),
('23', '7', '1', '1')
