using Store.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
	public class OrderListInputModel
	{
		public long? Id { get; set; }
		public int? OrderId{ get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public float Price { get; set; }

	}
}
