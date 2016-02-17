using System;

namespace Task2
{
	public class Bandmember
	{
		private int equAmount;
		/// <summary>
		/// Creates a new band.
		/// </summary>
		/// <param name="firstName">First name.</param>
		/// <param name="sureName">Sure name.</param>
		/// <param name="instrument">Instrument.</param>
		/// <param name="equipmentAmount">Equipment amount.</param>
		public Bandmember(string firstname, string surename, Instrument instrument, int equipmentamount)
		{
			if (string.IsNullOrEmpty (firstname))
				throw new ArgumentException ("You've to give a name to your member.");
			if (string.IsNullOrEmpty (surename))
				throw new ArgumentException ("You've to give a name to your member.");
			FirstName = firstname;
			SureName = surename;
			UpdateEquipment (equipmentamount, instrument);
		}
		public string FirstName { get;}
		public string SureName { get;}
		public Instrument Instr{ get; private set;}

		public int GetEquipmentAmount()
		{
			return equAmount;
		}



		/// <summary>
		/// Updates the equipment (and maybe also the instrument.
		/// </summary>
		/// <param name="newEquAmount">New equ amount.</param>
		/// <param name="newInstrument">New instrument.</param>
		public void UpdateEquipment(int newEquAmount, Instrument newInstrument)
		{
			if (newEquAmount < 1)
				throw new ArgumentException ("As a bandmember, you must have at least one equipment.");
			equAmount = newEquAmount;
			Instr = newInstrument;
		}

	}


}

