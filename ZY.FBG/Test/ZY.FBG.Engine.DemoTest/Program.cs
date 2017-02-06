using ADCC.Common.Datas;
using System;
using System.Threading;
using ZY.FBG.Engine.Agents;
using ZY.FBG.Engine.Sagas;

namespace ZY.FBG.Engine.DemoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = Repository.Instance;
            GameEngine game = GameEngine.Instance;
            game.SetGameTime(1);
            string soccerID = Guid.NewGuid().ToString();
            Point3D soccerInitialPos = new Point3D(1,1);
            int soccerInitialDirection = 0;
            int soccerInitialSpeed = 0;
            SoccerAgent soccer = SoccerAgent.CreateNew(soccerID, new MovementStatus(soccerInitialSpeed, soccerInitialDirection, soccerInitialPos));
            repository.Save(soccer);

            string aTeamID = Guid.NewGuid().ToString();
            string no1PlayerID = Guid.NewGuid().ToString();
            Point3D no1PlayerInitialPos = soccerInitialPos;
            int no1PlayerInitialDirection = 0;
            int no1PlayerInitialSpeed = 0;
            PlayerAgent no1Player = PlayerAgent.CreateNew(no1PlayerID, new MovementStatus(no1PlayerInitialSpeed, no1PlayerInitialDirection, no1PlayerInitialPos), aTeamID);
            repository.Save(no1Player);
            Bus.RegesteSaga<ShootCommand, ShootSaga>();

            game.Start();
            Thread.Sleep(5 * 1000);
            var shoot = new ShootCommand(no1PlayerID, aTeamID, soccerID, new MovementStatus(10, 3, no1PlayerInitialPos));
            shoot.ID = Guid.NewGuid().ToString();
            Bus.Send(shoot);

            Console.ReadKey();
        }
    }
}
