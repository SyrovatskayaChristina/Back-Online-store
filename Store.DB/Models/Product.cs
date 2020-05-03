using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DB.Models
{
	public class Product
	{
		public long? Id { get; set; }
		public decimal Price { get; set; }
		public string ProductName { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public Category Category { get; set; }
		public Category SubCategory { get; set; }
		public City City { get; set; }

	}
}
