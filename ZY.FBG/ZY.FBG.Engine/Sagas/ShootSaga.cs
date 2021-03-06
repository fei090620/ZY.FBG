﻿using System;
using System.Diagnostics;
using ZY.FBG.Engine.Events;

namespace ZY.FBG.Engine.Sagas
{
    public class ShootSaga : SagaBase<ShootCommand>,
        IStartWithMessage<ShootCommand>,
        ICanHandleMessage<ChangSoccerMoveStatusEvent>
    {
        public void Handle(ShootCommand message)
        {
            var cmd = new ChangSoccerMoveStatusEvent(message.SoccerID, message.ShootParameters);
            cmd.ID = message.ID;
            Debug.WriteLine("shoot command is start!");
            Bus.Send(cmd);
        }

        public void Handle(ChangSoccerMoveStatusEvent message)
        {
            if (message == null)
                return;
            
            dynamic soccer = _repository.GetById(message.MoveObjetcID);
            if (soccer == null)
                return;

            soccer.UpdateMovementStatus(message.MoveStatus);
            _isCompleted = true;
            Debug.WriteLine("soccer move status is updated by shoot command!");
        }
    }
}
