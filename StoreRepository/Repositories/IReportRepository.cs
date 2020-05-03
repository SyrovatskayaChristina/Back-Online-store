using Store.Common;
using Store.DB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreRepository.Repositories
{
	public interface IReportRepository
	{
		ValueTask<RequestResult<List<City>>> FindOutHowMuchMoney();
		ValueTask<RequestResult<List<Product>>> Report(ReportTypeEnum reportTypeEnum);
		ValueTask<RequestResult<List<City>>> GetMostPopularProduct();
		ValueTask<RequestResult<List<Category>>> GetCategoryMoreThen5Goods();
		ValueTask<RequestResult<OrderByCountry>> GetOrdersSumByCountry();
		ValueTask<RequestResult<List<OrderByTime>>> GetOrdersByTime(DateTime DateFrom, DateTime DateTo);
	}
}