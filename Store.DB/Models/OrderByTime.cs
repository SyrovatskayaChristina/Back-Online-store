using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DB.Models
{
	public class OrderByTime
	{
		public long? Id { get; set; }
		public DateTime OrderDate { get; set; }
		public City City{ get; set; }
		public decimal TotalCost { get; set; }
		public int TotalQuantity { get; set; }
		public Product Product { get; set; }
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }

	}
}
