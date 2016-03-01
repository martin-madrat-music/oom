using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3 {
	class Program {
		static void Main(string[] args){
			var disks = new IMusicDisks[] {
				new CompactDisk("Slayer","Repentless",21.99m,Currency.EUR,"B00ZU6IVXW"),
				new CompactDisk("Night Falls Last","Deathwalker",8.99m,Currency.EUR,"B00NDJF398"),
				new CompactDisk("Obscura","Acróasis",14.99m,Currency.EUR,"B018A1MUEO"),
				new CompactDisk("Comeback Kid","Die Knowing",20.99m,Currency.EUR,"B00HQ5XK04"),
				new CompactDisk("Architects","Lost Forever/Lost Together",12.99m,Currency.EUR,"B00HUGK7N2"),
				new Vinyl("The Doors","Doors",20.99m,Currency.EUR,33,25),
				new Vinyl("David Bowie","Blackstar",21.99m,Currency.EUR,45,30),
				new Vinyl("Georg Danzer","Traurig aber wahr",4.55m,Currency.EUR,33,30)
			};


			var currency = Currency.EUR;
			foreach (var disk in disks)
				Console.WriteLine ("{1}{0}{2} {4}\t{3}",disk.Diskname.PadRight(28,' '),disk.Bandname.PadRight(20,' '),disk.GetPrice(currency),disk.ASIN,currency);

			Console.WriteLine ("\n\n");
				

			Console.WriteLine ("\n\n");

			disks [4].UpdatePrice (19.99m, Currency.EUR);

			Console.WriteLine ("{1}{0}{2} {4}\t{3}\n\n",cds[4].Diskname.PadRight(28,' '),cds[4].Bandname.PadRight(20,' '),cds[4].GetPrice(currency),cds[4].ASIN,currency);


			currency = Currency.USD;
			foreach (var disk in disks)
				Console.WriteLine ("{1}{0}{2} {4}\t{3}",disk.Diskname.PadRight(28,' '),disk.Bandname.PadRight(20,' '),disk.GetPrice(currency),disk.ASIN,currency);

		}
	}
}
