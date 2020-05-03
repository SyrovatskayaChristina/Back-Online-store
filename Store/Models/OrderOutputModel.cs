using Store.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
	public class OrderOutputModel
	{
		public long? Id { get; set; }
		public string OrderDate { get; set; }
		public string CityName { get; set; }
		public List<OrderListOutputModel> orderListOutputModels { get; set; }
		public string ProductName { get; set; }


	}
}
