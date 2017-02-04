using System;
using System.Threading;
using ZY.FBG.Engine.Agents;

namespace ZY.FBG.Engine.DemoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine g = GameEngine.Instance;
            g.SetGameTime(1);
            SoccerAgent soccer = SoccerAgent.CreateNew("11");
            g.Start();
            Thread.Sleep(1000 * 10);
           

            Console.ReadKey();
        }
    }
}
