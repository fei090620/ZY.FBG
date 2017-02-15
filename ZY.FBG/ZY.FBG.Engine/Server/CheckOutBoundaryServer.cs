using System;
using System.Threading;
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

        private void Instance_OnGameTimeChanged(object sender, GameTimeEventArgs e)
        {
            var soccer = Repository.Instance.GetById(_soccerID);
            var playGround = Repository.Instance.GetById(_playerGroundID);
            if (soccer == null || playGround == null) return;
            SoccerOutBoundaried(new SoccerOutBoundaryEventArgs(e.GameTime, (soccer as SoccerAgent).Status.Pos));
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
