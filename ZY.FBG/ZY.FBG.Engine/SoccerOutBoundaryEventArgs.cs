using ADCC.Common.Datas;

namespace ZY.FBG.Engine
{
    public class SoccerOutBoundaryEventArgs : GameTimeEventArgs
    {
        public SoccerOutBoundaryEventArgs(string gameTime, Point3D outBoundaryPos, Point3D inBoundaryPos) : base(gameTime)
        {
            OutBoundaryPos = outBoundaryPos;
            InBoundaryPos = inBoundaryPos;
        }

        public Point3D OutBoundaryPos { get; private set; }
        public Point3D InBoundaryPos { get; private set; }

        public override bool Equals(object obj)
        {
            //?
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            //?
            return base.GetHashCode();
        }
    }
}
