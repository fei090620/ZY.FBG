namespace ZY.FBG.Engine.Command
{
    public class ShootCommand : ICommand
    {
        public ShootCommand(string shootPlayerId, string soccerId, int shootSpeed, int shootDirection)
        {
            ShootDirection = shootDirection;
            ShootSpeed = shootSpeed;
            ShootPlayerID = shootPlayerId;
            SoccerID = soccerId;
        }

        public int ShootDirection { get; private set; }
        public int ShootSpeed { get; private set; }
        public string ShootPlayerID { get; private set; }
        public string SoccerID { get; private set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
