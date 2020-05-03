using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DB.Models
{
	public class OrderByCountry
	{
		public decimal SalesMadeInRF { get; set; }
		public decimal SalesMadeAbroad { get; set; }
	}
}
