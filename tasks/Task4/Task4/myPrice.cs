using System;

namespace Task4
{
	/// <summary>
	/// My price, connected with unit.
	/// </summary>
	public class myPrice
	{
		public myPrice (decimal amount, Currency unit)
		{
			Amount = amount;
			Unit = unit;
		}
		/// <summary>
		/// Gets the amount.
		/// </summary>
		/// <value>The amount.</value>
		public decimal Amount{get;}
		/// <summary>
		/// Gets the unit.
		/// </summary>
		/// <value>The unit.</value>
		public Currency Unit{ get;}

		public myPrice convert(Currency target){
			if (target == Unit)
				return this;
			else
				return new myPrice(Amount * ExchangeRates.Get(Unit, target), target);
		}

	}

	

}

