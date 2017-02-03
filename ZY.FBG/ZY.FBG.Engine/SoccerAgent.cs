using ADCC.Common.Datas;
using System.Diagnostics;
using System;

namespace ZY.FBG.Engine
{
    /// <summary>
    /// 足球Agent
    /// </summary>
    public class SoccerAgent : ICommand<SoccerStatusArgs>
    {
        private SoccerAgent()
        {
            if (Pos == null)
                Pos = new Point3D(0, 0, 0);

            Speed = 1;
            Direction = 0;
            /* GameEngine.Instance是static成员，必然是在被调用之前初始化，且只初始化一次
            SoccerAgent.Instance道理是一样的
            所以这里的事件绑定只会绑定一次 */
            GameEngine.Instance.OnGameTimeChanged += Instance_OnGameTimeChanged;
        }

        private void Instance_OnGameTimeChanged(object sender, GameEventArgs e)
        {
            Pos = GetNewPos(Pos, Speed, Direction, 1);
            Debug.WriteLine("({0},{1},{2})",Pos.X, Pos.Y, Pos.Z);
        }

        private Point3D GetNewPos(Point3D pos, int speed, int direction, int timeSecond)
        {
            return pos.GetNextPoint(direction, timeSecond * speed);
        }

        public static readonly SoccerAgent Instance = new SoccerAgent();
        public Point3D Pos { get; private set; }
        public int Direction { get; private set; }
        public int Speed { get; private set; }
        public void ChangeSpeedTo (int newSpeed)
        {
            Speed = newSpeed;
        }

        public void SetPos(Point3D pos)
        {
            Pos = pos;
        }

        public void ChangeDirectionTo(int newDirection)
        {
            Direction = newDirection;
        }

        public void UpdateStatus(SoccerStatusArgs newStatus)
        {
            // add code . . .
        }
    }
}
