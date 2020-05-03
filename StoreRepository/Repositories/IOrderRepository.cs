using Store.DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreRepository
{
	public interface IOrderRepository
	{
		ValueTask<RequestResult<Order>> AddOrder(Order dataModel);
	}
}