using System;
using System.Threading;
using ADCC.Common.Datas;
using ZY.FBG.Engine.Agents;
using ZY.FBG.Engine.Sagas;

namespace ZY.FBG.Engine.Server
{
    public sealed class CheckOutBoundaryServer
    {
        public static readonly CheckOutBoundaryServer Instance = new CheckOutBoundaryServer();
        public event EventHandler<SoccerOutBoundaryEventArgs> OnSoccerOutBoudary;
        private CheckOutBoundaryServer()
        {
            GameEngine.Instance.OnGameTimeChanged += Instance_OnGameTimeChanged;
        }

        private string _soccerID;
        private string _playerGroundID;
        private Point3D _lastInBoundaryPos;

        private void Instance_OnGameTimeChanged(object sender, GameTimeEventArgs e)
        {
            var soccer = Repository.Instance.GetById(_soccerID) as SoccerAgent;
            var playGround = Repository.Instance.GetById(_playerGroundID) as PlayGroundAgent;
            if (soccer == null || playGround == null) return;
            if (playGround.PlayGround.IsInclude(soccer.Status.Pos))
            {
                _lastInBoundaryPos = soccer.Status.Pos;
                return;
            }
            SoccerOutBoundaried(new SoccerOutBoundaryEventArgs(e.GameTime, soccer.Status.Pos, _lastInBoundaryPos));
        }

        private void SoccerOutBoundaried(SoccerOutBoundaryEventArgs e)
        {
            var temp = Volatile.Read(ref OnSoccerOutBoudary);
            if (temp != null) temp(null, e);
        }

        public void Init(string soccerID, string playerGroundID)
        {
            _soccerID = soccerID;
            _playerGroundID = playerGroundID;
        }
    }
}
