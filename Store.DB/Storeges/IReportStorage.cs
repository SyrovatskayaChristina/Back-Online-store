using Store.Common;
using Store.DB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DB.Storeges
{
	public interface IReportStorage
	{
		ValueTask<List<City>> FindHowMuchMoneyIs();
		ValueTask<List<Product>> GetProduct(ReportTypeEnum typeEnam);
		ValueTask<List<City>> MostPopular();
		ValueTask<List<Category>> MoreThen5Goods();
		ValueTask<OrderByCountry> SumOfOrders();
		ValueTask<List<OrderByTime>> OrdersByTime(DateTime DateFrom, DateTime DateTo);
	}
}