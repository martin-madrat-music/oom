using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Task4
{
	public static class ExchangeRates
	{
		private static Dictionary<string,decimal> exchangeRate = new Dictionary<string, decimal> ();
		public static decimal Get(Currency givenCurrency, Currency exchangeableCurrency)
		{
			if (givenCurrency == exchangeableCurrency)
				return 1;

			else {
				var key = string.Format ("{0}{1}",givenCurrency,exchangeableCurrency);

				if (exchangeRate.ContainsKey (key))
					return exchangeRate [key];

				var url = string.Format (@"http://download.finance.yahoo.com/d/quotes.csv?s={0}=X&f=sl1d1t1c1ohgv&e=.csv", key);
				var csv = new WebClient ().DownloadString (url);
				var splittedstring = csv.Split (',');
				var rate = decimal.Parse(splittedstring [1], CultureInfo.InvariantCulture);

				exchangeRate [key] = rate;

				return rate;
			}
		}
	}
}

