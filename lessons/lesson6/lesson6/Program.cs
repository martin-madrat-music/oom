using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            //PullExample.Run();
			Console.WriteLine("enumerables: foreach (array)");
			IEnumerable<int> xs = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
			foreach (var x in xs) Console.Write(x + " "); Console.WriteLine();

			Console.WriteLine("enumerables: foreach (list)");
			xs = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
			foreach (var x in xs) Console.Write(x + " "); Console.WriteLine();

			Console.WriteLine("enumerables: behind the scenes");
			var e = xs.GetEnumerator();
			while (e.MoveNext()) Console.Write(e.Current + " "); Console.WriteLine();

			Console.WriteLine("enumerables: queries (filter) - Where(x => x % 2 == 0)");
			var ys = xs.Where(x => x % 2 == 0);
			foreach (var y in ys) Console.Write(y + " "); Console.WriteLine();

			Console.WriteLine("enumerables: queries (map) - Select(x => x * x)");
			ys = xs.Select(x => x * x);
			foreach (var y in ys) Console.Write(y + " "); Console.WriteLine();
			Console.ReadLine();
          	//  PushExample.Run();

           // TasksExample.Run();
        }
    }
}
