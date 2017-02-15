using ADCC.Common.Datas;
using System;
using System.Threading;
using ZY.FBG.Engine.Agents;
using ZY.FBG.Engine.Sagas;
using ZY.FBG.Engine.Events;
using System.Collections.Generic;

namespace ZY.FBG.Engine.DemoTest
{
    class Program
    {
        private static void Main(string[] args)
        {
            var repository = Repository.Instance;
            var game = GameEngine.Instance;
            game.SetGameTime(1);
            var soccerId = Guid.NewGuid().ToString();
            var soccerInitialPos = new Point3D(1,1);
            var soccerInitialDirection = 0;
            var soccerInitialSpeed = 0;
            var soccer = SoccerAgent.CreateNew(soccerId, new MovementStatus(soccerInitialSpeed, soccerInitialDirection, soccerInitialPos));
            repository.Save(soccer);

            var aTeamID = Guid.NewGuid().ToString();
            var no1PlayerID = Guid.NewGuid().ToString();
            var no1PlayerInitialPos = soccerInitialPos;
            var no1PlayerInitialDirection = 0;
            var no1PlayerInitialSpeed = 0;
            var no1Player = PlayerAgent.CreateNew(no1PlayerID, new MovementStatus(no1PlayerInitialSpeed, no1PlayerInitialDirection, no1PlayerInitialPos), aTeamID);
            repository.Save(no1Player);
            Bus.RegesteSaga<ShootCommand, ShootSaga>();

            IEnumerable<Point3D> groundaryPoses = new[] { new Point3D(0, 0), new Point3D(100, 0), new Point3D(100, 100), new Point3D(0, 100), new Point3D(0, 0) };
            Curve groundOutBoundary = new Curve(groundaryPoses);
            Area groundArea = Area.CreateNew(groundOutBoundary);

            IEnumerable<Point3D> teamADoorPoses = new[] {new Point3D(25, 0), new Point3D(75, 0), new Point3D(75, 25), new Point3D(25, 25),  new Point3D(25, 0) };
            IEnumerable<Point3D> teamBDoorPoses = new[] { new Point3D(25, 100), new Point3D(25, 75), new Point3D(75,75),new Point3D(75,100), new Point3D(25,100)};
            var teamADoorOutBoundary = new Curve(teamADoorPoses);
            var teamBDoorOutBoundary = new Curve(teamBDoorPoses);
            var teamADoorArea = Area.CreateNew(teamADoorOutBoundary);
            var teamBDoorArea = Area.CreateNew(teamBDoorOutBoundary);
            var ground = PlayGroundAgent.CreateNew(Guid.NewGuid().ToString(),
                groundArea, teamADoorArea, teamBDoorArea);

            ground.Soccer = soccer;
            game.Start();
            Thread.Sleep(5 * 1000);
            var shoot = new ShootCommand(no1PlayerID, aTeamID, soccerId, new MovementStatus(10, 3, no1PlayerInitialPos))
            {
                ID = Guid.NewGuid().ToString()
            };
            Bus.Send(shoot);

            Console.ReadKey();
        }
    }
}
