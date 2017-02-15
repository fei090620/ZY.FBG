using System;
using ADCC.Common.Datas;
using ZY.FBG.Engine.Events;
using System.Diagnostics;

namespace ZY.FBG.Engine.Agents
{
    /// <summary>
    /// 球员Agent
    /// </summary>
    public class PlayerAgent : DomainObject
    {
        protected PlayerAgent()
        {
        }

        public static PlayerAgent CreateNew(string id, MovementStatus movementStatus = null, string teamId = null)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            PlayerAgent player = new PlayerAgent
            {
                ID = id,
                Status = movementStatus == null ? new MovementStatus(0,0,null):movementStatus, 
                TeamID = teamId
            };

            return player;
        }

        public MovementStatus Status { get; private set; }
        public string TeamID { get; private set; }

        public void UpdateMovementStatus(MovementStatus newMovementStatus)
        {
            if (newMovementStatus == null)
                return;
            
            Status = newMovementStatus;
        }
    }
}
