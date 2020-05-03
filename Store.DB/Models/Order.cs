using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DB.Models
{
	public class Order
	{
		public long? Id { get; set; }
		public DateTime OrderDate { get; set; }
		public City City { get; set; }
		public List<OrderList> OrderList { get; set; }
		public Product Product { get; set; }


	}
}
