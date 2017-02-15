using ADCC.Common.Datas;

namespace ZY.FBG.Engine
{
    public class SoccerOutBoundaryEventArgs : GameTimeEventArgs
    {
        public SoccerOutBoundaryEventArgs(string gameTime, Point3D outBoundaryPos) : base(gameTime)
        {
            OutBoundaryPos = outBoundaryPos;
        }

        public Point3D OutBoundaryPos { get; private set; }

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
