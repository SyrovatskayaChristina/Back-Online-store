using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DB.Models
{
	public class City
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public bool IsForeign { get; set; }
		public string ProductName { get; set; }
		public decimal Money { get; set; }
	}
}
