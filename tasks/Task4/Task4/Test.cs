using NUnit.Framework;

namespace Task4
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void CanCreatePrice(){
			var x = new myPrice(1, Currency.EUR);
			Assert.IsTrue(x.Amount == 1);
			Assert.IsTrue(x.Unit == Currency.EUR);
		}

		[Test]
		public void  CheckExchangeRateSameCurrency(){
			var x = ExchangeRates.Get(Currency.EUR, Currency.EUR);
			Assert.IsTrue(x == 1);
		}

		[Test]
		public void CheckExchangeRateDifferentCurrency(){
			var x = ExchangeRates.Get(Currency.EUR, Currency.USD);
			Assert.IsTrue(x != 1);
		}

		[Test]
		public void CanUpdatePrice(){
			var x = new Vinyl("bertram","herbert",33,25,23.90m,Currency.EUR);
			x.UpdatePrice (234m, Currency.EUR);
			Assert.IsTrue(x.actualprice.Amount!=23.90m);
		}	

		[Test]
		public void CanUpdateCurrency(){
			var x = new Vinyl("bertram","herbert",33,25,23.90m,Currency.EUR);
			x.UpdatePrice (234m, Currency.USD);
			Assert.IsTrue(x.actualprice.Unit!=Currency.EUR);
			Assert.IsTrue(x.actualprice.Unit==Currency.USD);
		}

		[Test]
		public void CannotAddEmptyBandname(){

			Assert.Catch (() => {
				var x = new Vinyl ("", "herbert", 33, 25, 23.90m, Currency.EUR);
					
			});

			try{
				var x = new Vinyl("","herbert",33,25,23.90m,Currency.EUR);
			
			}
			catch{
				Assert.Fail ();
			}

		}	

		[Test]
		public void CannotAddEmptyDiskname(){

			Assert.Catch (() => {
				var x = new Vinyl ("bertram", "", 33, 25, 23.90m, Currency.EUR);
			});


			try{
				var x = new Vinyl("bertram","",33,25,23.90m,Currency.EUR);
			
			}
			catch{
				Assert.Fail ();
			}

		}

		[Test]
		public void CannotAddNegativePrice(){
			Assert.Catch (() => {
				var x = new Vinyl ("bertram", "herbert", 33, 25, -23.90m, Currency.EUR);


			});

			try{
				var x = new Vinyl("bertram","herbert",33,25,-23.90m,Currency.EUR);

			}
			catch{
				Assert.Fail ();
			}

		}

	}
}

