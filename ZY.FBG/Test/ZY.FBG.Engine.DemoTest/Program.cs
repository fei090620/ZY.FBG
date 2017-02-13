using ADCC.Common.Datas;
using System;
using System.Threading;
using ZY.FBG.Engine.Agents;
using ZY.FBG.Engine.Sagas;
using ZY.FBG.Engine.Events;
using System.Collections.Generic;
using System.Linq;

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

            IEnumerable<Point3D> groundaryPoses = new[] { new Point3D(0, 0), new Point3D(100, 0), new Point3D(100, 100), new Point3D(0, 100), new Point3D(0, 0) };
            Curve groundOutBoundary = new Curve(groundaryPoses);
            Area groundArea = Area.CreateNew(groundOutBoundary);

            IEnumerable<Point3D> teamADoorPoses = new[] {new Point3D(25, 0), new Point3D(75, 0), new Point3D(75, 25), new Point3D(25, 25),  new Point3D(25, 0) };
            IEnumerable<Point3D> teamBDoorPoses = new[] { new Point3D(25, 100), new Point3D(25, 75), new Point3D(75,75),new Point3D(75,100), new Point3D(25,100)};
            Curve teamADoorOutBoundary = new Curve(teamADoorPoses);
            Curve teamBDoorOutBoundary = new Curve(teamBDoorPoses);
            Area teamADoorArea = Area.CreateNew(teamADoorOutBoundary);
            Area teamBDoorArea = Area.CreateNew(teamBDoorOutBoundary);
            PlayGroundAgent ground = PlayGroundAgent.CreateNew(Guid.NewGuid().ToString(),
                groundArea, teamADoorArea, teamBDoorArea);

            ground.Soccer = soccer;
            game.Start();
            Thread.Sleep(5 * 1000);
            var shoot = new ShootCommand(no1PlayerID, aTeamID, soccerID, new MovementStatus(10, 3, no1PlayerInitialPos));
            shoot.ID = Guid.NewGuid().ToString();
            Bus.Send(shoot);

            Console.ReadKey();
        }
    }
}
