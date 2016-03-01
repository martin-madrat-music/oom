using System;
using System.Net;
using System.Globalization;


namespace Task3
{
	public class Vinyl : IMusicDisks
	{
		private decimal actualprice;

		/// <summary>
		/// Creates a new <see cref="Vinyl"/>.
		/// </summary>
		/// <param name="bandname">Bandname.</param>
		/// <param name="diskname">Diskname.</param>
		/// <param name="price">Price.</param>
		/// <param name="currency">Currency.</
		/// <param name="ASIN">Amazon ID Nbr.</param>
		public Vinyl(string bandname, string diskname, decimal price, Currency curr, int speed ,int size)
		{
			if (string.IsNullOrWhiteSpace (bandname))
				throw new ArgumentException ("You've to add a bandname to Vinyls.");
			if (string.IsNullOrWhiteSpace (diskname))
				throw new ArgumentException ("You've to add the title of the disk.");
		/*	if (speed!=33 || speed !=45)
				throw new ArgumentException ("There are only two speeds available for vinyl discs [33 & 45 rpm].");
			if(size!=30 ||size !=15 || size!=25)
				throw new ArgumentException ("There are only three sizes available for vinyl discs [15,25 & 30 cm].");
			*/	
			Bandname = bandname;
			Diskname = diskname;
			Speed = speed;
			Size = size;

			UpdatePrice (price,curr);
		}
		/// <summary>
		/// Gets the bandname.
		/// </summary>
		/// <value>The bandname.</value>
		public string Bandname { get;}

		/// <summary>
		/// Gets the diskname.
		/// </summary>
		/// <value>The diskname.</value>
		public string Diskname { get;}

		/// <summary>
		/// Gets the speed.
		/// </summary>
		/// <value>The speed.</value>
		public int Speed { get;}

		/// <summary>
		/// Gets the currency.
		/// </summary>
		/// <value>The currency.</value>
		public Currency Currency { get; private set;}

		public int Size { get;}

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

		public string Description => "Vinyl "+Bandname+Diskname;

	}
}