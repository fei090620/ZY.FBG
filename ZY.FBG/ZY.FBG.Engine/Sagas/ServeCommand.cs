using ADCC.Common.Datas;

namespace ZY.FBG.Engine.Events
{
    public class ServeCommand : Message, ICommand
    {
        public ServeCommand(string soccerID, MovementStatus serveMoveStatus)
        {
            SoccerID = soccerID;
            ServeParameters = serveMoveStatus;
        }

        public string SoccerID { get; private set; }
        public MovementStatus ServeParameters { get; private set; }
    }
}
