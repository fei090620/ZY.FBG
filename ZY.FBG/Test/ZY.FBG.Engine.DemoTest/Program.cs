using ADCC.Common.Datas;
using System;
using System.Threading;
using ZY.FBG.Engine.Agents;
using ZY.FBG.Engine.Sagas;
using ZY.FBG.Engine.Events;
using System.Collections.Generic;
using ZY.FBG.Engine.Server;
using System.Diagnostics;

namespace ZY.FBG.Engine.DemoTest
{
    class Program
    {
        private static void Main(string[] args)
        {
            #region Initial Game Parameters
            var repository = Repository.Instance;
            var game = GameEngine.Instance;
            game.SetGameTime(1);
            #endregion

            #region Initial Soccer
            var soccerId = Guid.NewGuid().ToString();
            var soccerInitialPos = new Point3D(1, 1);
            var soccerInitialDirection = 0;
            var soccerInitialSpeed = 0;
            var soccer = SoccerAgent.CreateNew(soccerId, new MovementStatus(soccerInitialSpeed, soccerInitialDirection, soccerInitialPos));
            repository.Save(soccer);
            #endregion

            #region Initial Team and Players
            var aTeamID = "TeamA";
            var bTeamID = "TeamB";
            var no1ATeamPlayerID = "TeamA_No.1";
            var no2ATeamPlayerID = "TeamA_No.2";
            var no1BTeamPlayerID = "TeamB_No.1";
            var no2BTeamPlayerID = "TeamB_No.2";
            var no1ATeamPlayerPos = soccerInitialPos;
            var no2ATeamPlayerPos = soccerInitialPos;
            var no1BTeamPlayerPos = soccerInitialPos;
            var no2BTeamPlayerPos = soccerInitialPos;
            var no1ATeamPlayerSpeed = 0;
            var no2ATeamPlayerSpeed = 0;
            var no1BTeamPlayerSpeed = 0;
            var no2BTeamPlayerSpeed = 0;
            var no1ATeamPlayerDirection = 0;
            var no2ATeamPlayerDirection = 0;
            var no1BTeamPlayerDirection = 0;
            var no2BTeamPlayerDirection = 0;
            var no1ATeamPlayer = PlayerAgent.CreateNew(no1ATeamPlayerID, new MovementStatus(no1ATeamPlayerSpeed, no1ATeamPlayerDirection, no1ATeamPlayerPos), aTeamID);
            var no2ATeamPlayer = PlayerAgent.CreateNew(no2ATeamPlayerID, new MovementStatus(no2ATeamPlayerSpeed, no2ATeamPlayerDirection, no2ATeamPlayerPos), aTeamID);
            var no1BTeamPlayer = PlayerAgent.CreateNew(no1BTeamPlayerID, new MovementStatus(no1BTeamPlayerSpeed, no1BTeamPlayerDirection, no1BTeamPlayerPos), bTeamID);
            var no2BTeamPlayer = PlayerAgent.CreateNew(no2BTeamPlayerID, new MovementStatus(no2BTeamPlayerSpeed, no2BTeamPlayerDirection, no2BTeamPlayerPos), bTeamID);
            var teamA = TeamAgent.CreateNew(aTeamID, "ATeam", new[] {no1ATeamPlayer, no2ATeamPlayer });
            var teamB = TeamAgent.CreateNew(bTeamID, "BTeam", new[] { no1BTeamPlayer, no2BTeamPlayer });
            repository.Save(no1ATeamPlayer);
            repository.Save(no2ATeamPlayer);
            repository.Save(no1BTeamPlayer);
            repository.Save(no2BTeamPlayer);
            repository.Save(teamA);
            repository.Save(teamB);
            #endregion

            #region Initial PlayGround
            var playGroundID = "playGround-1111";
            IEnumerable<Point3D> groundaryPoses = new[] { new Point3D(0, 0), new Point3D(100, 0), new Point3D(100, 100), new Point3D(0, 100), new Point3D(0, 0) };
            Curve groundOutBoundary = new Curve(groundaryPoses);
            Area groundArea = Area.CreateNew(groundOutBoundary);

            IEnumerable<Point3D> teamADoorPoses = new[] { new Point3D(25, 0), new Point3D(75, 0), new Point3D(75, 25), new Point3D(25, 25), new Point3D(25, 0) };
            IEnumerable<Point3D> teamBDoorPoses = new[] { new Point3D(25, 100), new Point3D(25, 75), new Point3D(75, 75), new Point3D(75, 100), new Point3D(25, 100) };
            var teamADoorOutBoundary = new Curve(teamADoorPoses);
            var teamBDoorOutBoundary = new Curve(teamBDoorPoses);
            var teamADoorArea = Area.CreateNew(teamADoorOutBoundary);
            var teamBDoorArea = Area.CreateNew(teamBDoorOutBoundary);
            var ground = PlayGroundAgent.CreateNew(playGroundID,
                groundArea, teamADoorArea, teamBDoorArea);
            repository.Save(ground);
            #endregion

            #region Initial UpdateMoveStatusServer
            var updateMoveServer = UpdateMoveStatusServer.Instance;
            updateMoveServer.Register(soccerId);
            updateMoveServer.Register(no1ATeamPlayerID);
            updateMoveServer.Register(no2ATeamPlayerID);
            updateMoveServer.Register(no1BTeamPlayerID);
            updateMoveServer.Register(no2BTeamPlayerID);
            #endregion

            #region Intial CheckOutBoundaryServer
            var checkOutBoundaryServer = CheckOutBoundaryServer.Instance;
            checkOutBoundaryServer.Init(soccerId, playGroundID);
            checkOutBoundaryServer.OnSoccerOutBoudary += (x,y)=> 
            {
                Debug.WriteLine("Soccer is out Boundary in {0} at {1}!",y.GameTime, y.OutBoundaryPos.ToString());
            };
            #endregion

            #region Intial CheckGetGradeServer
            var checkGetGradeServer = CheckGradeServer.Instance;
            checkGetGradeServer.Init(soccerId, playGroundID);
            checkGetGradeServer.OnGetGradeEvent += (x, y) => 
            {
                dynamic team = repository.GetById(y.GetGradeTeamID);
                team.TeamGetSocre();
            };
            #endregion

            #region Intial Commands
            Bus.RegesteSaga<ShootCommand, ShootSaga>();
            #endregion

            #region Play Game
            game.Start();
            Thread.Sleep(5 * 1000);
            var shoot = new ShootCommand(no1ATeamPlayerID, aTeamID, soccerId, new MovementStatus(10, 3, no1ATeamPlayerPos))
            {
                ID = Guid.NewGuid().ToString()
            };
            Bus.Send(shoot);
            #endregion

            Console.ReadKey();
        }
    }
}
