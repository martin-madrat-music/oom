using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reactive.Subjects;
using static System.Console;

namespace Task6
{
	public static class myPull
	{
		public static void doStuff()
		{
			//IObservable is equivalent zu IEnumerable
			//x.Subscribe ist equivalent zur foreach-schleife
			//Subject = Observable && Observer zu gleich!!! 
		
			var source = new Subject<int> ();
			var vinylsource = new Subject<Vinyl> ();


			var diskThread = new Thread(() =>
            {
				int j=0;
				var vinyls=new Vinyl[] {
						new Vinyl("Queen","Queen",33,25,13.99m,Currency.EUR),
						new Vinyl("Queen","Queen II",33,25,13.99m,Currency.EUR),
						new Vinyl("Queen","Sheer Heart Attack",33,25,13.99m,Currency.EUR),
						new Vinyl("Queen","A Night at the Opera",33,25,13.99m,Currency.EUR),
						new Vinyl("Queen","A Day at the Races",33,25,13.99m,Currency.EUR),
						new Vinyl("Queen","News of the World",33,25,13.99m,Currency.EUR),
						new Vinyl("Queen","Jazz",33,25,13.99m,Currency.EUR),
						new Vinyl("Queen","The Game",33,25,13.99m,Currency.EUR),
						new Vinyl("Queen","Hot Spaces",33,25,13.99m,Currency.EUR),
						new Vinyl("Queen","The Works",33,25,13.99m,Currency.EUR),
						new Vinyl("Queen","A Kind of Magic",33,25,13.99m,Currency.EUR),
						new Vinyl("Queen","The Miracle",33,25,13.99m,Currency.EUR),
						new Vinyl("Queen","Innuendo",33,25,13.99m,Currency.EUR),
						new Vinyl("Queen","Made in Heaven",33,25,13.99m,Currency.EUR),
						new Vinyl("Queen","The Cosmos Rocks",33,25,13.99m,Currency.EUR)
				};

                vinylsource
                         .Where(x => x.Diskname.Length > 10)
                         .Subscribe(x => Console.WriteLine(x.Diskname));
                
                while (j<vinyls.Length){
					
					Thread.Sleep(500);
					vinylsource.OnNext(vinyls[j]);
                    j++;
                }
			});
			diskThread.Start ();

			var t = new Thread(() =>
				{ 
					int i=0;
					while (true){
						/*Befehle im Thread die blockieren (wie Sleep) --> schlecht. sehr schlecht. */
						Thread.Sleep(1000);
						Console.WriteLine("Thread "+i);
						source.OnNext(i);
						//source.OnError(); //beendet stream wenn hinig
						//source.OnCompleted(); //beendet stream wenn es dezidiert start und endpunkt gibt
						i++;
					}
				});
			//t.Start ();
		}
	}
}
