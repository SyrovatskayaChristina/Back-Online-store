using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Common
{
	public static class CurCurrency
	{
		public static async ValueTask <decimal> GetCurrentCurrency(string country)
		{
			string URI = "https://www.cbr-xml-daily.ru/daily_json.js";
			WebRequest request = WebRequest.CreateHttp(URI);
			Stream dataStream;
			WebResponse response = await request.GetResponseAsync();
			string result;
			using (dataStream = response.GetResponseStream())
			{
				StreamReader reader = new StreamReader(dataStream);
				result = reader.ReadToEnd();
			}
			response.Close();
			JObject currency = JObject.Parse(result);
			var RequiredCurrency = (decimal)currency.SelectToken($"$.Valute.{country}.Value");
			return RequiredCurrency;
		}
	}
}
