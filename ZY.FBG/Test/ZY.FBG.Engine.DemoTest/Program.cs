﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            g.Start();
            //Thread.Sleep(2000);
            //g.SetGameTime(2);
            //g.Start();

            Console.ReadKey();
        }
    }
}