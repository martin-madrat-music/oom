using System;
using System.Net;
using System.Globalization;


namespace Task3
{
	public class CompactDisk : IMusicDisks
	{
		private decimal actualprice;

		/// <summary>
		/// Creates a new <see cref="CompactDisk"/>.
		/// </summary>
		/// <param name="bandname">Bandname.</param>
		/// <param name="diskname">Diskname.</param>
		/// <param name="price">Price.</param>
		/// <param name="currency">Currency.</
		/// <param name="ASIN">Amazon ID Nbr.</param>
		public CompactDisk(string bandname, string diskname, decimal price, Currency curr, string asin )
		{
			if (string.IsNullOrWhiteSpace (bandname))
				throw new ArgumentException ("You've to add a bandname to CDs.");
			if (string.IsNullOrWhiteSpace (diskname))
				throw new ArgumentException ("You've to add the title of the disk.");
			if (string.IsNullOrWhiteSpace (asin))
				throw new ArgumentException ("ASIN mustn't be empty.");

			Bandname = bandname;
			Diskname = diskname;
			ASIN = asin;

			UpdatePrice (price,curr);
		}
		public string Bandname { get;}
		public string Diskname { get;}
		public string ASIN { get;}
		public Currency Currency { get; private set;}


		public void UpdatePrice(decimal newprice, Currency curr)
		{
			if (newprice < 0)
				throw new ArgumentException ("Price must not be negative.");
			actualprice = newprice;
			Currency = curr;
		}


		/// <summary>
		/// Gets the price in given currency.
		/// </summary>
		/// <returns>The price.</returns>
		/// <param name="curr">Curr.</param>
		public decimal GetPrice(Currency givencurr)
		{
			if (givencurr == Currency)
				return actualprice;
			else {
				var key = string.Format ("{0}{1}",Currency,givencurr);
				var url = string.Format (@"http://download.finance.yahoo.com/d/quotes.csv?s={0}=X&f=sl1d1t1c1ohgv&e=.csv", key);
				var csv = new WebClient ().DownloadString (url);
				var splittedstring = csv.Split (',');
				var rate = decimal.Parse (splittedstring [1], CultureInfo.InvariantCulture);

				return rate * actualprice;
			}

		}

		public string Description => "CD "+Bandname+Diskname;

	}

}
