using System;
using ADCC.Common.Datas;
using ZY.FBG.Engine.Events;

namespace ZY.FBG.Engine.Agents
{
    public class PlayGroundAgent : DomainObject
    {
        private PlayGroundAgent()
        {
            GameEngine.Instance.OnGameTimeChanged += Instance_OnGameTimeChanged;
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

        private void Instance_OnGameTimeChanged(object sender, GameTimeEventArgs e)
        {
            throw new NotImplementedException();
        }

        public Area PlayGround { get; private set; }
        public Area TeamADoor { get; private set; }
        public Area TeamBDoor { get; private set; }
    }
}
