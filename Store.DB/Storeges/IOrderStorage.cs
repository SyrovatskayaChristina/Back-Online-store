using Store.DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DB
{
	public interface IOrderStorage
	{
		ValueTask<Order> OrderAdd(Order order, decimal currency);
		ValueTask OrderListAdd(List<OrderList> orderLists, long orderId, decimal currency);
		ValueTask<Order> GetOrderWithOrderList(long? id);
		void TransactionCommit();
		void TransactionStart();
		void TransactioRollBack();


	}
}