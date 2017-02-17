using System.Diagnostics;
using ZY.FBG.Engine.Events;

namespace ZY.FBG.Engine.Sagas
{
    public class ServeSaga : SagaBase<ServeCommand> 
        ,IStartWithMessage<ServeCommand>
        ,ICanHandleMessage<ChangSoccerMoveStatusEvent>
    {
        public void Handle(ServeCommand message)
        {
            GameEngine.Instance.ChangeGameFlagTo(false);
            Debug.WriteLine("Game is run again by Serve Command!");

            ChangSoccerMoveStatusEvent changeMoveEvent = new ChangSoccerMoveStatusEvent(message.SoccerID, message.ServeParameters);
            changeMoveEvent.ID = message.ID;
            Bus.Send(changeMoveEvent);
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
            Debug.WriteLine("Soccer change move status by serve!");
        }
    }
}
