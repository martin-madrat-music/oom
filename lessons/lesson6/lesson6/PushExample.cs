using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace lesson6
{
    public static class PushExample
    {
        public static void Run()
        {
			
            var w = new Form() { Text = "Push Example", Width = 800, Height = 600 };

            // C# events
			w.MouseMove += (s, e) => Console.WriteLine($"[MouseMove event] ({e.X}, {e.Y})");

            // Rx observables
            IObservable<Point> moves = Observable.FromEventPattern<MouseEventArgs>(w, "MouseMove").Select(x => x.EventArgs.Location);

            moves
				.Subscribe(e => Console.WriteLine($"[A] ({e.X}, {e.Y})"))
                ;

            moves
                .DistinctUntilChanged()
				.Subscribe(e => Console.WriteLine($"[B] ({e.X}, {e.Y})"))
                ;

            moves
                .Sample(TimeSpan.FromSeconds(1))
               .DistinctUntilChanged()
				.Subscribe(e => Console.WriteLine($"[C] ({e.X}, {e.Y})"))
                ;

            moves
                .Throttle(TimeSpan.FromSeconds(0.2))
                .DistinctUntilChanged()
				.Subscribe(e => Console.WriteLine($"[D] ({e.X}, {e.Y})"))
                ;

            Application.Run(w);
        }
    }
}
