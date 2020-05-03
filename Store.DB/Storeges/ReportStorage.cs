using Dapper;
using Microsoft.Extensions.Options;
using Store.Common;
using Store.Core.ConfigurationOptions;
using Store.DB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DB.Storeges
{
	public class ReportStorage : IReportStorage
	{
		private IDbConnection connection;


		public ReportStorage(IOptions<StorageOptions> storageOptions)
		{
			this.connection = new SqlConnection(storageOptions.Value.DBConnectionString);
		}


		internal static class SpName
		{
			public const string HowMuchMoney = "HowMuchMoney";
			public const string EndedProducts = "EndedProducts";
			public const string InWarehouseNotInCities = "OnWarehouseAndNotInSpbAndMsc1";
			public const string MostPopularProduct = "MostPopularProduct";
			public const string FindCategoryMoreThen5Goods = "FindCategoryMoreThen5Goods";
			public const string NobodyOrdered = "NobodyOrdered";
			public const string OrderSumByCountry = "OrderSumByCountry";
			public const string SpecificSalesInformation = "SpecificSalesInformation";

		}

		public async ValueTask<List<City>> FindHowMuchMoneyIs()
		{
				try
				{
					var result = await connection.QueryAsync<City, decimal, City>(
						SpName.HowMuchMoney, (c, p) =>
						 {
							 City city = c;
							 city.Money = p;
							 return city;
						 },
					commandType: CommandType.StoredProcedure,
					splitOn: "Money");
					return result.ToList();
				}
				catch (SqlException ex)
				{
					throw ex;
				}
		}



		public async ValueTask<List<City>> MostPopular()
		{
				try
				{

					var result = await connection.QueryAsync<City, string, City>(
						SpName.MostPopularProduct, (c, p) =>
						{
							City city = c;
							city.ProductName = p;
							return city;
						},
					param: null,
					commandType: CommandType.StoredProcedure,
					splitOn: "MostPopularProduct");
					return result.ToList();
				}
				catch (SqlException ex)
				{
					throw ex;
				}
		}

		public async ValueTask<List<Product>> GetProduct(ReportTypeEnum typeEnam)
		{
			string procName = SpName.EndedProducts;

			switch (typeEnam)
			{
				case ReportTypeEnum.WereSaledButEndedInStore:
					procName = SpName.EndedProducts;
					break;
				case ReportTypeEnum.InWarehouseNotInCities:
					procName = SpName.InWarehouseNotInCities;
					break;
				case ReportTypeEnum.NobodyOrdered:
					procName = SpName.NobodyOrdered;
					break;
			}
				try
				{

					var result = await connection.QueryAsync<Product>(
						procName,
					param: null,
					commandType: CommandType.StoredProcedure);
					return result.ToList();
				}
				catch (SqlException ex)
				{
					throw ex;
				}
		}

		public async ValueTask<List<Category>> MoreThen5Goods()
		{
				try
				{

					var result = await connection.QueryAsync<Category>(
						SpName.FindCategoryMoreThen5Goods,
					param: null,
					commandType: CommandType.StoredProcedure);
					return result.ToList();
				}
				catch (SqlException ex)
				{
					throw ex;
				}
		}



		public async ValueTask<OrderByCountry> SumOfOrders()
		{
				try
				{

					var result = await connection.QueryAsync<OrderByCountry>(
						SpName.OrderSumByCountry,
					param: null,
					commandType: CommandType.StoredProcedure);
					return result.FirstOrDefault();
				}
				catch (SqlException ex)
				{
					throw ex;
				}
		}


		public async ValueTask<List<OrderByTime>> OrdersByTime(DateTime DateFrom, DateTime DateTo)
		{
				try
				{


					var result = await connection.QueryAsync<OrderByTime, City, decimal, int, Product, OrderByTime>(
						SpName.SpecificSalesInformation, (o, c, tc,tq, p) =>
						{
							OrderByTime order = o;
							order.City = c;
							order.TotalCost = tc;
							order.TotalQuantity = tq;
							order.Product = p;
							return order;
						},
					param: new { DateFrom, DateTo },
					commandType: CommandType.StoredProcedure,
					splitOn: "Id,TotalCost,TotalQuantity,Id");
					return result.ToList();
				}
				catch (SqlException ex)
				{
					throw ex;
				}
		}

	}

}
