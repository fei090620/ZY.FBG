using System.Threading;

namespace ZY.FBG.Engine
{
    public class GameEngine
    {
        public static readonly GameEngine Instance = new GameEngine();
        public GameStatus Status { get; private set; }
        public int GameTime { get; private set; }
        private Timer _timer;

        private GameEngine()
        {
            Status = GameStatus.UnStart;
            //_timer = Timer
        }

        public void SetGameTime(int gameTimeOfMiniutes)
        {
            GameTime = gameTimeOfMiniutes;
        }

        public void Start()
        {
            Status = GameStatus.Inning;
            Thread.Sleep(GameTime);
            Status = GameStatus.Over;
        }
    }
}
