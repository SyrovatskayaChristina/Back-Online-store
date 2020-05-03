using System;
using System.Collections.Generic;
using System.Text;

namespace StoreRepository
{
	public class RequestResult<T>
	{
		public T RequestData { get; set; }
		public bool IsOkay { get; set; }
		public string ExMessage { get; set; }
	}
}
