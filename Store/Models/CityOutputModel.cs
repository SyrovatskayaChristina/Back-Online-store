using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
	public class CityOutputModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public bool IsForeign { get; set; }


	}
}
