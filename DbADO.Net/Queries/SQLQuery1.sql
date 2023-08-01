--INSERT into [dbo].[Status](StatusName)
--VALUES 
--('NotStarted'),
--('Loading'),
--('InProgress'),
--('Arrived'),
--('Unloading'),
--('Cancelled'),
--('Done');

--Insert into [dbo].[Product](Name,Description, Weight, Height, Width, Length)
--Values
--('Sofa','description Sofa', 100, 80, 120, 200),
--('Chair','description Chair', 20, 80, 60, 50),
--('Bed','description Bed', 200, 120, 180, 200),
--('Armchair','description Armchair', 90, 80, 100, 120);

--INSERT into [dbo].[Order](CreatedDate,UpdatedDate,ProductId,StatusId)
--VALUES 
--('20230618 10:34:09 AM', '20230621 11:15:02 AM', 1, 2),
--('20230722 10:10:02 AM', '20230727 11:15:02 AM', 2, 3),
--('20230711 00:08:42 AM', '20230712 11:00:52 AM', 3, 6),
--('20230512 11:52:13 AM', '20230620 11:15:02 AM', 4, 7);


--$"Insert into Product(Name, Description, Weight, Height, Width, Length)" +
--                              $" values(@name, @description, @weight, @height, @width, @length)";


--Insert into Product(Name,Description, Weight, Height, Width, Length)
--Values
--('te','rtrtr', 11, 12, 13, 14);

--var cmdText = $"select Id, Status, CreatedDate, UpdatedDate, ProductId  from Order";

--select * from [dbo].[Order]

--select Id, CreatedDate,UpdatedDate,ProductId, StatusId from [dbo].[Order]
--where ProductId=2

--exec sp_FetchOrdersByProductId @ProductId=2
