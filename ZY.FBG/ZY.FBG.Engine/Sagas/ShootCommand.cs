namespace ZY.FBG.Engine.Sagas
{
    public class ShootCommand : Message, ICommand
    {
        public ShootCommand(string shootPlayerId, string shootTeamId, string soccerId, MovementStatus shootParameters)
        {
            ShootParameters = shootParameters;
            ShootPlayerID = shootPlayerId;
            ShootTeamID = shootTeamId;
            SoccerID = soccerId;
        }

        public string ShootPlayerID { get; private set; }
        public string ShootTeamID { get; private set; }
        public string SoccerID { get; private set; }
        public MovementStatus ShootParameters { get; private set; }
    }
}
