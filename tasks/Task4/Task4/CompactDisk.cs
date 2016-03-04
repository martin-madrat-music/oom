using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using Newtonsoft.Json;


namespace Task4
{
	public class CompactDisk : IMusicDisks
	{
		private myPrice actualprice;

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


		public void UpdatePrice(decimal newprice, Currency curr)
		{
			if (newprice < 0)
				throw new ArgumentException ("Price must not be negative.");
			actualprice = new myPrice(newprice, curr);
		
		}

		/// <summary>
		/// Description of Disk.
		/// </summary>
		public string Description => "CD "+Bandname+Diskname;

		public myPrice Price => actualprice;

	}

}
