using Store.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
	public class OrderInputModel
	{

		public int CityId { get; set; }

		public List<OrderListInputModel> OrderListInputModels { get; set; }
	}
}
