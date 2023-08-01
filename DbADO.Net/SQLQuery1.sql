Use db;

INSERT into [dbo].[Status](StatusName)
VALUES 
('NotStarted'),
('Loading'),
('InProgress'),
('Arrived'),
('Unloading'),
('Cancelled'),
('Done');

Insert into [dbo].[Product](Name, Weight, Height, Width, Lenght)
Values
('Sofa', 100, 80, 120, 200),
('Chair', 20, 80, 60, 50),
('Bed', 200, 120, 180, 200),
('Armchair', 90, 80, 100, 120);

INSERT into [dbo].[Order](CreatedDate,UpdatedDate,ProductId,StatusId)
VALUES 
('20230618 10:34:09 AM', '20230723 11:15:02 AM', 1, 2),
('20230722 10:10:02 AM', '20230723 11:15:02 AM', 2, 3),
('20230711 00:08:42 AM', '20230712 11:00:52 AM', 3, 6),
('20230512 11:52:13 AM', '20230620 11:15:02 AM', 4, 7);