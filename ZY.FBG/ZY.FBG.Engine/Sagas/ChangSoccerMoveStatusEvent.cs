using ZY.FBG.Engine.Events;

namespace ZY.FBG.Engine.Sagas
{
    public class ChangSoccerMoveStatusEvent : Message, IDomentEvent
    {
        public ChangSoccerMoveStatusEvent(string moveObjectId, MovementStatus moveStatus)
        {
            MoveObjetcID = moveObjectId;
            MoveStatus = moveStatus;
        }

        public MovementStatus MoveStatus { get; private set; }
        public string MoveObjetcID { get; private set; }
    }
}
