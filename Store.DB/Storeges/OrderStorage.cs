using Dapper;
using Microsoft.Extensions.Options;
using Store.Core.ConfigurationOptions;
using Store.DB.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DB
{
	public class OrderStorage : IOrderStorage
	{
		private IDbConnection connection;

		private IDbTransaction transaction;

		public OrderStorage(IOptions<StorageOptions> storageOptions)
		{
			this.connection = new SqlConnection(storageOptions.Value.DBConnectionString);
		}

		public void TransactionStart()
		{
			connection.Open();
			transaction = this.connection.BeginTransaction();
		}

		public void TransactionCommit()
		{
			this.transaction?.Commit();
			connection?.Close();
		}

		public void TransactioRollBack()
		{
			this.transaction?.Rollback();
			connection?.Close();
		}

		internal static class SpName
		{
			public const string OrderInsert = "Order_Insert";
			public const string OrderUpdate = "Order_Update";
			public const string OrderGetById = "OrderWithOrderList_GetById";
			public const string OrderListInsert = "OrderList_Insert";
			public const string OrderListGetById = "OrderList_GetById";
			public const string AddOrderDetails = "AddOrderDetails";
		}

		public async ValueTask<Order> OrderAdd(Order order, decimal currency)
		{
			try
			{
				DynamicParameters orderModelParams = new DynamicParameters(new
				{
					CityId = order.City.Id,

				});
				var result = await connection.QueryAsync<long>(
						SpName.OrderInsert,
						orderModelParams,
						transaction: transaction,
						commandType: CommandType.StoredProcedure);
				order.Id = result.FirstOrDefault();
				await OrderListAdd(order.OrderList, (long)order.Id, currency);

			}
			catch (SqlException ex)
			{
				throw ex;
			}
			return await GetOrderWithOrderList(order.Id);
		}


		public async ValueTask OrderListAdd(List<OrderList> orderLists, long orderId, decimal currency)
		{
			try
			{
				for (int i = 0; i < orderLists.Count; i++)
				{
					decimal price = orderLists[i].Price /= currency;
					long productId = (int)orderLists[i].Product.Id;
					int quantity = orderLists[i].Quantity;
					decimal Price = orderLists[i].Price;

					var resulr = await connection.QueryAsync<long>(
					   SpName.AddOrderDetails,
					   new
					   {
						   orderId,
						   productId,
						   quantity,
						   price
					   },
						transaction: transaction,
					   commandType: CommandType.StoredProcedure);
				}
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}


		public async ValueTask<Order> GetOrderWithOrderList(long? id)
		{
			try
			{
				var dictionary = new Dictionary<long, Order>();
				var result = await connection.QueryAsync<Order, City, OrderList, Product, Order>(
					SpName.OrderGetById,
					(order, city, orderList, product) =>
					{
						Order newOrder;
						if (!dictionary.TryGetValue((long)order.Id, out newOrder))
						{
							newOrder = order;
							newOrder.OrderList = new List<OrderList>();
							dictionary.Add((long)newOrder.Id, newOrder);
						}
						newOrder.City = city;
						newOrder.OrderList.Add(orderList);
						orderList.Product = product;
						return newOrder;
					},
					param: new { id },
					transaction: transaction,
					commandType: CommandType.StoredProcedure,
					splitOn: "Id");
				return result.FirstOrDefault();
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}

	}
}
