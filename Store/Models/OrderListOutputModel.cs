using Store.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
	public class OrderListOutputModel
	{
		public long ProductId { get; set; }
		public string ProductBrand { get; set; }
		public string ProductName { get; set; }
		public string ProductModel { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
}
