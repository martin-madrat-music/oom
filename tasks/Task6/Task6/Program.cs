using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using System.Threading;

namespace Task6 {
	class Program {
		public static void Main(string[] args){
			var disks = new IMusicDisks[] {
				new CompactDisk("Slayer ","Repentless","B00ZU6IVXW",21.99m,Currency.EUR),
				new CompactDisk("Night Falls Last ","Deathwalker","B00NDJF398",8.99m,Currency.EUR),
				new CompactDisk("Obscura ","Acróasis","B018A1MUEO",14.99m,Currency.EUR),
				new CompactDisk("Comeback Kid ","Die Knowing","B00HQ5XK04",20.99m,Currency.EUR),
				new CompactDisk("Architects ","Lost Forever/Lost Together","B00HUGK7N2",12.99m,Currency.EUR),
				new Vinyl("The Doors ","Doors",33,25,20.99m,Currency.EUR),
				new Vinyl("David Bowie ","Blackstar",45,30,21.99m,Currency.EUR),
				new Vinyl("Georg Danzer ","Traurig aber wahr",33,30,4.55m,Currency.EUR)
			};
			
			Console.WriteLine ("\n\n");
			/*
			var vinyls = disks.Where(y => y==Task6.Vinyl);
			foreach (var x in vinyls)
				Console.WriteLine(x + " ");
			*/
			//SerializeDisks (disks);
			myPull.doStuff();
			//myTask.doStuff ();
		}


		private static void SerializeDisks (IEnumerable<IMusicDisks> disks){

			var settings = new JsonSerializerSettings () {
				Formatting = Formatting.Indented,
				TypeNameHandling = TypeNameHandling.Auto
			};	
			Console.WriteLine(JsonConvert.SerializeObject(disks, settings));

			var json = JsonConvert.SerializeObject(disks, settings);
			var filename = Path.Combine("/home/raphael/git_repositories/oom/tasks/Task4","output.json");
			File.WriteAllText (filename, json);

			var txtFromFile = File.ReadAllText (filename);
			var disksFromFile = JsonConvert.DeserializeObject<IMusicDisks[]> (txtFromFile, settings);
			var currency = Currency.USD;
			foreach (var x in disksFromFile)
				Console.WriteLine ("{0} {1} {2}",x.Description.PadRight(40), x.Price.convert(currency).Amount,currency);
			
		}
	
		//private static decimal CalculateExchangeRate (Currency givenCurrency, Currency exchangeableCurrency){
		//	Task.Run(async() =>
		//		{
		//			var key = string.Format ("{0}{1}",givenCurrency,exchangeableCurrency);
		//			//var url = string.Format (@"http://download.finance.yahoo.com/d/quotes.csv?s={0}=X&f=sl1d1t1c1ohgv&e=.csv", key);
		//			Uri uri = new System.Uri("http://download.finance.yahoo.com/d/quotes.csv?s={0}=X&f=sl1d1t1c1ohgv&e=.csv");
		//			/*Cannot await 'void' expression*/
		//			string csv = await new WebClient().DownloadStringAsync(uri);
		//			var splittedstring = csv.Split (',');
		//			var rate = decimal.Parse(splittedstring [1], CultureInfo.InvariantCulture);
		//			return rate;
		//		});
			

		//}
		
	}
}