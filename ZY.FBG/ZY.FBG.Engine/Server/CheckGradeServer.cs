using System;
using System.Threading;
using ZY.FBG.Engine.Agents;
using ZY.FBG.Engine.Sagas;

namespace ZY.FBG.Engine.Server
{
    public sealed class CheckGradeServer
    {
        public event EventHandler<GetGradeEventArgs> OnGetGradeEvent;
        private CheckGradeServer()
        {
            GameEngine.Instance.OnGameTimeChanged += Instance_OnGameTimeChanged;
        }

        private void Instance_OnGameTimeChanged(object sender, GameTimeEventArgs e)
        {
            var soccer = Repository.Instance.GetById(_soccerID) as SoccerAgent;
            var playGround = Repository.Instance.GetById(_playerGroundID) as PlayGroundAgent;
            if (soccer == null || playGround == null) return;
            if (playGround.TeamADoor.IsInclude(soccer.Status.Pos))
            {
                GetGrade(new GetGradeEventArgs(e.GameTime, playGround.TeamAID));
                return;
            }
            if (playGround.TeamBDoor.IsInclude(soccer.Status.Pos))
            {
                GetGrade(new GetGradeEventArgs(e.GameTime, playGround.TeamBID));
            }
        }

        private void GetGrade(GetGradeEventArgs e)
        {
            var temp = Volatile.Read(ref OnGetGradeEvent);
            if (temp != null) temp(null, e);
        }

        public static readonly CheckGradeServer Instance = new CheckGradeServer();
        public void Init(string soccerID, string playeGroundID)
        {
            _soccerID = soccerID;
            _playerGroundID = playeGroundID;
        }

        private string _soccerID;
        private string _playerGroundID;
    }
}
