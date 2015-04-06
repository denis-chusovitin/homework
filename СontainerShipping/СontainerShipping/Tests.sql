--1. Выбрать всю информацию обо всех кораблях.

select [Name], [OutputPort], [InputPort], [OutputTime], [InputTime] from [Ship] 

--2. Выбрать контактных лиц фирмы “IBM”.

select [Name] from [Client] where [Company] = 'IBM'

--3. Выбрать номера контейнеров, у которых вес пустого контейнера меньше 300 и упорядочить их по этому весу.

select d.Id from [DownloadContainer] d, [Container] c 
	where c.Weight < 300.0 and c.Id = d.IdContainer order by c.Weight

--4. Выбрать номера заказов с общим весом груза больше 100 и номера контейнеров, у которых  номер корабля, на котором 
-- они будут отправлены, содержит цифру 5. Список упорядочить по номеру заказа.

select b.Id, d.Id from [Booking] b, [DownloadContainer] d
	where charindex('5', d.IdShip) > 0 and d.IdBooking = b.Id and b.Weight > 100 order by b.Id

--5. Выдать время заказа перевозки груза, имена кораблей и дату их отправления, для которых время заказа с 10:10 до 20:00 1 июля 2005 года.

select b.Id, s.Name, s.OutputTime from [Booking] b, [Ship] s, [DownloadContainer] d
	where b.Date >= '2005-07-01 10:10:00' and b.Date <= '2005-07-01 20:00:00'
		and b.Id = d.IdBooking and d.IdShip = s.Id
		


--1. Посчитать общий вес всех пустых контейнеров в первой группе контейнеров.

select sum(c.Weight) from [Container] c, [DownloadContainer] d
	where d.Weight = c.Weight and d.IdBooking = 1

--2. Получить список фирм, отсортированный по количеству контактных лиц, для которых оно является представителем.

select t.Company from
(select [Company], COUNT(*) AS "Agents" from [Client] 
	GROUP BY [Company]) t order by t.[Agents]
	
--3. Выбрать постоянных клиентов корабля Титаник (не менее 2 заказов)

--select c.Client from [Client] c, [Booking] b, [DownloadContainer] d
select t.Id from
(select c.Id, COUNT(*) AS "Number of booking" from [DownloadContainer] d, [Ship] s, [Booking] b, [Client] c
	where d.IdShip = s.Id and s.Name = N'Титаник' and d.IdBooking = b.Id and c.Id = b.IdClient
		GROUP BY c.Id) t 
			where t.[Number of booking] >= 2
	

	
--1. Удалить контакное лицо - Иванова.
delete [Client] where [Name] = N'Иванова'

--2. Удалить все заказы, связанные с Титаником.
delete b from [DownloadContainer] d, [Ship] s, [Booking] b
	where s.Name = N'Титаник' and d.IdShip = s.Id and d.IdBooking = b.Id
 
--3. Заменить порт приписки кораблей Севастополь на Одессу
update [Ship] set [OutputPort] = N'Одесса' where [OutputPort] = N'Севастополь'