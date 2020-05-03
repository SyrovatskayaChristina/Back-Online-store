using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
	public class OrderByCountryOutputModel
	{
		public decimal SalesMadeInRF { get; set; }
		public decimal SalesMadeAbroad { get; set; }

	}
}
