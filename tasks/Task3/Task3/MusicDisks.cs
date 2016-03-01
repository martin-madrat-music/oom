using System;

namespace Task3
{
	public interface IMusicDisks
	{
		/// <summary>
		/// Gets the description.
		/// </summary>
		/// <value>The description.</value>
		string Description{ get;}

		/// <summary>
		/// Gets the price.
		/// </summary>
		/// <returns>The price.</returns>
		/// <param name="Currency">Currency.</param>
		decimal GetPrice(Currency Currency);
	}
}

