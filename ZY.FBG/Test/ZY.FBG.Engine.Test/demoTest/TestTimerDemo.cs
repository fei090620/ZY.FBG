using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace ZY.FBG.Engine.Test.demoTest
{
    [TestClass]
    public class TestTimerDemo
    {
        [TestMethod]
        public void TestMethod1()
        {
            int i = 0;
            Timer t = new Timer(x=> 
            {
                Console.WriteLine("{0}", i++);
            },i,5,2);

            //Thread thread= new Thread(new ThreadStart(()=> 
            //{
            //    Console.WriteLine(t.GetLifetimeService());
            //}));

            //thread.Start();
        }
    }
}
