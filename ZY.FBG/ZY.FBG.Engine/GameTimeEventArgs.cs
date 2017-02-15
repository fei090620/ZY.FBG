using System;

namespace ZY.FBG.Engine
{
    public class GameTimeEventArgs : EventArgs
    {
        private readonly string _gameTime;
        public GameTimeEventArgs(string gameTime)
        {
            _gameTime = gameTime;
        }

        public string GameTime { get { return _gameTime; } }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj == null || !GetType().IsEquivalentTo(obj.GetType()))
                return false;

            var other = obj as GameTimeEventArgs;
            return string.CompareOrdinal(GameTime, other.GameTime) == 0;   
        }

        public override int GetHashCode()
        {
            int result = 0;
            result ^= string.IsNullOrEmpty(GameTime) ? 0 : GameTime.GetHashCode();
            return result;
        }
    }
}
