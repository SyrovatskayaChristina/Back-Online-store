using Store.Common;
using Store.DB.Models;
using Store.DB.Storeges;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreRepository.Repositories
{
	public class ReportRepository : IReportRepository
	{
		public IReportStorage _commonStorage;
		public ReportRepository(IReportStorage commonStorage)
		{
			_commonStorage = commonStorage;
		}

		public async ValueTask<RequestResult<List<City>>> FindOutHowMuchMoney()
		{
			var result = new RequestResult<List<City>>();
			try
			{
				result.RequestData = await _commonStorage.FindHowMuchMoneyIs();
				result.IsOkay = true;
			}
			catch (Exception ex)
			{
				result.ExMessage = ex.Message;
			}
			return result;
		}

		public async ValueTask<RequestResult<List<City>>> GetMostPopularProduct()
		{
			var result = new RequestResult<List<City>>();
			try
			{
				result.RequestData = await _commonStorage.MostPopular();
				result.IsOkay = true;
			}
			catch (Exception ex)
			{
				result.ExMessage = ex.Message;
			}
			return result;
		}

		public async ValueTask<RequestResult<List<Product>>> Report(ReportTypeEnum reportTypeEnum)
		{
			var result = new RequestResult<List<Product>>();
			try
			{
				result.RequestData = await _commonStorage.GetProduct(reportTypeEnum);
				result.IsOkay = true;
			}
			catch (Exception ex)
			{
				result.ExMessage = ex.Message;
			}
			return result;
		}



		public async ValueTask<RequestResult<List<Category>>> GetCategoryMoreThen5Goods()
		{
			var result = new RequestResult<List<Category>>();
			try
			{
				result.RequestData = await _commonStorage.MoreThen5Goods();
				result.IsOkay = true;
			}
			catch (Exception ex)
			{
				result.ExMessage = ex.Message;
			}
			return result;
		}

		public async ValueTask<RequestResult<List<OrderByTime>>> GetOrdersByTime(DateTime DateFrom, DateTime DateTo)
		{
			var result = new RequestResult<List<OrderByTime>>();
			try
			{
				result.RequestData = await _commonStorage.OrdersByTime(DateFrom, DateTo);
				result.IsOkay = true;
			}
			catch (Exception ex)
			{
				result.ExMessage = ex.Message;
			}
			return result;
		}

		public async ValueTask<RequestResult<OrderByCountry>> GetOrdersSumByCountry()
		{
			var result = new RequestResult<OrderByCountry>();
			try
			{
				result.RequestData = await _commonStorage.SumOfOrders();
				result.IsOkay = true;
			}
			catch (Exception ex)
			{
				result.ExMessage = ex.Message;
			}
			return result;
		}


	}
}
