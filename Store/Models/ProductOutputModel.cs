using Store.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
	public class ProductOutputModel
	{
		public decimal Price { get; set; }
		public string ProductName { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }

	}
}
