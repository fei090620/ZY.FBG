using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using ZY.FBG.Engine.Events;

namespace ZY.FBG.Engine
{
    public class GameEngine
    {
        public static readonly GameEngine Instance = new GameEngine();
        private object _lockObject = new object();
        public GameStatus Status { get; private set; }
        public int GameTimePeriod { get; private set; }
        public string GameTime { get; private set; }
        public event EventHandler<GameTimeEventArgs> OnGameTimeChanged;
        private DateTime _time;
        private Timer _timer;
        private DateTime _endTime;
        private ManualResetEvent _manualEvent;
        private bool _flag = false;

        private GameEngine()
        {
            Status = GameStatus.UnStart;
        }

        /// <summary>
        /// 设置比赛时间
        /// </summary>
        /// <param name="gameTimeOfMiniutes"></param>
        public void SetGameTime(int gameTimeOfMiniutes)
        {
            if (Status == GameStatus.Inning)
                throw new ThreadInterruptedException("当前比赛进行时，不允许重新设定比赛时间");
            
            GameTimePeriod = gameTimeOfMiniutes;
        }

        /// <summary>
        /// 开始比赛
        /// </summary>
        public void Start()
        {
            //初始化比赛计时为“00：00”
            _time = new DateTime(0, DateTimeKind.Utc);
            //初始化比赛状态为“Inning”
            Status = GameStatus.Inning;
            //初始化比赛结束时间
            _endTime = _time.AddMinutes(GameTimePeriod);
            //初始化信号事件
            _manualEvent = new ManualResetEvent(false);
            //初始化定时器
            _timer = new Timer(x=>RunGame(), null, 0, 1000);
        }

        /// <summary>
        /// 运行游戏
        /// </summary>
        private void RunGame()
        {
            Thread.CurrentThread.IsBackground = false;
            if (_flag)
                return;

            lock (_lockObject)
            {
                if (string.CompareOrdinal(_time.ToLongTimeString(), _endTime.ToLongTimeString()) == 0)
                {
                    _timer.Dispose();
                    _manualEvent.Set();
                    _flag = true;
                    Status = GameStatus.Over;
                }

                //每一秒更新一次
                _time = _time.AddSeconds(1);
            }

            GameTime = FormateTime(_time);
            GameTimeChanged(new GameTimeEventArgs(GameTime));
            Debug.WriteLine(GameTime);
        }

        /// <summary>
        /// 比赛时间更新触发器
        /// </summary>
        /// <param name="e"></param>
        private void GameTimeChanged(GameTimeEventArgs e)
        {
            var temp = Volatile.Read(ref OnGameTimeChanged);
            if (temp != null) temp(null, e);             
        }

        /// <summary>
        /// 分钟转化为秒
        /// </summary>
        /// <param name="minute"></param>
        /// <returns></returns>
        private int ToSecond(int minute)
        {
            return minute * 60;
        }

        /// <summary>
        /// 将分钟：秒钟格式化为00：00形式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private string FormateTime(DateTime time)
        {
            if (time == null)
                throw new ArgumentNullException("在对比赛时间进行格式化时，传入时间参数为null");
            
            var minutes = time.Minute;
            var seconds = time.Second;
            var formateMinute = FormateTimeBySingleToDouble(minutes);
            var formateSecond = FormateTimeBySingleToDouble(seconds);

            return new StringBuilder(formateMinute).Append(":").Append(formateSecond).ToString();
        }

        private string FormateTimeBySingleToDouble(int minuteOrSecond)
        {
            return minuteOrSecond / 10 == 0 ? new StringBuilder("0").Append(minuteOrSecond).ToString() : minuteOrSecond.ToString();
        }
    }
}
