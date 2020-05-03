using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DB.Models
{
	public class ProductStorage
	{
		public int? Id { get; set; }
		public City City { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
		public string Money { get; set; }

	}
}
