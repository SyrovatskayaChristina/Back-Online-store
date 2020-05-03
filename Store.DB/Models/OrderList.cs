using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DB.Models
{
	public class OrderList
	{
		public long? Id { get; set; }
		public Order? Order { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }

	}
}
