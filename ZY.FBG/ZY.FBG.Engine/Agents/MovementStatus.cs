using System.Diagnostics;
using ADCC.Common.Datas;
using ADCC.Common.Tools;

namespace ZY.FBG.Engine
{
    public class MovementStatus 
    {
        public MovementStatus(Point3D pos,
                              int? speed = null, 
                              int? direction = null)
        {
            Speed = speed;
            Direction = (int)((double)direction).ToRadian();
            Pos = pos;
        }

        public int? Speed { get; private set; }
        public int? Direction { get; private set; }
        public Point3D Pos { get; private set; }

        public void UpdatePos()
        {
            if (Direction == null 
                || Speed == null)
                return;

            Pos = Pos.GetNextPoint((int)Direction, (int)Speed);
            Debug.WriteLine("Pos is {0}:{1}", Pos.X, Pos.Y);
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
            result ^= Pos?.GetHashCode() ?? 0;

            return result;
        }
    }
}
