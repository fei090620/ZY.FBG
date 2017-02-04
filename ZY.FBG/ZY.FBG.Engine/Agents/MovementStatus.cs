using ADCC.Common.Datas;

namespace ZY.FBG.Engine
{
    public class MovementStatus 
    {
        public MovementStatus(int? speed = null, 
                              int? direction = null, 
                              Point3D pos = null)
        {
            Speed = speed;
            Direction = direction;
            Pos = pos;
        }

        public int? Speed { get; private set; }
        public int? Direction { get; private set; }
        public Point3D Pos { get; private set; }

        public void UpdatePos()
        {

        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || ! GetType().IsEquivalentTo(obj.GetType()))
                return false;

            var other = obj as MovementStatus;
            return Speed.Equals(other.Speed)
                && Direction.Equals(other.Direction)
                && Pos.Equals(other.Pos);
        }

        public override int GetHashCode()
        {
            int result = 0;
            result ^= Speed == null ? 0 : Speed.GetHashCode();
            result ^= Direction == null ? 0 : Direction.GetHashCode();
            result ^= Pos == null ? 0 : Pos.GetHashCode();

            return result;
        }
    }
}
