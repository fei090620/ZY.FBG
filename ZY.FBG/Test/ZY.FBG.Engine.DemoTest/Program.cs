using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZY.FBG.Engine.DemoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine g = GameEngine.Instance;
            g.SetGameTime(1);
            SoccerAgent soccer = SoccerAgent.Instance;
            g.Start();
            Thread.Sleep(1000 * 10);
            soccer.ChangeDirectionTo(1);
            Thread.Sleep(1000 * 10);
            soccer.ChangeDirectionTo(3);

            Console.ReadKey();
        }
    }
}
