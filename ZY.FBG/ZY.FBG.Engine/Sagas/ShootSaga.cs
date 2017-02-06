using System.Diagnostics;

namespace ZY.FBG.Engine.Sagas
{
    public class ShootSaga : SagaBase<ShootCommand>,
        IStartWithMessage<ShootCommand>,
        ICanHandleMessage<ChangSoccerMoveStatusEvent>
    {
        public void Handle(ShootCommand message)
        {
            Data = message;
            var cmd = new ChangSoccerMoveStatusEvent(message.SoccerID, message.ShootParameters);
            cmd.ID = message.ID;
            Debug.WriteLine("Saga is started by shoot command!");
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
            Debug.WriteLine("Saga is completed by changeSoccerStatusEvent!");
        }
    }
}
