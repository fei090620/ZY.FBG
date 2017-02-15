using ZY.FBG.Engine.Events;

namespace ZY.FBG.Engine
{
    public class TeamGetGoalEventArgs : GameTimeEventArgs
    {
        public TeamGetGoalEventArgs(string gameTime, string teamID) : base(gameTime)
        {
            TeamID = teamID;
        }

        public string TeamID { get; private set; }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || !GetType().IsEquivalentTo(obj.GetType()))
                return false;

            var other = (TeamGetGoalEventArgs) obj;
            return base.Equals(other)
                && TeamID.Equals(other.TeamID);
        }

        public override int GetHashCode()
        {
            var result = base.GetHashCode();
            result ^= string.IsNullOrEmpty(TeamID)? 0 : TeamID.GetHashCode();

            return result;
        }
    }
}
