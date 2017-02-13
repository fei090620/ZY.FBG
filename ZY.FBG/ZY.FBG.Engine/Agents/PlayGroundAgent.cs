using System;
using ADCC.Common.Datas;
using ZY.FBG.Engine.Events;
using System.Threading;

namespace ZY.FBG.Engine.Agents
{
    public class PlayGroundAgent : DomainObject
    {
        public event EventHandler<GameTimeEventArgs> OnSoccerOutGround;
        public event EventHandler<GameTimeEventArgs> OnTeamAScore;
        public event EventHandler<GameTimeEventArgs> OnTeamBScore;
        private PlayGroundAgent()
        {
            GameEngine.Instance.OnGameTimeChanged += Instance_OnGameTimeChanged;
        }

        private void Instance_OnGameTimeChanged(object sender, GameTimeEventArgs e)
        {
            if (Soccer == null) return;
            if (!PlayGround.IsInclude(Soccer.Status.Pos)) SoccerOutGround(e);
            if (TeamADoor.IsInclude(Soccer.Status.Pos)) TeamAScored(e);
            if (TeamBDoor.IsInclude(Soccer.Status.Pos)) TeamBScored(e);
        }

        private void SoccerOutGround(GameTimeEventArgs e)
        {
            var temp = Volatile.Read(ref OnSoccerOutGround);
            if (temp != null) temp(null, e);
        }

        private void TeamAScored(GameTimeEventArgs e)
        {
            var temp = Volatile.Read(ref OnTeamAScore);
            if (temp != null) temp(null, e);
        }

        private void TeamBScored(GameTimeEventArgs e)
        {
            var temp = Volatile.Read(ref OnTeamBScore);
            if (temp != null) temp(null, e);
        }

        public static PlayGroundAgent CreateNew(string id, Area playGround, Area teamADoor, Area teamBDoor)
        {
            PlayGroundAgent ground = new PlayGroundAgent
            {
                ID = id,
                PlayGround = playGround,
                TeamADoor = teamADoor,
                TeamBDoor = teamBDoor
            };

            return ground;
        }




        public SoccerAgent Soccer { get; set; }
        public Area PlayGround { get; private set; }
        public Area TeamADoor { get; private set; }
        public Area TeamBDoor { get; private set; }
    }
}
