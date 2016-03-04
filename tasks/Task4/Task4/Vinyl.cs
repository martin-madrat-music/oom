using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using Newtonsoft.Json;

namespace Task4
{
	public class Vinyl : IMusicDisks
	{
		public myPrice actualprice;

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
			if (speed!=33 && speed !=45)
				throw new ArgumentException ("There are only two speeds available for vinyl discs [33 & 45 rpm].");
			if (size!=30 && size !=15 && size!=25)
				throw new ArgumentException ("There are only three sizes available for vinyl discs [15,25 & 30 cm].");
			
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
		/// Gets the size.
		/// </summary>
		/// <value>The size.</value>
		public int Size { get;}

		/// <summary>
		/// Updates the price.
		/// </summary>
		/// <param name="newprice">Newprice.</param>
		/// <param name="curr">Curr.</param>
		public void UpdatePrice(decimal newprice, Currency curr)
		{
			if (newprice < 0)
				throw new ArgumentException ("Price must not be negative.");
			actualprice = new myPrice (newprice, curr);
		}
			

		public string Description => "Vinyl "+Bandname+Diskname;

		public myPrice Price => actualprice;

	}
}