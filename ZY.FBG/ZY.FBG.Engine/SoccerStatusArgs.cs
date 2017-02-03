using ADCC.Common.Datas;

namespace ZY.FBG.Engine
{
    public class SoccerStatusArgs : GameEventArgs
    {
        public SoccerStatusArgs(string gameTime, 
                                int? newSpeed = null, 
                                int? newDirection = null, 
                                Point3D newPos = null):base(gameTime)
        {
            NewSpeed = newSpeed;
            NewDirection = newDirection;
            NewPos = newPos;
        }

        public int? NewSpeed { get; private set; }
        public int? NewDirection { get; private set; }
        public Point3D NewPos { get; private set; }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || ! GetType().IsEquivalentTo(obj.GetType()))
                return false;

            var other = obj as SoccerStatusArgs;
            return GameTime.Equals(other.GameTime)
                && NewSpeed.Equals(other.NewSpeed)
                && NewDirection.Equals(other.NewDirection)
                && NewPos.Equals(other.NewPos);
        }

        public override int GetHashCode()
        {
            int result = 0;
            result ^= base.GetHashCode();
            result ^= NewSpeed == null ? 0 : NewSpeed.GetHashCode();
            result ^= NewDirection == null ? 0 : NewDirection.GetHashCode();
            result ^= NewPos == null ? 0 : NewPos.GetHashCode();

            return result;
        }
    }
}
