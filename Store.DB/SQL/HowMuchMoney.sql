USE [SQL-HW]
GO
/****** Object:  StoredProcedure [dbo].[HowMuchMoney]    Script Date: Вс 03.05.20 23:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[HowMuchMoney] AS
BEGIN
--Сколько у тебя гипотетических денег в каждом городе, а также на складе 
Select c.Name  ,sum(Price*Quantity) as Money
from dbo.Product_Storege ps 
inner join dbo.Product p on ps.ProductId=p.Id
inner join dbo.City c on ps.CityId=c.id
group by c.Name ;
end
