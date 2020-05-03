using Store.Core.Common;
using Store.DB;
using Store.DB.Models;
using System;
using System.Threading.Tasks;

namespace StoreRepository
{
	public class OrderRepository : IOrderRepository
	{
		private IOrderStorage _orderStorege;
		public OrderRepository(IOrderStorage orderStorege)
		{
			_orderStorege = orderStorege;
		}

		public async ValueTask<RequestResult<Order>> AddOrder(Order dataModel)
		{
			var result = new RequestResult<Order>();
			try
			{
				_orderStorege.TransactionStart();
				string country;
				decimal currency=1;
				
				switch (dataModel.City.Id)
				{
					case (int)CountryTypeEnam.Belarus:
						country = "UAH";
						currency = await CurCurrency.GetCurrentCurrency(country);
						break;
					case (int)CountryTypeEnam.Ukraine:
						country = "BYN";
						currency = await CurCurrency.GetCurrentCurrency(country);
						break;
				}
				result.RequestData = await _orderStorege.OrderAdd(dataModel, currency);
				_orderStorege.TransactionCommit();
				result.IsOkay = true;
			}
			catch (Exception ex)
			{
				_orderStorege.TransactioRollBack();
				result.ExMessage = ex.Message;
			}
			return result;
		}


	}
}
