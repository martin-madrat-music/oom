using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Task4 {
	class Program {
		public static void Main(string[] args){
			var disks = new IMusicDisks[] {
				new CompactDisk("Slayer ","Repentless",21.99m,Currency.EUR,"B00ZU6IVXW"),
				new CompactDisk("Night Falls Last ","Deathwalker",8.99m,Currency.EUR,"B00NDJF398"),
				new CompactDisk("Obscura ","Acróasis",14.99m,Currency.EUR,"B018A1MUEO"),
				new CompactDisk("Comeback Kid ","Die Knowing",20.99m,Currency.EUR,"B00HQ5XK04"),
				new CompactDisk("Architects ","Lost Forever/Lost Together",12.99m,Currency.EUR,"B00HUGK7N2"),
				new Vinyl("The Doors ","Doors",20.99m,Currency.EUR,33,25),
				new Vinyl("David Bowie ","Blackstar",21.99m,Currency.EUR,45,30),
				new Vinyl("Georg Danzer ","Traurig aber wahr",4.55m,Currency.EUR,33,30)
			};



			Console.WriteLine ("\n\n");

			SerializeDisks (disks);
		}
		private static void SerializeDisks (IEnumerable<IMusicDisks> disks){

			var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
			Console.WriteLine(JsonConvert.SerializeObject(disks));
					
			var text = JsonConvert.SerializeObject(disks, settings);
			var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			var filename = Path.Combine(desktop, "all_music.json");
			File.WriteAllText(filename, text);

			/*print the file in a correct way*/
			var textFromFile = File.ReadAllText(filename);
			var itemsFromFile = JsonConvert.DeserializeObject<IMusicDisks[]>(textFromFile, settings);

			foreach (var x in itemsFromFile)
				Console.WriteLine ("{0} {1} {2}", x.Description.PadRight(40,' '), x.Price.Amount, x.Price.Unit);
				
		}
	
	}
}