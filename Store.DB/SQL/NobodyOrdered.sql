USE [SQL-HW]
GO
/****** Object:  StoredProcedure [dbo].[NobodyOrdered]    Script Date: Вс 03.05.20 23:32:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[NobodyOrdered]
as
begin
select p.Id, p.ProductName, p.brand, p.model, p.Price, p.CategoryId,p.SubCategoryId 
from Product p
--join dbo.Category c on c.Id=p.CategoryId
where p.Id not in (
select ol.ProductId
from dbo.OrderList ol)
end