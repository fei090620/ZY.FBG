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
            GameEngine.Instance.OnGameTimeChanged += Instance_OnGameTimeChanged;
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

        private void Instance_OnGameTimeChanged(object sender, GameTimeEventArgs e)
        {
            Status.UpdatePos();
            Debug.WriteLine("({0},{1},{2})", Status.Pos.X, Status.Pos.Y, Status.Pos.Z);
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
