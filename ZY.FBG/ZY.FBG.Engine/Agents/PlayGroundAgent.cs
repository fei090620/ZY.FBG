using System;
using System.Diagnostics;
using ADCC.Common.Datas;
using ZY.FBG.Engine.Events;
using System.Threading;

namespace ZY.FBG.Engine.Agents
{
    public class PlayGroundAgent : DomainObject
    {
        private PlayGroundAgent()
        {
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

        public void SetTeamAID(string teamAId)
        {
            TeamAID = teamAId;
        }

        public void SetTeamBID(string teamBId)
        {
            TeamBID = teamBId;
        }

        public string TeamAID { get; private set; }
        public string TeamBID { get; private set; }
        public Area PlayGround { get; private set; }
        public Area TeamADoor { get; private set; }
        public Area TeamBDoor { get; private set; }
    }
}
