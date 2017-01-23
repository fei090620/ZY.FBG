using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZY.FBG.Engine;
using System.Threading;

namespace ZY.FBG.Engine.Test
{
    [TestClass]
    public class TestGameEngine
    {
        private GameEngine _engine;
        [TestInitialize]
        public void Init()
        {  
            //游戏引擎只有一个
            _engine = GameEngine.Instance;
            //设置游戏时长为1分钟
            int gameTimeOfMiniutes = 1;
            _engine.SetGameTime(gameTimeOfMiniutes);
        }

        [TestMethod]
        public void Test_GameStart()
        {
            //比赛没开始前，状态应该是NoStart
            Assert.IsTrue(_engine.Status == GameStatus.UnStart);

            _engine.Start();

            //比赛开始后，状态为Ining
            Assert.IsTrue(_engine.Status == GameStatus.Inning);

            //模拟线程运行时间1分钟零10毫秒
            Thread.Sleep(_engine.GameTimePeriod * 1000 * 60 + 10);

            //比赛时间过去后，状态为Over
            Assert.IsTrue(_engine.Status == GameStatus.Over);
        }

        [TestMethod]
        [ExpectedException(typeof(ThreadInterruptedException))]
        public void Test_SetGameTimeWhenGameRunning()
        {
            _engine.Start();

            //比赛开始后，状态为Ining
            Assert.IsTrue(_engine.Status == GameStatus.Inning);

            //比赛进行中修改比赛时间
            _engine.SetGameTime(2);
        }
    }
}
