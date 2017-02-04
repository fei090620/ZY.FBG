using System;
using ZY.FBG.Engine.Repository;

namespace ZY.FBG.Engine.Command
{
    public class ShootCommandExecuter : ICommandExecuter<ShootCommand>
    {
        public void Execute(ShootCommand newStatus)
        {
            var soccer = SoccerRepository.Instance.Get(newStatus.SoccerID);
            var movementStatus = new MovementStatus(newStatus.ShootSpeed, newStatus.ShootDirection);
            soccer.UpdateMovementStatus(movementStatus);
        }
    }
}
