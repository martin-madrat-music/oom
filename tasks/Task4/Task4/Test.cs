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
			var x = new Vinyl("bertram","herbert",23.90m,Currency.EUR,33,25);
			x.UpdatePrice (234m, Currency.EUR);
			Assert.IsTrue(x.actualprice.Amount!=23.90m);
		}	

		[Test]
		public void UpdateCurrency(){
			var x = new Vinyl("bertram","herbert",23.90m,Currency.EUR,33,25);
			x.UpdatePrice (234m, Currency.USD);
			Assert.IsTrue(x.actualprice.Unit!=Currency.EUR);
			Assert.IsTrue(x.actualprice.Unit==Currency.USD);
		}

	}
}

